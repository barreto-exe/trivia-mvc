using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trivia_mvc.DataAccess.Interfaces;
using trivia_mvc.Models;

namespace trivia_mvc.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        public async Task<IActionResult> Index()
        {
            var users = await userRepository.Get();
            return View(users);
        }

        public async Task<ActionResult> Details(int id)
        {
            var user = await userRepository.GetById(id);
            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(IFormCollection collection)
        {
            try
            {
                var newUser = new User()
                {
                    Username = collection["Username"],
                    DateBirth = Convert.ToDateTime(collection["DateBirth"]),
                    DateIn = DateTime.Now,
                };

                await userRepository.Add(newUser);

                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                //return View();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id)
        {
            var user = await userRepository.GetById(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                var user = new User()
                {
                    IdUser = id,
                    Username = collection["Username"],
                    DateBirth = Convert.ToDateTime(collection["DateBirth"]),
                };

                await userRepository.Edit(user);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            await userRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
