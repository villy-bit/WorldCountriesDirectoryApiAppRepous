namespace WorldCountriesDirectoryApiApp.Api.Messages
{
    public record StringMessage(string Message);
    public record ErrorMessage(string Type, string Message);
}
