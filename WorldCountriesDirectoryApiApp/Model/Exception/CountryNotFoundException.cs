namespace WorldCountriesDirectoryApiApp.Model.Exception
{
    public class CountryNotFoundException : ApplicationException
    {
        public CountryNotFoundException() : base("airport is not found") { }
        public CountryNotFoundException(string code) : base($"airport '{code}' is not found") { }
    }
}
