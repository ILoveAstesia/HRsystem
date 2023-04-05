namespace HRsystem.Models
{
    public class PersonBasicInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = new string(string.Empty);
        public DepartmentInfo? Department;
        public char Sex { get; set; }
        public int Age { get; set; }
    }
}
