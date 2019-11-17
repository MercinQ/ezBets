namespace ezBet.WebAPI.Model.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ResetPasswordToken { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
    }
}
