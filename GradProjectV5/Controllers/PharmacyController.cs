using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GradProjectV5.Models;
using Microsoft.AspNet.Identity;

namespace GradProjectV5.Controllers
{
    [Authorize]
    public class PharmacyController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public dynamic Create(Pharamacy p)
        {
            if (ModelState.IsValid)
            {
                MyProjectDBEntities db = new MyProjectDBEntities();
                var userid = User.Identity.GetUserId();
                var member = db.Members.FirstOrDefault(x => x.UserId == userid);
                Pharamacy pharamacy = new Pharamacy();
                pharamacy.IsDeleted = false;
                pharamacy.PharmacyAddress = p.PharmacyAddress;
                pharamacy.PharmacyName = p.PharmacyName;
                pharamacy.PharmacyPhone = p.PharmacyPhone;
                if (member != null)
                    pharamacy.PharmacyOwnerId = member.ID;

                db.Pharamacies.Add(pharamacy);
                db.SaveChanges();
                return RedirectToAction("Index");


            }


            return View(p);




        }

        [HttpGet]
       
        public dynamic Index()
        {
            return View();
        }

        [HttpPost]
        public dynamic GetMyPharmacies()
        {

            MyProjectDBEntities db = new MyProjectDBEntities();
            
            var userid = User.Identity.GetUserId();
            var member = db.Members.FirstOrDefault(x => x.UserId == userid && x.IsDeleted == false);
           var tmp = db.Pharamacies.Where(x => x.IsDeleted == false && 
                                               x.PharmacyOwnerId == member.ID ).Select(x =>new{
                PharmacyAddress= x.PharmacyAddress == null ?"":x.PharmacyAddress,
                PharmacyName= x.PharmacyName == null ?"":x.PharmacyName,
                PharmacyPhone= x.PharmacyPhone == null ?"":x.PharmacyPhone,
                FullName= x.PharmacyOwnerId == null ?"":x.Member.FullName,
                x.ID
            }).ToList();
            
            return Json(tmp , JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public dynamic RequestMedicine()
        {
            return View();
        }


        
        [HttpPost]
        public dynamic RequestMedicine(PharmacyMedicineRequest pmr)
        {
            if (ModelState.IsValid)
            {
                MyProjectDBEntities db = new MyProjectDBEntities();
                PharmacyMedicineRequest pharmacyMedicineRequest = new PharmacyMedicineRequest();
                pharmacyMedicineRequest.IsDeleted = false;
                pharmacyMedicineRequest.Amount = pmr.Amount;
                pharmacyMedicineRequest.MedicineId = pmr.MedicineId;
                pharmacyMedicineRequest.RequestPharamcyId = pmr.RequestPharamcyId;
                pharmacyMedicineRequest.RequestDate = DateTime.Now;
                pharmacyMedicineRequest.LatestRequestStatusId = 1;
                db.PharmacyMedicineRequests.Add(pharmacyMedicineRequest);
                db.SaveChanges();
                PhMedicineRequestStatu  requeststatus= new PhMedicineRequestStatu();
                requeststatus.PhMedicineRequestId = pharmacyMedicineRequest.ID;
                requeststatus.StatusId = 1;
                requeststatus.StatusDate = DateTime.Now;
                db.PhMedicineRequestStatus.Add(requeststatus);
                db.SaveChanges();

            }

            return View(pmr);
        }

        [HttpGet]
        public dynamic GetPhRequestedMedicine()
        {
            MyProjectDBEntities db = new MyProjectDBEntities();
            var userid = User.Identity.GetUserId();
            var member = db.Members.FirstOrDefault(x => x.UserId ==userid );
            var tmp = db.PharmacyMedicineRequests.Where(x => x.IsDeleted == false &&
                                                             x.Pharamacy.PharmacyOwnerId == member.ID).Select(x => new
            {
                x.ID,
                RequestPharmacy = x.RequestPharamcyId == null ? "":x.Pharamacy.PharmacyName,
                MedicineName = x.MedicineId == null ?"":x.Medicine.MedicineName,
                Amount= x.Amount == null ?"":x.Amount,
                requestday =x.RequestDate == null ?0: x.RequestDate.Value.Day,
                requestmonth = x.RequestDate == null ?0:x.RequestDate.Value.Month,
                requestyear = x.RequestDate == null ?0:x.RequestDate.Value.Year,
                StatusName = x.LatestRequestStatusId == null ?"":x.Status.StatusName,
                RespondPharmacy =x.RespondPharamacyId == null ? "": x.Pharamacy1.PharmacyName,
                respondday =x.RespondDate == null ? 0:x.RespondDate.Value.Day,
                respondmonth = x.RespondDate == null ? 0:x.RespondDate.Value.Month,
                respondyear = x.RespondDate == null ? 0:x.RespondDate.Value.Year,
            }).ToList();
            return Json(tmp, JsonRequestBehavior.AllowGet);


        }

    }
}