using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_Back_End.Models.Domain;
using Projekt_Back_End.Repositories;

namespace Projekt_Back_End.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeyController : Controller
    {
        private readonly IKeyRepository keyRepository;
        private readonly IMapper mapper;

        public KeyController(IKeyRepository keyRepository, IMapper mapper)
        {
            this.keyRepository = keyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]

        public async Task<IActionResult> GetAllKeysAsync()
        {
            var keys = await keyRepository.GetAllAsync();

            var keysDTO = mapper.Map<List<Models.DTO.Movie_Key>>(keys);
            return Ok(keysDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetKeyAsync")]
        [Authorize(Roles = "reader")]

        public async Task<IActionResult> GetKeyAsync(Guid id)
        {
            var key = await keyRepository.GetAsync(id);

            if (key == null)
            {
                return NotFound();
            }
            var keyDTO = mapper.Map<Models.DTO.Movie_Key>(key);

            return Ok(keyDTO);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> AddKeyAsync(Models.DTO.AddKeyRequest addKeyRequest)
        {
            var key = new Models.Domain.Movie_Key()
            {
                Time_Of_Start = addKeyRequest.Time_Of_Start,
                Time_Of_End = addKeyRequest.Time_Of_End,
                MovieId = addKeyRequest.MovieId
            };

            key = await keyRepository.AddAsync(key);

            var keyDTO = new Models.DTO.Movie_Key()
            {
                Time_Of_Start = key.Time_Of_Start,
                Time_Of_End = key.Time_Of_End,
                MovieId = key.MovieId
            };

            return CreatedAtAction(nameof(GetKeyAsync), new { id = keyDTO.Id }, keyDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> DeleteKeyAsync(Guid id)
        {
            // Get movie from database
            var key = await keyRepository.DeleteAsync(id);

            //if null notfound
            if (key == null)
            {
                return NotFound();
            }

            //Convert response back to DTO

            var keyDTO = new Models.DTO.Movie_Key
            {
                Id = key.Id,
                Time_Of_Start = key.Time_Of_Start,
                Time_Of_End = key.Time_Of_End,
                MovieId = key.MovieId
            };

            //response back to the client
            return Ok(keyDTO);
        }
        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> UpdateKeyAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateKeyRequest updateKeyRequest)
        {
            //Convert dto to domain
            var key = new Models.Domain.Movie_Key()
            {
                Time_Of_Start = updateKeyRequest.Time_Of_Start,
                Time_Of_End = updateKeyRequest.Time_Of_End,
                MovieId = updateKeyRequest.MovieId
            };

            //update movie
            key = await keyRepository.UpdateAsync(id, key);

            // if null not found
            if (key == null)
            {
                return NotFound();
            }

            //convert domain to dto
            var keyDTO = new Models.DTO.Movie_Key()
            {
                Id = key.Id,
                Time_Of_Start = key.Time_Of_Start,
                Time_Of_End = key.Time_Of_End,
                MovieId = key.MovieId
            };
            //return ok
            return Ok(keyDTO);
        }
    }
}
