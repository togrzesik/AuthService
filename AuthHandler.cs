public abstract class AuthHandler
{
    protected AuthHandler Next;

    public AuthHandler SetNext(AuthHandler next)
    {
        Next = next;
        return next;
    }

    public virtual bool Handle(User user)
    {
        if (Next != null)
            return Next.Handle(user);
        return true;
    }
}

public class UsernameValidator : AuthHandler
{
    public override bool Handle(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Username))
        {
            Console.WriteLine("❌ Username cannot be empty.");
            return false;
        }

        if (!user.Username.Contains("@"))
        {
            Console.WriteLine("❌ Username must be an email address.");
            return false;
        }

        return base.Handle(user);
    }
}

public class PasswordLengthValidator : AuthHandler
{
    public override bool Handle(User user)
    {
        var config = AuthConfiguration.Instance;
        if (user.Password.Length < config.MinPasswordLength)
        {
            Console.WriteLine($"❌ Password must be at least {config.MinPasswordLength} characters long.");
            return false;
        }

        return base.Handle(user);
    }
}

public class PasswordComplexityValidator : AuthHandler
{
    public override bool Handle(User user)
    {
        var config = AuthConfiguration.Instance;

        if (config.RequireDigit && !user.Password.Any(char.IsDigit))
        {
            Console.WriteLine("❌ Password must contain at least one digit.");
            return false;
        }

        if (config.RequireSpecialChar && !user.Password.Any(ch => !char.IsLetterOrDigit(ch)))
        {
            Console.WriteLine("❌ Password must contain at least one special character.");
            return false;
        }

        return base.Handle(user);
    }
}