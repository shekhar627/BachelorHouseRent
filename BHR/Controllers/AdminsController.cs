using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BHR.ViewModels;

namespace BHR.Controllers
{
    public class AdminsController : Controller
    {

        private BhrContext _Context;

        public AdminsController()
        {

            _Context = new BhrContext();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }
        // GET: Admins
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult PendingAdd()
        {
            var pendingAdd = _Context.ConfirmPayments.Where(cp => cp.IsCheckedByAdmin == false).ToList();
            return View(pendingAdd);
        }

        public ActionResult FinishAdd(int id)
        {
            var conPay = _Context.ConfirmPayments.SingleOrDefault(cp => cp.Id == id);
            conPay.IsCheckedByAdmin = true;
            _Context.SaveChanges();

            var advertise = _Context.Advertisements.SingleOrDefault(a => a.Key == conPay.AddKey);
            advertise.IsPaid = true;
            _Context.SaveChanges();

            return RedirectToAction("PendingAdd");
        }

        public ActionResult PendingUser()
        {
            var pendingUser = _Context.Users.Where(u => u.IsValid == false || u.IsValid == null).ToList();
            return View(pendingUser);

        }

        public ActionResult ViewUser(int id)
        {

            var singleManager = _Context.Users.Find(id);
            var houseKeyUser =
                _Context.UserHouses.SingleOrDefault(uh => uh.UserId == singleManager.UserId && uh.IsActive == true);
            var UserDetails = new UserDetailsViewModel()
            {
                User = singleManager,
                UserImage = _Context.UserImages.SingleOrDefault(ui => ui.UserId == id),
                Document = _Context.Documents.SingleOrDefault(ud => ud.UserId == id),
              

            };
            return View(UserDetails);
        }

        public ActionResult Clearing(int id)
        {
            var pendingUser = _Context.Users.SingleOrDefault(u => u.Id == id);
            pendingUser.IsValid = true;
            _Context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}