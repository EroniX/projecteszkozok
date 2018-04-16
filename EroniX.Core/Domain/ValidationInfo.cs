using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EroniX.Core.Domain
{
    public class ValidationInfo
    {
        public ValidationInfo(string property, string message)
        {
            Property = property;
            Message = message;
        }

        public string Property { get; }

        public string Message { get; }

        public static ICollection<ValidationInfo> ToValidationInfos(ICollection<ValidationResult> validationResults, string prefix = "")
        {
            var coll = new List<ValidationInfo>();
            foreach(var result in validationResults)
            {
                foreach(var prop in result.MemberNames)
                {
                    coll.Add(new ValidationInfo(prefix + prop, result.ErrorMessage));
                }
            }

            return coll;
        }
    }
}
