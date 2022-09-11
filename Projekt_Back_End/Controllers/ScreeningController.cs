using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projekt_Back_End.Models.Domain;
using Projekt_Back_End.Repositories;

namespace Projekt_Back_End.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScreeningController : Controller
    {
        private readonly IScreeningRepo screenRepo;
        private readonly IMapper mapper;


        public ScreeningController(IScreeningRepo screenRepo, IMapper mapper)
        {
            this.screenRepo = screenRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllScreensAsync()
        {
            var screens = await screenRepo.GetAllAsync();

            var screensDTO = mapper.Map<List<Models.DTO.Screening>>(screens);
            return Ok(screensDTO);
        }

        [HttpGet]
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetScreeningsAsync")]
        public async Task<IActionResult> GetScreenAsync(Guid id)
        {
            var screen = await screenRepo.GetAsync(id);

            if (screen == null)
            {
                return NotFound();
            }
            var screenDTO = mapper.Map<Models.DTO.Screening>(screen);
            return Ok(screenDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddScreenAsync(Models.DTO.AddScreeningRequest addScreening)
        {
            var screen = new Models.Domain.Screening()
            {
                Time_Of_Start = addScreening.Time_Of_Start,
                Time_Of_End = addScreening.Time_Of_End,
                MovieId = addScreening.MovieId,
                RoomId = addScreening.RoomId

            };
            screen = await screenRepo.AddAsync(screen);

            var screenDTO = new Models.DTO.Screening()
            {
                Id = screen.Id,
                Time_Of_Start = screen.Time_Of_Start,
                Time_Of_End = screen.Time_Of_End,
                MovieId = screen.MovieId,
                RoomId = screen.RoomId
            };

            return CreatedAtAction(nameof(GetScreenAsync), new { id = screenDTO.Id }, screenDTO);

        }
        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteScreenAsync(Guid id)
        {
            var screen = await screenRepo.DeleteAsync(id);

            if (screen == null)
            {
                return NotFound();
            }

            var screenDTO = new Models.DTO.Screening
            {
                Id = screen.Id,
                Time_Of_Start = screen.Time_Of_Start,
                Time_Of_End = screen.Time_Of_End,
                MovieId = screen.MovieId,
                RoomId = screen.RoomId
            };

            return Ok(screenDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateScreenAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateScreeningRequest updateScreening)
        {
            var screen = new Models.Domain.Screening()
            {
                Time_Of_Start = updateScreening.Time_Of_Start,
                Time_Of_End = updateScreening.Time_Of_End,
                MovieId = updateScreening.MovieId,
                RoomId = updateScreening.RoomId

            };

            screen = await screenRepo.UpdateAsync(id, screen);

            if (screen == null)
            {
                return NotFound();
            }

            var screenD = new Models.DTO.Screening()
            {
                Time_Of_Start = screen.Time_Of_Start,
                Time_Of_End = screen.Time_Of_End,
                MovieId = screen.MovieId,
                RoomId = screen.RoomId

            };

            return Ok(screen);

        }
    }
}

