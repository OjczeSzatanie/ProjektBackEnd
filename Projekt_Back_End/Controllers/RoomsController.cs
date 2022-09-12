using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_Back_End.Models.Domain;
using Projekt_Back_End.Repositories;

namespace Projekt_Back_End.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : Controller
    {
        private readonly IScreeningRoomRepo roomRepo;
        private readonly IMapper mapper;


        public RoomsController(IScreeningRoomRepo roomRepo, IMapper mapper)
        {
            this.roomRepo = roomRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]

        public async Task<IActionResult> GetAllRoomsAsync()
        {
            var rooms = await roomRepo.GetAllAsync();

            var roomsDTO = mapper.Map<List<Models.DTO.Screening_Room>>(rooms);
            return Ok(roomsDTO);
        }

       
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRoomAsync")]
        [Authorize(Roles = "reader")]

        public async Task<IActionResult> GetRoomAsync(Guid id)
        {
            var room = await roomRepo.GetAsync(id);

            if (room == null)
            {
                return NotFound();
            }
            var roomDTO = mapper.Map<Models.DTO.Screening_Room>(room);
            return Ok(roomDTO);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> AddRoomAsync(Models.DTO.AddRoomRequest addRoomRequest)
        {
            var room = new Models.Domain.Screening_Room()
            {
                Name = addRoomRequest.Name,
                Num_Of_Seats = addRoomRequest.Num_Of_Seats
            };
            room = await roomRepo.AddAsync(room);

            var roomDTO = new Models.DTO.Screening_Room()
            {
                Id = room.Id,
                Name = room.Name,
                Num_Of_Seats = room.Num_Of_Seats
            };

            return CreatedAtAction(nameof(GetRoomAsync), new { id = roomDTO.Id }, roomDTO);

        }
        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]


        public async Task<IActionResult> DeleteRoomAsync(Guid id)
        {
            var room = await roomRepo.DeleteAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            var roomDTO = new Models.DTO.Screening_Room
            {
                Id = room.Id,
                Name = room.Name,
                Num_Of_Seats = room.Num_Of_Seats
            };

            return Ok(roomDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> UpdateRoomAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateRoomRequest updateRoomRequest)
        {
            var room = new Models.Domain.Screening_Room()
            {
                Name = updateRoomRequest.Name,
                Num_Of_Seats = updateRoomRequest.Num_Of_Seats

            };

            room = await roomRepo.UpdateAsync(id, room);

            if (room == null)
            {
                return NotFound();
            }

            var roomDTO = new Models.DTO.Screening_Room()
            {
                Name = room.Name,
               Num_Of_Seats = room.Num_Of_Seats

            };

            return Ok(roomDTO);
            
        } }
}
