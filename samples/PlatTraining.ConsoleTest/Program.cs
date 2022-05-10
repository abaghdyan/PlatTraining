// See https://aka.ms/new-console-template for more information
Console.WriteLine(nameof(JwtTokenOptions.Secret));
Console.ReadLine();


public class JwtTokenOptions
{
    public const string Section = "Templates";

    public string Secret { get; set; }
    public int AccessTokenDurationInMinutes { get; set; }
    public int AccessTokenDurationInMinutesRememberMe { get; set; }
}