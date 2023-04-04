using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace HRsystem.Models
{
    public class SalaryInfo
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Basic Salary")]
        public float Basic { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public float Bonus { get; set; }
        public float Sum() { return Basic + Bonus; }

    }
}
