namespace WorldCountriesDirectoryApiApp.Model
{
    public class Country
    {
        public string shortName {  get; set; } = string.Empty;
        public string fullName { get; set; } = string.Empty;
        public string isoAlpha2 { get; set; } = string.Empty;

        public Country() { }
    }
}
