using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BHR.Models;
using BHR.ViewModels;
using System.Data.Entity;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BHR.Controllers
{
    public class ManagersController : Controller
    {
        private BhrContext _Context;

        public ManagersController()
        {

            _Context = new BhrContext();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }

        // GET: Managers
        public ActionResult CheckingNManager()
        {
            if (Session["user_id"] != null)
            {
                //  var user_id = (int)Session["user_id"];
                var dummyUserId = new UserLoginViewModel()
                {
                    UserId = "dummy text"
                };

                return View(dummyUserId);
            }
            return RedirectToAction("LogInUser", "Users");
        }

        [HttpPost]
        public ActionResult CheckUser(UserLoginViewModel user)
        {
            if (Session["user_id"] != null)
            {
                if (!ModelState.IsValid)
                {
                    return View("CheckingNManager");
                }
                var user_id = (int) Session["user_id"];
                byte[] bytes = Encoding.Unicode.GetBytes(user.Password);
                byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
                user.Password = Convert.ToBase64String(inArray);
                var exUser = _Context.Users.SingleOrDefault(u => u.Id == user_id && u.Password == user.Password);
                if (exUser == null)
                {
                    ModelState.AddModelError("Password", "Password is not correct");
                    return View("CheckingNManager");
                }
                Session["check_pass"] = "ok";
                return RedirectToAction("CreateManager", "Managers");

            }
            return RedirectToAction("LogInUser", "Users");
        }

        public ActionResult CreateManager()
        {
            if (Session["user_id"] != null)
            {
                if (Session["check_pass"] == null)
                {
                    return RedirectToAction("CheckingNManager");
                }

                var houserManager = new ManagerHouse()
                {
                    User_Id = (int) Session["user_id"]
                };
                return View(houserManager);
            }
            return RedirectToAction("LogInUser", "Users");
        }

        [HttpPost]
        public ActionResult StoreManager(ManagerHouse mh)
        {
            if (Session["user_id"] != null)
            {
                if (Session["check_pass"] == null)
                {
                    return RedirectToAction("CheckingNManager");
                }
                if (!ModelState.IsValid)
                {
                    return View("CreateManager", mh);
                }
                var keyChecking = _Context.HouseKeys.SingleOrDefault(hk => hk.Key == mh.Key);
                if (keyChecking == null)
                {
                    ModelState.AddModelError("Key", "Invalid Key. Please Try Another.");
                    return View("CreateManager", mh);
                }
                var checkExistingManage =
                    _Context.ManagerHouses.SingleOrDefault(m => m.Key == m.Key && m.IsActive == true);
                if (checkExistingManage != null)
                {
                    ModelState.AddModelError("Key", "Already have a manager.");
                    return View("CreateManager", mh);
                }
                mh.IsActive = true;
                _Context.ManagerHouses.Add(mh);
                _Context.SaveChanges();

                var existingUser = _Context.Users.Find((int) Session["user_id"]);

                existingUser.IsAManager = true;
                _Context.SaveChanges();

                var user_id = (int) Session["user_id"];
                var user = _Context.Users.Find(user_id);
                UserHouse uh = new UserHouse();
                uh.UserId = user.UserId;
                uh.IsActive = true;
                uh.HouseKeyId = keyChecking.Id;

                _Context.UserHouses.Add(uh);
                _Context.SaveChanges();

                return RedirectToAction("Index", "Users");
            }
            return RedirectToAction("LogInUser", "Users");


        }

        public ActionResult CheckExperience()
        {
            var user_id = (int) Session["user_id"];
            List<House> houses = new List<House>();
            var managers = _Context.ManagerHouses.Where(mh => mh.User_Id == user_id).ToList();

            foreach (var x in managers)
            {
                var houseKey = _Context.HouseKeys.SingleOrDefault(hk => hk.Key == x.Key);
                houses.Add(_Context.Houses.SingleOrDefault(h => h.Id == houseKey.HouseId));

            }

            var checkExperiance = new CheckExperianceViewModel()
            {
                Houses = houses,
                ManagerHouses = managers
            };

            return View(checkExperiance);

        }

        public ActionResult CheckMembers()
        {
            List<User> Users = new List<User>();
            var user_id = (int) Session["user_id"];
            var managerHouse =
                _Context.ManagerHouses.SingleOrDefault(mh => mh.User_Id == user_id && mh.IsActive == true);
            var houseKey = _Context.HouseKeys.SingleOrDefault(hk => hk.Key == managerHouse.Key);
            var userHouses = _Context.UserHouses.Where(uh => uh.HouseKeyId == houseKey.Id && uh.IsActive == true)
                .ToList();

            foreach (var x in userHouses)
            {
                Users.Add(_Context.Users.SingleOrDefault(u => u.UserId == x.UserId));
            }
            var membersList = new MembersListViewModel()
            {
                User = Users
            };
            return View(membersList);
        }

        public ActionResult MemberRemove(string userId)
        {
            var memberOfHouse = _Context.UserHouses.SingleOrDefault(uh => uh.UserId == userId && uh.IsActive == true);

            memberOfHouse.IsActive = false;
            _Context.SaveChanges();
            return RedirectToAction("CheckMembers");
        }

        public ActionResult SingleUser(string user_id)
        {
            var singleManager = _Context.Users.SingleOrDefault(u => u.UserId == user_id);
            var houseKeyUser =
                _Context.UserHouses.SingleOrDefault(uh => uh.UserId == singleManager.UserId && uh.IsActive == true);
            var houseKey = _Context.HouseKeys.SingleOrDefault(hk => hk.Id == houseKeyUser.HouseKeyId);
            var UserDetails = new UserDetailsViewModel()
            {
                User = singleManager,
                UserImage = _Context.UserImages.SingleOrDefault(ui => ui.UserId == singleManager.Id),
                Document = _Context.Documents.SingleOrDefault(ud => ud.UserId == singleManager.Id),
                HouseKey = houseKey.Key

            };
            return View(UserDetails);
        }

        public ActionResult ReplaceManager()
        {
            return View();
        }

        public ActionResult CheckingManager(UserLoginViewModel user)
        {

            if (Session["user_id"] != null)
            {
                if (!ModelState.IsValid)
                {
                    return View("ReplaceManager");
                }
                byte[] bytes = Encoding.Unicode.GetBytes(user.Password);
                byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
                user.Password = Convert.ToBase64String(inArray);

                var exUser =
                    _Context.Users.SingleOrDefault(u => u.UserId == user.UserId && u.Password == user.Password);
                var existingManager =
                    _Context.ManagerHouses.SingleOrDefault(mh => mh.User_Id == exUser.Id && mh.IsActive == true);
                if (exUser == null)
                {
                    ModelState.AddModelError("Password", "User Id or Password is not correct");
                    return View("ReplaceManager");
                }
                if (existingManager == null)
                {
                    ModelState.AddModelError("Password", "User is not a manager.");
                    return View("ReplaceManager");
                }

                Session["check_pass1"] = "ok";
                Session["temporary_key"] = existingManager.Key;
                return RedirectToAction("CreateNewManager", "Managers");

            }
            return RedirectToAction("LogInUser", "Users");
        }

        public ActionResult CreateNewManager()
        {
            if (Session["user_id"] != null)
            {
                if (Session["check_pass1"] == null)
                {
                    return RedirectToAction("ReplaceManager");
                }

                return View();
            }
            return RedirectToAction("LogInUser", "Users");
        }

        public ActionResult StoreNewManager(NewManagerWithExistingManagerViewModel nmwem)
        {
            if (Session["user_id"] != null)
            {
                if (Session["check_pass1"] == null)
                {
                    return RedirectToAction("ReplaceManager");
                }
                if (!ModelState.IsValid)
                {
                    return View("CreateNewManager", nmwem);
                }
                string key = (string) Session["temporary_key"];
                var existingManager =
                    _Context.ManagerHouses.SingleOrDefault(
                        mh => mh.IsActive == true && mh.Key == nmwem.ManagerHouse.Key);
                if (key != nmwem.ManagerHouse.Key)
                {
                    ModelState.AddModelError("UserHouse.Key", "Key is not valid");
                    return View("CreateNewManager", nmwem);
                }
                existingManager.IsActive = false;
                _Context.SaveChanges();

                var newManager = _Context.Users.SingleOrDefault(u => u.UserId == nmwem.UserId && u.IsValid == true);
                if (newManager == null)
                {
                    ModelState.AddModelError("UserId", "User is not valid. Please try valid user.");
                    return View("CreateNewManager", nmwem);
                }
                ManagerHouse newManagerHouse = new ManagerHouse();
                newManagerHouse.User_Id = newManager.Id;
                newManagerHouse.IsActive = true;
                newManagerHouse.Key = nmwem.ManagerHouse.Key;
                _Context.ManagerHouses.Add(newManagerHouse);
                _Context.SaveChanges();


                var HouseKey = _Context.HouseKeys.SingleOrDefault(hk => hk.Key == key);


                var user = _Context.Users.Find(newManager.Id);
                user.IsAManager = true;
                _Context.SaveChanges();
                var checkingUser =
                    _Context.UserHouses.SingleOrDefault(
                        userHouse => userHouse.UserId == user.UserId && userHouse.IsActive == true);
                if (checkingUser == null)
                {
                    UserHouse uh = new UserHouse();
                    uh.UserId = user.UserId;
                    uh.IsActive = true;
                    uh.HouseKeyId = HouseKey.Id;

                    _Context.UserHouses.Add(uh);
                    _Context.SaveChanges();
                }

                Session["temporary_key"] = null;
                return RedirectToAction("Index", "Users");

            }
            return RedirectToAction("LogInUser", "Users");
        }

        public ActionResult CreateAdd()
        {
            var division = _Context.Divisions.ToList();

            var creatingAdd = new CreateAddViewModel()
            {
                Divisions = division
            };
            return View(creatingAdd);
        }

        public JsonResult GetDistrict(int divisionId)
        {
            var districts = _Context.Districts.Where(d => d.DivisionId == divisionId).OrderBy(d => d.Name);
            return Json(districts);
        }

        public JsonResult GetThana(int districtId)
        {
            var thanas = _Context.Thanas.Where(t => t.DistrictId == districtId).OrderBy(t => t.Name);
            return Json(thanas);
        }

        public ActionResult StoreAdd(CreateAddViewModel cavm,IEnumerable<HttpPostedFileBase> files)
        {
            if (Session["user_id"] != null)
            {
                if (!ModelState.IsValid)
                {
                    cavm.Divisions = _Context.Divisions.ToList();
                    return View("CreateAdd", cavm);
                }
                var user_id = (int) Session["user_id"];
                Advertisement add = new Advertisement();
                add.Description = cavm.Description;
                add.DivisionId = cavm.DivisionId;
                add.DistrictId = cavm.DistrictId;
                add.ThanaId = cavm.ThanaId;
                add.PublishDate = DateTime.Now;
                add.EndDate = cavm.EndDate;
                add.Price = cavm.Price;
                add.UserId = user_id;
                add.Address = cavm.Address;
                add.IsPaid = false;
                add.Key = user_id.ToString() + "_" + DateTime.Now.ToString("MMddyyyyHHmmssfff");

                _Context.Advertisements.Add(add);
                _Context.SaveChanges();

                var lastAdd = _Context.Advertisements.Where(a => a.UserId == user_id).OrderByDescending(a => a.Id)
                    .ToList();
                var last_id = 0;
                foreach (var x in lastAdd)
                {
                    last_id = x.Id;
                    break;
                }
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0 && file.ContentType.Contains("image") &&
                        Path.GetExtension(file.FileName).ToLower() != ".gif")
                    {
                        using (var reader = new BinaryReader(file.InputStream))
                        {
                            var advertisemage=new AdvertiseImage();
                            advertisemage.AdvertisementId = last_id;
                            advertisemage.ContentType = file.ContentType;
                            advertisemage.Contents = reader.ReadBytes(file.ContentLength);

                            _Context.AdvertiseImages.Add(advertisemage);
                            _Context.SaveChanges();
                        }
                    }
                    
                }
                return RedirectToAction("Index", "Users");
            }
            return RedirectToAction("LogInUser", "Users");
        }

        public ActionResult Payments()
        {
            var payMethods = _Context.PaymentMethods.ToList();
            var payView=new PaymentViewModel()
            {
                PaymentMethods = payMethods
            };
            return View(payView);
        }

        public ActionResult AddPay(PaymentViewModel pay)
        {
            var paymentMethod = _Context.PaymentMethods.SingleOrDefault(p => p.Id == pay.PaymentId);
            var agentNumber = "";
            if (paymentMethod.Name == "bKash")
            {
                agentNumber = "01775203399";
            }
            else if (paymentMethod.Name == "Dutch Bangla")
            {
                agentNumber = "017752033990";
            }
            var payView = new StorePaymentViewModel()
            {
                AgentNumber = agentNumber
            };
            return View(payView);
        }

        public ActionResult StorePayment(StorePaymentViewModel sp)
        {
            if (!ModelState.IsValid)
            {
                return View("AddPay", sp);
            }
            var checkAddKey = _Context.Advertisements.SingleOrDefault(a => a.Key == sp.AddKey);
            if (checkAddKey == null)
            {
                ModelState.AddModelError("AddKey","Key is not valid");
                return View("AddPay", sp);
            }
            ConfirmPayment cp=new ConfirmPayment();
            cp.AddKey = sp.AddKey;
            cp.Mobile = sp.Mobile;
            cp.TransactionId = sp.TransactionId;

            _Context.ConfirmPayments.Add(cp);
            _Context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }
    }
}