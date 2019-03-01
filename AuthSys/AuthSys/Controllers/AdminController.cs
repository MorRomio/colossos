﻿using AuthSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthSys.ViewModels;

namespace AuthSys.Controllers
{
    public class AdminController : Controller
    {        
        [HttpGet]
        public ActionResult AddAdmin()
        {
            DataAccessLayer.ColossosContext col = new DataAccessLayer.ColossosContext();

            List<Roles> list = new List<Roles>(col.Roles.ToList());
            AdminViewModel viewMod = new AdminViewModel();                         

            //viewMod.Roles = new SelectList(list);

            viewMod.Roles = col.Roles.ToList().Select(x => new SelectListItem()
            {
                 Value = x.RoleName,
                 Text = x.RoleDescription
            }).ToList();
            
            return View(viewMod);
        }

        [HttpPost]
        public ActionResult AddAdmin(AdminViewModel model)
        {
            //var selectedVal = new SelectList(model.Roles);

            if(ModelState.IsValid) 
            {
                var admin = new Admin()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MemberEmail = model.MemberEmail
                   // RoleName = selectedVal.DataTextField
                };

                return View(admin);
            }

            return null;
        }

        [HttpGet]
        public ActionResult EditAdmin(EditMemberViewModel model)
        {
            Admin admin = new Admin();
           

            return View(admin);
        }

        [HttpGet]
        public ActionResult DeleteAdmin(int? MemberID)
        {
            

            return View();
        }
    }
}