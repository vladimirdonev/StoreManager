using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreManager.Services.Schudele;
using StoreManager.ViewModels.Schudele;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManager.Controllers
{
    public class SchedulesController : Controller   
    {
        private readonly IScheduleService service;

        public SchedulesController(IScheduleService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Schedule(int Id)
        {
            var employees = this.service.AllEmployees(Id);
            this.ViewBag.StoreId = Id;
            return this.View(employees);
        }

        [HttpGet]
        public IActionResult CreateSchedule(int Id)
        {
            this.ViewBag.StoreId = Id;
            var Employees = this.service.GetCreate(Id);            
            return this.View(Employees);
        }

        [HttpPost]
        public IActionResult CreateSchedule(CreateScheduleViewModel create, [FromForm] string UsersTemplate,int Id)
        {
            this.ViewBag.StoreId = Id;
            var UserId = UsersTemplate.Split(", ");
            if (!ModelState.IsValid)
            {
                
            }
            else
            {
                if(create.StartDate < DateTime.Today)
                {
                    ModelState.AddModelError("StartDate", "StartDate Must be Bigger Than The CurrenDate");
                }
                else if(create.EndDate < create.StartDate)
                {
                    ModelState.AddModelError("EndDate", "EndDate Must be Bigger Than The StartDate");
                }
                else if (string.IsNullOrEmpty(UsersTemplate))
                {
                    ModelState.AddModelError("UsersTemplate", "Please Select Employee");
                }
                else if (this.service.ISShiftAvailable(create.StartDate,create.EndDate))
                {
                    ModelState.AddModelError("StartDate", "This Shift Is Already Occupied");
                }
                else if (this.service.IsEmployeeInShift(UserId[0].Remove(0,1)) != null)
                {
                    return this.RedirectToAction("Edit", new { Id = this.service.IsEmployeeInShift(UserId[0].Remove(0, 1)) });
                }
                else
                {
                    this.service.CreateSchedule(create, UsersTemplate);
                    return this.RedirectToAction("Schedule", new { Id = Id });
                }
                create = this.service.GetCreate(Id);
            }
                return this.View(create);

        }

        [HttpGet]
        public IActionResult Edit(int id, int StoreId)
        {
            this.ViewBag.StoreId = StoreId;
            var model = this.service.FindById(id);
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditScheduleViewModel model, int StoreId)
        {
            this.ViewBag.StoreId = StoreId;
            if (!ModelState.IsValid)
            {
            }
            else if (model.StartDate < DateTime.Today)
            {
                ModelState.AddModelError("StartDate", "StartDate Must be Bigger Than The CurrenDate");
            }
            else if (model.EndDate < model.StartDate)
            {
                ModelState.AddModelError("EndDate", "EndDate Must be Bigger Than The StartDate");
            }
            else if (this.service.ISShiftAvailable(model.StartDate, model.EndDate))
            {
                ModelState.AddModelError("StartDate", "This Shift Is Already Occupied");
            }
            else
            {
                this.service.Update(model);
                return this.RedirectToAction("Schedule", new { Id = StoreId });
            }

            return this.View(model);
        }
    }
}
