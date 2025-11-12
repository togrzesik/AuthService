public class User
{
    public string Username { get; private set; }
    public string Password { get; private set; }

    private User() { }

    public class Builder
    {
        private readonly User _user = new();

        public Builder WithUsername(string username)
        {
            _user.Username = username;
            return this;
        }

        public Builder WithPassword(string password)
        {
            _user.Password = password;
            return this;
        }

        public User Build()
        {
            if (string.IsNullOrWhiteSpace(_user.Username) || string.IsNullOrWhiteSpace(_user.Password))
                throw new InvalidOperationException("Username and password are required.");

            return _user;
        }
    }
}