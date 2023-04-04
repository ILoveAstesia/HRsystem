using System.ComponentModel.DataAnnotations;

namespace HRsystem.Models
{
    public class RewardingAndPunishmentInfo
    {
        public int Pid { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Detail { get; set; }=string.Empty;
    }
}
