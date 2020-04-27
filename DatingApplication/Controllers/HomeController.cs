using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatingApplication.Models;
using DatingApplication.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace DatingApplication.Controllers
{
    // [Authorize]
    public class HomeController : Controller
    {
        private readonly DataContext _Context;

        public IAuthRepository _Repo { get; }

        public HomeController(DataContext context, IAuthRepository repo)
        {
            _Context = context;
            _Repo = repo;
        }

        public IActionResult Index()
        {
            var values = _Context.Customers.ToList();
            seed.SeedUserData(_Context);
            return Ok(values);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetAllData()
        {
            var values = await _Context.Users.ToListAsync();
            return Ok(values);
        }

        public async Task<IActionResult> getStudentData(){
            var students = await _Context.Customers.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserData(int id)
        {
            var user = await _Context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(user);
        }
    }
}
