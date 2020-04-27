using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingApplication.Dtos;
using DatingApplication.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace DatingApplication.Controllers
{
    // [Route("api/controller]")]
    // [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        //[HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var userForList = _mapper.Map<IEnumerable<UserFroListDto>>(users);
            return Ok(userForList);
        }

        //[HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);
            var userForDetails = _mapper.Map<UserForDetailsDto>(user);
            return Ok(userForDetails);
        }
    }
}