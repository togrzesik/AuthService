public sealed class AuthConfiguration
{
    private static readonly Lazy<AuthConfiguration> _instance = new(() => new AuthConfiguration());

    public static AuthConfiguration Instance => _instance.Value;

    public int MinPasswordLength { get; private set; } = 8;
    public bool RequireDigit { get; private set; } = true;
    public bool RequireSpecialChar { get; private set; } = true;

    private AuthConfiguration() { }

    public void SetSecurityRules(int minLength, bool requireDigit, bool requireSpecialChar)
    {
        MinPasswordLength = minLength;
        RequireDigit = requireDigit;
        RequireSpecialChar = requireSpecialChar;
    }
}