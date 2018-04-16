namespace TimeTableDesigner.Shared.Entity.Web
{
    public class WebSemester : IWebEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public void Initialize(string[] values)
        {
            Id = values[0];
            Name = values[1];
        }
    }
}
