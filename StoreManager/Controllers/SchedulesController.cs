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
                else
                {
                    this.service.CreateSchedule(create, UsersTemplate);
                }
                create = this.service.GetCreate(Id);
                return this.View(create);
            }
            return null;
        }
    }
}
