namespace HRsystem.Models
{
    public class AccountInfo
    {
        public int Id { get; set; }
        public string Password { get; set; }=string.Empty;
        public int Authority { get; set; }
    }
}
