using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trivia_mvc.DataContexts;
using trivia_mvc.Models;

namespace trivia_mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly TriviaContext triviaContext;
        public UserController(TriviaContext triviaContext)
        {
            this.triviaContext = triviaContext;
        }


        // GET: UserController
        public async Task<IActionResult> Index()
        {
            var users = triviaContext.Users.ToList();
            return View(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var user = triviaContext.Users.SingleOrDefault(u => u.IdUser == id);

            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                var newUser = new User()
                {
                    Username = collection["Username"],
                    DateBirth = Convert.ToDateTime(collection["DateBirth"]),
                    DateIn = DateTime.Now,
                };

                triviaContext.Users.Add(newUser);
                await triviaContext.SaveChangesAsync();

                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                //return View();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
