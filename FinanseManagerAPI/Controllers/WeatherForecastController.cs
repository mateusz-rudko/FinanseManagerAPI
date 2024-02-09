using AutoMapper;
using FinanseManagerAPI.Data;
using FinanseManagerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinanseManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _user;
        
        public WeatherForecastController(AppDbContext db, IMapper mapper, UserManager<IdentityUser> user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }
        
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var userName = _user.GetUserId(User);
            return Ok(userName);
        }
    }
}
