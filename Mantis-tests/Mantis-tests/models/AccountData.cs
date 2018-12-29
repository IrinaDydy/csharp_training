namespace mantis_tests
{
    public class AccountData
    {

        public string Password { get; set; }
        public string Username { get; set; }

        public AccountData(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}