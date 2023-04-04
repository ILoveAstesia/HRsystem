namespace HRsystem.Models
{
    public class AccountInfo
    {
        public int AccountInfoId { get; set; }
        public string Password { get; set; }=string.Empty;
        public int Autority { get; set; }
    }
}
