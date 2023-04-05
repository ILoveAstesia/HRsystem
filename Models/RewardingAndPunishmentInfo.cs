using System.ComponentModel.DataAnnotations;

namespace HRsystem.Models
{
    public class RewardingAndPunishmentInfo
    {
        public int Id { get; set; }

        public int PrincipalId { get;set; }
        public int PersonId { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Detail { get; set; }=string.Empty;
    }
}
