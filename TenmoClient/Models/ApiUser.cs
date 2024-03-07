namespace TenmoClient.Models
{
    /// <summary>
    /// Return value from login endpoint
    /// </summary>
    public class ApiUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            string userIdString = UserId.ToString();
            //return $"{UserId} - {Username}"
            return $"{userIdString.PadLeft(10)}{Username.PadLeft(10)}";
        }
    }

}
