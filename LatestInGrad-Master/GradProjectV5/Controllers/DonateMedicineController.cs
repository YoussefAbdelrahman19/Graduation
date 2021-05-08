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
    public class DonateMedicineController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public dynamic Create(BeneficierMedicineRequest b)
        {
            if (ModelState.IsValid)
            {
                MyProjectDBEntities db = new MyProjectDBEntities();
                var userid = User.Identity.GetUserId();
                var member = db.Members.FirstOrDefault(x => x.UserId == userid);
                BeneficierMedicineRequest beneficierMedicineRequest = new BeneficierMedicineRequest();
                beneficierMedicineRequest.RequestedAmount = b.RequestedAmount;
                beneficierMedicineRequest.LatestStatusId = 1;
                beneficierMedicineRequest.IsDeleted = false;
                beneficierMedicineRequest.BeneficierId = member.ID;
                beneficierMedicineRequest.MedicineId = b.MedicineId;
                beneficierMedicineRequest.RequestDate = DateTime.Now;
                db.BeneficierMedicineRequests.Add(beneficierMedicineRequest);
                db.SaveChanges();
                BMedicineRequestStatu bMedicineRequestStatu = new BMedicineRequestStatu();
                bMedicineRequestStatu.BRequestId = beneficierMedicineRequest.ID;
                bMedicineRequestStatu.StatusId = 1;
                bMedicineRequestStatu.Date = DateTime.Now;
                db.BMedicineRequestStatus.Add(bMedicineRequestStatu);
                db.SaveChanges();
                return true;


            }


            return View(b);
        }


        [HttpGet]
        public dynamic LoadRequestsToDonate()
        {
            return View();
        }



        
        [HttpPost]
        public dynamic LoadRequestsDataToDonate()
        {
            MyProjectDBEntities db = new MyProjectDBEntities();
            var userid = User.Identity.GetUserId();
            var member = db.Members.FirstOrDefault(x => x.UserId == userid);
            var tmp = db.BeneficierMedicineRequests.Where(x => x.IsDeleted == false && 
                                                               x.DonatorId != member.ID).Select(x => new
            {
                x.ID,
                BenificierFullName= x.BeneficierId == null ?"":x.Member1.FullName,
                MedicineName = x.MedicineId == null ?"": x.Medicine.MedicineName,
                Rday = x.RequestDate == null ?0: x.RequestDate.Value.Day,
                Rmonth = x.RequestDate == null ?0: x.RequestDate.Value.Month,
                Ryear = x.RequestDate == null ?0: x.RequestDate.Value.Year,
                StatusName = x.LatestStatusId == null ?"": x.Status.StatusName,
                RequestedAmount = x.RequestedAmount == null ?"": x.RequestedAmount,
               

            }).ToList();

            return Json(tmp, JsonRequestBehavior.AllowGet);

        }
    }



}