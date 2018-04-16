using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EroniX.Core.Domain
{
    public static class DomainValidator
    {
        public static IList<ValidationInfo> Validate(object obj, string[] references = null, bool failFast = true) 
        {
            var validationInfos = new List<ValidationInfo>();

            var results = ValidateSingleObject(obj);
            if(results.Any())
            {
                validationInfos.AddRange(ValidationInfo.ToValidationInfos(results));
                if (failFast)
                    return validationInfos;
            }

            if (references != null)
            {
                foreach (var reference in references)
                {
                    var propertyInfo = obj.GetType().GetProperty(reference);
                    var val = propertyInfo.GetValue(obj);

                    if (val != null)
                    {
                        results = ValidateSingleObject(val);
                        if (results.Any())
                        {
                            validationInfos.AddRange(ValidationInfo.ToValidationInfos(results, reference + "."));
                            if (failFast)
                                return validationInfos;
                        }
                    }
                }
            }

            return validationInfos;
        }

        private static ICollection<ValidationResult> ValidateSingleObject(object obj)
        {
            ICollection<ValidationResult> results = new List<ValidationResult>();
            var validationContext = new ValidationContext(obj);
            Validator.TryValidateObject(obj, validationContext, results);
            return results;
        }
    }
}
