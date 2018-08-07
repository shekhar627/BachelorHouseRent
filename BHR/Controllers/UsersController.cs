using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BHR.Models;
using BHR.ViewModels;
using System.IO;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;

namespace BHR.Controllers
{
    public class UsersController : Controller
    {
        private BhrContext _Context;

        public UsersController()
        {

            _Context = new BhrContext();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }

        public ActionResult Index()
        {
            if (Session["user_id"] != null)
            {
                var userid = (int) Session["user_id"];
                var singleUser = new UserInfoWithImageViewModel()
                {
                    User = _Context.Users.Include(u => u.Occupation).Single(u => u.Id == userid),
                    UserImage = _Context.UserImages.SingleOrDefault(ui => ui.UserId == userid),
                    Document = _Context.Documents.SingleOrDefault(ud => ud.UserId == userid),
                    ManagerHouse = _Context.ManagerHouses.SingleOrDefault(mh => mh.User_Id == userid)
                };
                return View(singleUser);
            }
            return RedirectToAction("LogInUser", "Users");
        }

        public ActionResult Create()
        {
            var occupations = new NewUserViewModel()
            {
                Occupations = _Context.Occupations.ToList()
            };
            return View(occupations);
        }

        [HttpPost]
        public ActionResult Store(NewUserViewModel newUser)
        {
            if (!ModelState.IsValid)
            {
                var user = new NewUserViewModel()
                {
                    User = newUser.User,
                    Occupations = _Context.Occupations.ToList()

                };
                return View("Create", user);
            }
            var checkingUser = _Context.Users.SingleOrDefault(u => u.UserId == newUser.User.UserId);
            if (checkingUser != null)
            {
                var user = new NewUserViewModel()
                {
                    User = newUser.User,
                    Occupations = _Context.Occupations.ToList()

                };
                ModelState.AddModelError("User.UserId", "User Id is already exists!!! Try another User Id");
                return View("Create", user);
            }

            // hasihing password to protect
            byte[] bytes = Encoding.Unicode.GetBytes(newUser.User.Password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            newUser.User.Password = Convert.ToBase64String(inArray);

            // hasihing confirm password to protect
            byte[] bytes1 = Encoding.Unicode.GetBytes(newUser.User.ConfirmPassword);
            byte[] inArray1 = HashAlgorithm.Create("SHA1").ComputeHash(bytes1);
            newUser.User.ConfirmPassword = Convert.ToBase64String(inArray1);

            _Context.Users.Add(newUser.User);
            _Context.SaveChanges();

            return RedirectToAction("Create");
        }

        public ActionResult UploadImage()
        {
            if (Session["user_id"] != null)
            {
                return View();
            }
            return RedirectToAction("LogInUser", "Users");
        }

        [HttpPost]
        public ActionResult StoreImage(HttpPostedFileBase file)
        {
            if (Session["user_id"] != null)
            {
                if (file != null && file.ContentLength > 0 && file.ContentType.Contains("image") &&
                    Path.GetExtension(file.FileName).ToLower() != ".gif")
                {
                    using (var reader = new BinaryReader(file.InputStream))
                    {
                        var imageForUser = new UserImage()
                        {
                            UserId = (int) Session["user_id"],
                            ImageContent = reader.ReadBytes(file.ContentLength),
                            ContentType = file.ContentType
                        };

                        var newUserImage = _Context.UserImages.SingleOrDefault(ui => ui.UserId == imageForUser.UserId);
                        if (newUserImage == null)
                        {
                            _Context.UserImages.Add(imageForUser);
                            _Context.SaveChanges();
                        }
                        else
                        {
                            var existingUser = _Context.UserImages.SingleOrDefault(ui => ui.Id == newUserImage.Id);
                            existingUser.ImageContent = imageForUser.ImageContent;
                            existingUser.ContentType = imageForUser.ContentType;
                            _Context.SaveChanges();
                        }

                        return RedirectToAction("Index", "Users");
                    }
                }
                return Content("only .jpg, .jpeg, .png are allowed. <a href='/Users/UploadImage'> back to previous.");
            }
            return RedirectToAction("LogInUser", "Users");
        }

        public ActionResult LogInUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckUser(UserLoginViewModel logUser)
        {
            if (!ModelState.IsValid)
            {
                var user = new UserLoginViewModel()
                {
                    UserId = logUser.UserId,
                };
                return View("LogInUser", user);
            }
            var exUser = _Context.Users.SingleOrDefault(u => u.UserId == logUser.UserId);

            if (exUser == null)
            {
                ModelState.AddModelError("Password", "Username or password is incorrect");
                return View("LogInUser", logUser);
            }

            // hasihing password to protect
            byte[] bytes = Encoding.Unicode.GetBytes(logUser.Password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            logUser.Password = Convert.ToBase64String(inArray);

            if (exUser.UserId != null && exUser.Password == logUser.Password)
            {
                Session["user_id"] = exUser.Id;
                return RedirectToAction("Index");
            }
            return RedirectToAction("LogInUser");
        }

        public ActionResult Logout()
        {
            if (Session["user_id"] != null)
            {
                Session["user_id"] = null;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("LogInUser", "Users");
        }

        public ActionResult Update()
        {
            if (Session["user_id"] != null)
            {
                var userId = (int) Session["user_id"];
                var user = _Context.Users.SingleOrDefault(u => u.Id == userId);
                var occupations = new UpdateUserViewModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserId = user.UserId,
                    MobileNumber = user.MobileNumber,
                    Address = user.Address,
                    OccupationId = user.OccupationId,
                    IsAHouseOwner = user.IsAHouseOwner,
                    Occupations = _Context.Occupations.ToList()
                };
                return View("Update", occupations);
            }
            return RedirectToAction("LogInUser", "Users");
        }

        [HttpPost]
        public ActionResult StoreUpdate(UpdateUserViewModel upuvm)
        {
            if (Session["user_id"] != null)
            {
                if (!ModelState.IsValid)
                {
                    var occupations = new UpdateUserViewModel()
                    {
                        FirstName = upuvm.FirstName,
                        LastName = upuvm.LastName,
                        UserId = upuvm.UserId,
                        MobileNumber = upuvm.MobileNumber,
                        Address = upuvm.Address,
                        OccupationId = upuvm.OccupationId,
                        IsAHouseOwner = upuvm.IsAHouseOwner,
                        Occupations = _Context.Occupations.ToList()
                    };
                    return View("Update", occupations);
                }
                var userId = (int) Session["user_id"];
                var singleUser = _Context.Users.Single(u => u.Id == userId);
                singleUser.MobileNumber = upuvm.MobileNumber;
                singleUser.Address = upuvm.Address;
                singleUser.Address = upuvm.Address;
                singleUser.OccupationId = upuvm.OccupationId;
                singleUser.IsAHouseOwner = upuvm.IsAHouseOwner;

                _Context.SaveChanges();

                return RedirectToAction("Index", "Users");
            }
            return RedirectToAction("LogInUser", "Users");
        }

        public ActionResult VerifyAccount()
        {
            if (Session["user_id"] != null)
            {
                return View();
            }
            return RedirectToAction("LogInUser", "Users");
        }

        [HttpPost]
        public ActionResult StoreVerify(HttpPostedFileBase file)
        {
            if (Session["user_id"] != null)
            {
                if (file != null && file.ContentLength > 0 && file.ContentType.Contains("image") &&
                    Path.GetExtension(file.FileName).ToLower() != ".gif")
                {
                    using (var reader = new BinaryReader(file.InputStream))
                    {
                        var documentsForUser = new Document()
                        {
                            UserId = (int) Session["user_id"],
                            DocumentContents = reader.ReadBytes(file.ContentLength),
                            ContentType = file.ContentType
                        };

                        var newUserDocument =
                            _Context.Documents.SingleOrDefault(ud => ud.UserId == documentsForUser.UserId);
                        if (newUserDocument == null)
                        {
                            _Context.Documents.Add(documentsForUser);
                            _Context.SaveChanges();
                        }
                        else
                        {
                            var existingUserDocument =
                                _Context.Documents.SingleOrDefault(ud => ud.Id == newUserDocument.Id);
                            existingUserDocument.DocumentContents = newUserDocument.DocumentContents;
                            existingUserDocument.ContentType = newUserDocument.ContentType;
                            _Context.SaveChanges();

                            var singleUser = _Context.Users.SingleOrDefault(u => u.Id == documentsForUser.UserId);
                            singleUser.IsValid = null;
                            _Context.SaveChanges();
                        }

                        return RedirectToAction("Index", "Users");
                    }
                }
                return Content("only .jpg, .jpeg, .png are allowed. <a href='/Users/VerifyAccount'> back to previous.");
            }
            return RedirectToAction("LogInUser", "Users");
        }

        public ActionResult CheckDocument()
        {
            if (Session["user_id"] != null)
            {
                var userId = (int) Session["user_id"];
                var singleUserDcument = _Context.Documents.SingleOrDefault(ud => ud.UserId == userId);
                return View(singleUserDcument);
            }
            return RedirectToAction("LogInUser", "Users");
        }

        public ActionResult AddMember()
        {
            if (Session["user_id"] != null)
            {
                return View();
            }
            return RedirectToAction("LogInUser", "Users");
        }

        [HttpPost]
        public ActionResult StoreMember(UserHouse uh)
        {
            if (Session["user_id"] != null)
            {
                var user_id = (int) Session["user_id"];
                if (!ModelState.IsValid)
                {
                    return View("AddMember", uh);
                }
                var member = _Context.Users.SingleOrDefault(u => u.UserId == uh.UserId);
                if (member == null)
                {
                    ModelState.AddModelError("UserId","User Id is not exists");
                    return View("AddMember", uh);
                }

                var userHouse = _Context.UserHouses.SingleOrDefault(uhg => uhg.UserId == uh.UserId && uhg.IsActive==true);
                if (userHouse != null)
                {
                    ModelState.AddModelError("UserId", "User Id is already assign to a house key");
                    return View("AddMember", uh);
                }
                var managerHouse = _Context.ManagerHouses.SingleOrDefault(mh => mh.User_Id == user_id && mh.IsActive==true);
                var houseKeyId = _Context.HouseKeys.SingleOrDefault(hk => hk.Key == managerHouse.Key);

                UserHouse uHouse=new UserHouse();
                uHouse.UserId = uh.UserId;
                uHouse.IsActive = true;
                uHouse.HouseKeyId = houseKeyId.Id;

                _Context.UserHouses.Add(uHouse);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("LogInUser", "Users");
        }

        public ActionResult CheckYourAdd()
        {
            var user_id = (int) Session["user_id"];

            var yourAdds = _Context.Advertisements.Where(a => a.UserId == user_id).ToList();
            return View(yourAdds);
        }

        public ActionResult AllAdd()
        {
            var allAdds = _Context.Advertisements.Where(a=>a.IsPaid==true);
            var allAddViewModel= new AllAddViewModel()
            {
                Advertisements = allAdds
            };
            return View(allAddViewModel);
        }

        public ActionResult SearchByDivision()
        {
            var divisions = _Context.Divisions.ToList();
            CreateAddViewModel ca=new CreateAddViewModel()
            {
                Divisions = divisions
            };
            return View(ca);
        }

        public ActionResult SearchDivision(CreateAddViewModel cavm)
        {
            var divisionId = cavm.DivisionId;
            var divisionWiseAdvertisement =
                _Context.Advertisements.Where(a => a.DivisionId == divisionId && a.IsPaid == true);

            var allAdd=new AllAddViewModel()
            {
                Advertisements = divisionWiseAdvertisement
            };
            return View(allAdd);
        }

        public ActionResult SearchByDistrict()
        {
            var districts = _Context.Districts.ToList();
            CreateAddViewModel ca = new CreateAddViewModel()
            {
                Districts = districts
            };
            return View(ca);
        }

        public ActionResult SearchDistrict(CreateAddViewModel cavm)
        {
            var districtId = cavm.DistrictId;
            var districtWiseAdvertisement = _Context.Advertisements.Where(a => a.DistrictId == districtId && a.IsPaid == true);
            var allAdd = new AllAddViewModel()
            {
                Advertisements = districtWiseAdvertisement
            };
            return View(allAdd);
        }

        public ActionResult SearchByThana()
        {
            var thanas = _Context.Thanas.ToList();
            CreateAddViewModel ca = new CreateAddViewModel()
            {
                Thanas = thanas
            };
            return View(ca);

        }

        public ActionResult SearchThana(CreateAddViewModel cavm)
        {
            var thanaId = cavm.ThanaId;
            var thanaWiseAdvertisments = _Context.Advertisements.Where(a => a.ThanaId == thanaId && a.IsPaid == true).ToList();

            var allAdd = new AllAddViewModel()
            {
                Advertisements = thanaWiseAdvertisments
            };
            return View(allAdd);
        }
    }

    
}