public class AuthService
{
    private readonly AuthHandler _handlerChain;

    public AuthService()
    {
        // Tworzymy łańcuch walidacji
        _handlerChain = new UsernameValidator();
        _handlerChain
            .SetNext(new PasswordLengthValidator())
            .SetNext(new PasswordComplexityValidator());
    }

    public void Authenticate(User user)
    {
        Console.WriteLine("🔍 Validating credentials...");

        if (_handlerChain.Handle(user))
        {
            Console.WriteLine($"✅ Authentication successful! Welcome {user.Username}");
        }
        else
        {
            Console.WriteLine("❌ Authentication failed.");
        }
    }
}