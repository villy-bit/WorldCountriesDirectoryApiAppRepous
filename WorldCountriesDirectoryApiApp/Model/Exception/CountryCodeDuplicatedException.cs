namespace WorldCountriesDirectoryApiApp.Model.Exception
{
    public class CountryCodeDuplicatedException : ApplicationException
    {
        public CountryCodeDuplicatedException(string code) : base($"code '{code}' is duplicated") { }
    }
}
