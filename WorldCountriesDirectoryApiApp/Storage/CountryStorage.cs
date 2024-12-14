using Microsoft.EntityFrameworkCore;
using WorldCountriesDirectoryApiApp.Model;

namespace WorldCountriesDirectoryApiApp.Storage
{
    public class CountryStorage : ICountryStorage
    {
        private readonly ApplicationDbContext _db;

        public CountryStorage(ApplicationDbContext db)
        {
            _db = db;
        }

        //получение списка всех стран
        public async Task<List<Country>> GetAllAsync()
        {
            return await _db.Countries.
                Select(dbCountry => new Country{
                    shortName = dbCountry.ShortName,
                    fullName = dbCountry.FullName,
                    isoAlpha2 = dbCountry.IsoAlpha2
                }).ToListAsync();
        }

        //получение страны по коду alpha2
        public async Task<Country> GetAsync(string isoAlpha2Code)
        {
            DbCountry? found = await _db.Countries.FirstOrDefaultAsync(a => a.IsoAlpha2 == isoAlpha2Code);
            if (found == null)
            {
                return null;
            }
            return DbToModel(found);
        }

        //сохранение новой страны
        public async Task StoreAsync(Country country)
        {
            DbCountry dbCountry = ModelToDb(country);
            await _db.Countries.AddAsync(dbCountry);
            await _db.SaveChangesAsync();
        }

        //редактирование страны по коду
        public async Task EditAsync(string isoAlpha2, Country country)
        {
            DbCountry? edit = await _db.Countries.FirstOrDefaultAsync(a => a.IsoAlpha2 == country.isoAlpha2);
            if (edit == null)
            {
                return;
            }
            edit.ShortName = country.shortName;
            edit.FullName = country.fullName;
            edit.IsoAlpha2 = country.isoAlpha2;
            await _db.SaveChangesAsync();
        }

        //удаление страны по коду
        public async Task DeleteAsync(string isoAlpha2)
        {
            DbCountry? delete = await _db.Countries.FirstOrDefaultAsync(a => a.IsoAlpha2 == isoAlpha2);
            if (delete != null)
            {
                _db.Countries.Remove(delete);
                await _db.SaveChangesAsync();
            }
        }


        private DbCountry ModelToDb(Country country)
        {
            return new DbCountry()
            {
                Id = 0,
                ShortName = country.shortName,
                FullName = country.fullName,
                IsoAlpha2 = country.isoAlpha2
            };
        }

        private Country DbToModel(DbCountry dbCountry)
        {
            return new Country()
            {
                shortName = dbCountry.ShortName,
                fullName = dbCountry.FullName,
                isoAlpha2 = dbCountry.IsoAlpha2
            };
        }
    }
}
