public class Program
{
    public static void Main()
    {
        // Configuration of system
        var config = AuthConfiguration.Instance;
        config.SetSecurityRules(minLength: 8, requireDigit: true, requireSpecialChar: true);

        // Create user 
        var user = new User.Builder()
            .WithUsername("john.doe@example.com")
            .WithPassword("Pass123!")
            .Build();

        // Validate login
        var authService = new AuthService();
        authService.Authenticate(user);

        Console.WriteLine("\n--- Incorrect login attempt ---");
        var badUser = new User.Builder()
            .WithUsername("invalid_user")
            .WithPassword("weak")
            .Build();

        authService.Authenticate(badUser);
    }
}