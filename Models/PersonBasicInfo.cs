using System.ComponentModel.DataAnnotations.Schema;
namespace HRsystem.Models
{
    public class PersonBasicInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = new string(string.Empty);
        public string Department { get; set; }= new string(string.Empty);
        public char Sex { get; set; }
        public int Age { get; set; }
    }
}
