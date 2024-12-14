using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using WorldCountriesDirectoryApiApp.Api.Messages;
using WorldCountriesDirectoryApiApp.Model;
using WorldCountriesDirectoryApiApp.Storage;
using WorldCountriesDirectoryApiApp.Model.Exception;

namespace WorldCountriesDirectoryApiApp.Api.Controllers
{
    // CountryController - контроллер для работы со странами
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryScenarios _scenarios;

        public CountryController(CountryScenarios scenarios)
        {
            _scenarios = scenarios;
        }

        // GET /api/country - получить записи о всех странах
        [HttpGet]
        public async Task<List<Country>> GetAllAsync()
        {
            return await _scenarios.GetAllAsync();
        }

        // GET /api/country/{isoAlpha2} - получить страну по коду
        [HttpGet("{isoAlpha2:alpha}")]
        public async Task<IActionResult> GetAsync(string isoAlpha2)
        {
            try
            {
                // 200
                return Ok(await _scenarios.GetAsync(isoAlpha2));
            }
            catch (CountryCodeFormatException ex)
            {
                // 400
                return BadRequest(new ErrorMessage(Type: ex.GetType().Name, Message: ex.Message));
            }
            catch (CountryNotFoundException ex)
            {
                // 404
                return NotFound(new ErrorMessage(Type: ex.GetType().Name, Message: ex.Message));
            }
        }

        // POST /api/country - добавить новую страну
        [HttpPost]
        public async Task<IActionResult> StoreAsync(Country country)
        {
            try
            {
                await _scenarios.StoreAsync(country);
                // 201
                return Created();
            }
            catch (CountryCodeFormatException ex)
            {
                // 400
                return BadRequest(new ErrorMessage(Type: ex.GetType().Name, Message: ex.Message));
            }
            catch (CountryCodeDuplicatedException ex)
            {
                // 409
                return Conflict(new ErrorMessage(Type: ex.GetType().Name, Message: ex.Message));
            }
        }

        // DELETE /api/country/{isoAlpha2} - удалить страну по isoAlpha2
        [HttpDelete("{isoAlpha2:alpha}")]
        public async Task<IActionResult> DeleteAsync(string isoAlpha2)
        {
            try
            {
                await _scenarios.DeleteAsync(isoAlpha2);
                // 204
                return NoContent();
            }
            catch (CountryCodeFormatException ex)
            {
                // 400
                return BadRequest(new ErrorMessage(Type: ex.GetType().Name, Message: ex.Message));
            }
            catch (CountryNotFoundException ex)
            {
                // 404
                return NotFound(new ErrorMessage(Type: ex.GetType().Name, Message: ex.Message));
            }
        }

        // PATCH /api/country/{isoAlpha2} - редактирование страны по коду
        [HttpPatch("{isoAlpha2:alpha}")]
        public async Task<IActionResult> EditAsync(string isoAlpha2, Country country)
        {
            try
            {
                await _scenarios.EditAsync(isoAlpha2, country);
                // 204
                return NoContent();
            }
            catch (CountryCodeFormatException ex)
            {
                // 400
                return BadRequest(new ErrorMessage(Type: ex.GetType().Name, Message: ex.Message));
            }
            catch (CountryNotFoundException ex)
            {
                // 404
                return NotFound(new ErrorMessage(Type: ex.GetType().Name, Message: ex.Message));
            }
        }


    }
}
