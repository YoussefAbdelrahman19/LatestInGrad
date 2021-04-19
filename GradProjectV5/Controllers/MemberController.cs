using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GradProjectV5.Models;

namespace GradProjectV5.Controllers
{
    public class MEMBERController : Controller
    {
        private MyProjectDBEntities db = new MyProjectDBEntities();

        [HttpGet]
        //[Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllGovernrates()
        {
            var tmp =  db.Governartes.Select(x =>new
            {
                x.ID,
                x.GovernarteName
            }).ToList();
         
            return Json(tmp , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetGovCities(int governmentid)
        {
            var tmp = db.Cities.Where(x => x.GovernerateId == governmentid).Select(x => new
            {
                x.ID,
                x.CityName,
                x.Governarte.GovernarteName

            }).ToList();

            return Json(tmp, JsonRequestBehavior.AllowGet);
        }

        // GET: /Member/Edit/5
        [HttpPost]
        public ActionResult SaveMember(
            string name , 
            string phone,
            string nationalid,
            string address , 
            string email , 
            int jid
            

            )
        {
            Member m = new Member();
            
            
          
            m.FullName = name;
            m.Address = address;
            m.Email = email;
            m.PhoneNo = phone;
            m.CityId = jid;
            m.NationalId = nationalid;
            m.IsDeleted = false;
            if (Session["memberid"] == null)
            {
                db.Members.Add(m);
                db.SaveChanges();

            }
            else
            {
                int id = Convert.ToInt32(Session["memberid"].ToString());
                var oldvalues = db.Members.Find(id);
                m.ID = oldvalues.ID;
                db.Entry(oldvalues).CurrentValues.SetValues(m);
                db.SaveChanges();
                Session.Remove("memberid");
            }



            return Json("data saved", JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult LoadMembersNoUserName()
        {
            var tmp = db.Members.Where(x => x.IsDeleted == false && x.AspNetUser == null).Select(x => new
            {
                x.ID,
                FullName = x.FullName == null ? "" : x.FullName,
              


            }).ToList();

            return Json(tmp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult LoadAllMembers()
        {
            var tmp = db.Members.Where(x => x.IsDeleted == false).Select(x => new
            {
                x.ID,
                x.NationalId,
                Address = x.Address == null ? "" : x.Address,
                Email = x.Email == null ? "" : x.Email,
                PhoneNo = x.PhoneNo == null ? "" : x.PhoneNo,
                FullName = x.FullName == null ? "" : x.FullName,
                CityName = x.CityId == null ? "" : x.City.CityName,
                GovernarteName = x.City.GovernerateId == null ? "" : x.City.Governarte.GovernarteName,
            

               
            }).ToList();

            return Json(tmp, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult LoadMemberForEdit(int memberid)
        {
            Session["memberid"] = memberid;
            var tmp = db.Members.Where(x => x.ID == memberid).Select(x => new
            {
                x.ID,
                x.NationalId,
                Address = x.Address == null ? "" : x.Address,
                Email = x.Email == null ? "" : x.Email,
                PhoneNo = x.PhoneNo == null ? "" : x.PhoneNo,
                FullName = x.FullName == null ? "" : x.FullName,
                CityID = x.CityId == null ?0 : x.CityId,
                governmentid = x.CityId == null ? 0 : x.City.GovernerateId



            }).ToList();

            return Json(tmp, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public ActionResult DeleteMember(int memberid)
        {
            var tmp = db.Members.Find(memberid);
            tmp.IsDeleted = true;
            db.SaveChanges();
            return Json("deleted successfully", JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
