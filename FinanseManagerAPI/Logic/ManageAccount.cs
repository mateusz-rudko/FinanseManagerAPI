using AutoMapper;
using FinanseManagerAPI.Data;
using FinanseManagerAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Claims;

namespace FinanseManagerAPI.Logic
{
    public class ManageAccount
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _user;
        
        public ManageAccount(AppDbContext db, IMapper mapper, UserManager<IdentityUser> user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }
        
        //public async Task<User> GetSomething()
        //{
        //    var user = await _user.GetUserAsync(ClaimsPrincipal.Current);
            
        //}
    }
}
