namespace HRsystem.Models
{
    public class DepartmentInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public ICollection<PersonBasicInfo> ? PersonBasicInfo { get; set; }
    }
}
