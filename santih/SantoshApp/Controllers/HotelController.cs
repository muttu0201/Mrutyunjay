using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SantoshApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SantoshApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//Httppost,httpget,httpupdate,httpdelete   -verbs

    public class HotelController : ControllerBase
    {
        public IHotelRepository _IHotelRepository { get; set; }

        public HotelController(IHotelRepository hotelRepository)
        {
            _IHotelRepository = hotelRepository;
        }
        [HttpPost]
        public IActionResult Create([FromBody] HotelModel model)
        {
            if (model == null)

                return BadRequest();
            _IHotelRepository.Add(model);
            return new ObjectResult("Success");


        }
        [HttpGet]
        public IActionResult GetHotels()
        {
            IEnumerable<HotelModel> hotelModels = _IHotelRepository.GetAll();
            return Ok(hotelModels);
        }

        [HttpGet("{id}", Name = "GetHotel")]
        public IActionResult GetHotels(int id)
        {
            HotelModel hotelModels = _IHotelRepository.Find(id);
            return Ok(hotelModels);
        }

        [HttpPut("{id}")]
        public IActionResult put(int id, [FromBody] HotelModel employee)
        {
            employee.HotelId = id;
            _IHotelRepository.Update(employee);
            return Ok("Updated");

        }
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            _IHotelRepository.Remove(id);
            return Ok("deleted");



        }

    }
}
