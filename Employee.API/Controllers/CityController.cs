using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Models.Models;
using Employee.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _iCityRepository;

        public CityController(ICityRepository iCityRepository)
        {
            _iCityRepository = iCityRepository;
        }

        [HttpGet("SelectCity")]
        public async Task<ActionResult> City()
        {
            _iCityRepository.SetRequest(Request);
            var response = await _iCityRepository.City();

            if (response.Success)
                return Ok(response);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, response.Message);
        }

        //my test code
        [HttpGet("GetTestDetails")]
        public ActionResult<string> Get()
        {
            return "Testing 1";
        }
        //----------------------

        [HttpGet("SelectCityByID")]
        public async Task<ActionResult> SelectCityByID(int id)
        {
            _iCityRepository.SetRequest(Request);
            var response = await _iCityRepository.SelectCityByID(id);

            if (response.Success)
                return Ok(response);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, response.Message);
        }


        [HttpPost("InsertCity")]
        public async Task<ActionResult> InsertCity(CityRequest cityOrder)
        {
            _iCityRepository.SetRequest(Request);
            var response = await _iCityRepository.InsertCity(cityOrder);
            if (response.Success)
                return Ok(response);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, response.Message);

        }

        [HttpPost("UpdateCity")]
        public async Task<ActionResult> UpdateCity(CityRequest cityOrder)
        {
            _iCityRepository.SetRequest(Request);
            var response = await _iCityRepository.UpdateCity(cityOrder);
            if (response.Success)
                return Ok(response);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, response.Message);

        }

        [HttpDelete("DeleteCity")]
        public async Task<ActionResult> DeleteCity(int id)
        {
            _iCityRepository.SetRequest(Request);
            var response = await _iCityRepository.DeleteCity(id);
            if (response.Success)
                return Ok(response);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, response.Message);

        }

        //GET api/values
        [HttpGet("City1")]
        public ActionResult<IEnumerable<string>> City1()
        {
            return new string[] { "Kandy" };
        }

        // POST api/values
        [HttpPost("InsertCity1")]
        public void InsertCity([FromBody] string value)
        {
        }
    }
}