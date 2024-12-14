namespace WorldCountriesDirectoryApiApp.Model.Exception
{
    public class CountryCodeFormatException : ApplicationException
    {
        public CountryCodeFormatException() : base($"isoAlpha2 format error") { }
        public CountryCodeFormatException(string details) : base($"isoAlpha2 format error: {details}") { }
    }
}
