using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JWT_Api.Models;
using JWT_Api.Interface;

namespace JWT_Api.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository _userRepository;
        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public class JDto
        {
            public int id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string username { get; set; }
            public object password { get; set; }
            public object token { get; set; }
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromBody]List<JDto> jDto)
        {
            Console.WriteLine(jDto);

            for (int i = 0; i < jDto.Count; i++)
            {
                User user = new User()
                {
                    UserId = jDto[i].id,
                    firstName = jDto[i].firstName,
                    lastName = jDto[i].lastName,
                    username = jDto[i].username
                };

                var result= _userRepository.Get(user.UserId);
                if (result == null)
                {
                    _userRepository.Add(user);
                }                

            }
            return View();
        }

    }
}
