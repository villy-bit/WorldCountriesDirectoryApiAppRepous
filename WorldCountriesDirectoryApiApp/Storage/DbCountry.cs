using Microsoft.EntityFrameworkCore;

namespace WorldCountriesDirectoryApiApp.Storage
{
    //[Index(nameof(IsoAlpha2), IsUnique = true)]
    public class DbCountry
    {
        public int Id { get; set; }
        public string ShortName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string IsoAlpha2 { get; set; } = string.Empty;

        public DbCountry() { }

    }
}
