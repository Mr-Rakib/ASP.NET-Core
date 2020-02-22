using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RCTC.BLL;
using RCTC.BLL.Services;
using RCTC.Models;

namespace RCTC.Controllers
{
    public class ProgramController : Controller
    {

        private ProgramService programService = new ProgramService();

        // GET: Program
        public IActionResult Index(string search)
        {
            List<Programs> AllPrograms = new List<Programs>();
            AllPrograms = (search == null) ? programService.FindAll() : programService.SearchAll(search);
            return View(AllPrograms);
        }

        // GET: Program/Details/5
        public IActionResult Details(int id)
        {
            return View(programService.FindByID(id));
        }

        // GET: Program/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Program/Create
        [HttpPost]

        public IActionResult Create(Programs program)
        {
            if (ModelState.IsValid)
            {
                programService.Save(program);
                return RedirectToAction("Index");
            }
            else return View();
        }

        // GET: Program/Edit/5
        public IActionResult Edit(int id)
        {
            return View(programService.FindByID(id));
        }

        // POST: Program/Edit/5
        [HttpPost]
        public IActionResult Edit(Programs program)
        {
            return (programService.UpdateByID(program)) ? 
                RedirectToAction("Index") : 
                (IActionResult) View();
        }

        // GET: Program/Delete/5
        public IActionResult Delete(int id)
        {
            return (programService.DeteteByID(id)) ? RedirectToAction("Index") : (IActionResult)View();
        }
    }
}