namespace WorldCountriesDirectoryApiApp.Model
{
    public interface ICountryStorage
    {
        //получение списка всех стран
        Task<List<Country>> GetAllAsync();

        //получение страны по коду alpha2
        Task<Country> GetAsync(string isoAlpha2);

        //сохранение новой страны
        Task StoreAsync(Country country);

        //редактирование страны по коду
        Task EditAsync(string isoAlpha2, Country country);

        //удаление страны по коду
        Task DeleteAsync(string isoAlpha2);
    }
}
