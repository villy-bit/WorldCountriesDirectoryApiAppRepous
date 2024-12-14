using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;
using WorldCountriesDirectoryApiApp.Model.Exception;

namespace WorldCountriesDirectoryApiApp.Model
{
    public class CountryScenarios
    {
        // компонент-зависимостей - сторадж стран, инициализируется в конструкторе
        private readonly ICountryStorage _storage;

        public CountryScenarios(ICountryStorage storage)
        {
            _storage = storage;
        }

        //получение списка всех стран
        //GET /api/country -> 200 JSON-массив объектов стран(Country) с полной сериализацией
        public async Task<List<Country>> GetAllAsync()
        {
            return await _storage.GetAllAsync();
        }

        //получение страны по коду alpha2
        //GET /api/country/{code} -> 200 объект страны с полной сериализацией
        //code - url-параметр, в котором передать двухбуквенный код страны, по которому выполняется поиск
        //исключения: CountryCodeFormatException
        public async Task<Country> GetAsync(string isoAlpha2)
        {
            Country? country = await _storage.GetAsync(isoAlpha2);
            if (country == null)
            {
                throw new CountryCodeFormatException(isoAlpha2);
            }
            return country;
        }

        //сохранение новой страны
        //POST /api/country + JSON-объект страны со всеми заполненными полями -> 201 Created
        //исключения: CountryCodeFormatException, CountryCodeDuplicatedException
        public async Task StoreAsync(Country country)
        {
            Country? clone = await _storage.GetAsync(country.isoAlpha2);
            if (clone != null)
            {
                throw new CountryCodeDuplicatedException(country.isoAlpha2);
            }
            await _storage.StoreAsync(country);
        }

        //редактирование страны по коду
        //PATCH /api/country/{code} + JSON-объект страны со всеми полями кроме кода (код не редактируется, остальное может) -> 200 +
        //JSON-объект страны после редактирования
        //code - url-параметр
        //исключения: CountryNotFoundException, CountryCodeFormatException
        public async Task EditAsync(string isoAlpha2, Country country)
        {
            Country? countryEdit = await _storage.GetAsync(isoAlpha2);
            if (countryEdit == null)
            {
                throw new CountryNotFoundException(isoAlpha2);
            }
            await _storage.EditAsync(isoAlpha2, country);
        }

        //удаление страны по коду
        //DELETE /api/country/{code} -> 204 No Content
        //code - url-параметр
        //исключения: CountryNotFoundException, CountryCodeFormatException
        public async Task DeleteAsync(string isoAlpha2)
        {
            if (isoAlpha2 != "")
            {
                Country? airport = await _storage.GetAsync(isoAlpha2);
                if (airport == null)
                {
                    throw new CountryNotFoundException(isoAlpha2);
                }
                await _storage.DeleteAsync(isoAlpha2);
            }
        }
    }
}
