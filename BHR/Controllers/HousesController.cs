using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BHR.Models;
using BHR.ViewModels;

namespace BHR.Controllers
{
    public class HousesController : Controller
    {
        private BhrContext _Context;

        public HousesController()
        {
            _Context = new BhrContext();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }

        public ActionResult CreateHouse()
        {
            if (Session["user_id"] != null)
            {
                var user_id = (int) Session["user_id"];
                var singleUser = _Context.Users.SingleOrDefault(u => u.Id == user_id);
                var newHouse = new CreateHouseViewModel()
                {
                    Divisions = _Context.Divisions.ToList(),
                    UserId = singleUser.UserId
                };
                return View(newHouse);
            }
            return RedirectToAction("LogInUser", "Users");
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

        [HttpPost]
        public ActionResult StoreHouse(CreateHouseViewModel ch)
        {
            if (Session["user_id"] != null)
            {
                var user_id = (int) Session["user_id"];
                var singleUser = _Context.Users.SingleOrDefault(u => u.Id == user_id);
                if (!ModelState.IsValid)
                {
                    var newHouse = new CreateHouseViewModel()
                    {
                        Divisions = _Context.Divisions.ToList(),
                        UserId = singleUser.UserId

                    };

                    return View("CreateHouse", newHouse);
                }

                var nHouse = new House()
                {
                    Address = ch.Address,
                    UserId = user_id,
                    ThanaId = ch.ThanaId
                };
                _Context.Houses.Add(nHouse);
                _Context.SaveChanges();

                return RedirectToAction("Index", "Users");
            }
            return RedirectToAction("LogInUser", "Users");
        }

        public ActionResult HouseList()
        {
            if (Session["user_id"] != null)
            {
                var user_id = (int) Session["user_id"];
                var houses = _Context.Houses.Where(h => h.UserId == user_id);

                return View(houses);
            }
            return RedirectToAction("LogInUser", "Users");
        }

        public ActionResult HouseDetails(int id)
        {
            if (Session["user_id"] != null)
            {
                var singleHouse = _Context.Houses.SingleOrDefault(h => h.Id == id);
                if (singleHouse == null)
                {
                    return HttpNotFound();

                }

                _Context.Users.Where(u => u.Id == singleHouse.UserId).Load();
                _Context.Thanas.Where(t => t.Id == singleHouse.ThanaId).Load();
                _Context.Districts.Where(d => d.Id == singleHouse.Thana.DistrictId).Load();
                _Context.Divisions.Where(dv => dv.Id == singleHouse.Thana.District.DivisionId).Load();

                return View(singleHouse);
            }
            return RedirectToAction("LogInUser", "Users");
        }

        public ActionResult HouseKey(int id)
        {
            if (Session["user_id"] != null)
            {
                var user_id = (int) Session["user_id"];
                var user = _Context.Users.Find(user_id);
                string userId = user.UserId;
                string key = userId + "_" + DateTime.Now.ToString("MMddyyyyHHmmssfff");
                var houseKey = new HouseKey()
                {
                    Key = key,
                    HouseId = id
                };
                return View("HouseKey", houseKey);
            }
            return RedirectToAction("LogInUser", "Users");
        }
        [HttpPost]
        public ActionResult StoreHouseKey(HouseKey hk)
        {
            if (Session["user_id"] != null)
            {
                if (!ModelState.IsValid)
                {
                    return View("HouseKey",hk);
                }

                var user_id = (int) Session["user_id"];
                var house = _Context.Houses.Where(h => h.Id == hk.Id && h.UserId == user_id);
                if (house == null)
                {
                    return HttpNotFound();
                }
                _Context.HouseKeys.Add(hk);
                _Context.SaveChanges();
                return RedirectToAction("HouseDetails", new {id = hk.HouseId});
            }
            return RedirectToAction("LogInUser", "Users");

        }

        public ActionResult HouseKeyList(int id)
        {
            if (Session["user_id"] != null)
            {
                var houseKeyView = new HouseKeyListViewModel()
                {
                    HouseKeys = _Context.HouseKeys.Where(hk => hk.HouseId == id),
                    House_Id = id
            };
                return View(houseKeyView);
            }
            return RedirectToAction("LogInUser", "Users");
        }

        [Route("Houses/CheckManager/{key}")]
        public ActionResult ManagerDetails(string key)
        {
            var managerId = _Context.ManagerHouses.SingleOrDefault(mh => mh.Key == key && mh.IsActive==true);
            if (managerId != null)
            {
                var singleManager = _Context.Users.SingleOrDefault(u => u.Id == managerId.User_Id);
                var UserDetails = new UserDetailsViewModel()
                {
                    User = singleManager,
                    UserImage = _Context.UserImages.SingleOrDefault(ui => ui.UserId == managerId.User_Id),
                    Document = _Context.Documents.SingleOrDefault(ud => ud.UserId == managerId.User_Id),
                    Key = _Context.HouseKeys.SingleOrDefault(hk => hk.Key == key)
                };


                return View(UserDetails);
            }
            return Content("No Manager added yet!!!!! <a href='/Users/Index'>back to previous</\a>");


        }
        [Route("Houses/CheckMembers/{key}")]
        public ActionResult MembersList(string key)
        {
            List<User> Users = new List<User>();

            var houseKeyId = _Context.HouseKeys.SingleOrDefault(hk => hk.Key == key);

            var house = _Context.Houses.SingleOrDefault(h => h.Id == houseKeyId.HouseId);

            var members = _Context.UserHouses.Where(mh => mh.HouseKeyId==houseKeyId.Id && mh.IsActive == true).ToList();
            var membersId = members.Select(m => m.UserId);
            foreach (var x in membersId)
            {
                Users.Add(_Context.Users.SingleOrDefault(u => u.UserId == x));
            }
            var memberList = new MembersListViewModel()
            {
                User = Users,
                HouseId = house.Id

            };
            return View(memberList);
        }

        
        public ActionResult MemberDetails(int id)
        {
            var singleManager = _Context.Users.Find(id);
            var houseKeyUser =
                _Context.UserHouses.SingleOrDefault(uh => uh.UserId == singleManager.UserId && uh.IsActive == true);
            var houseKey = _Context.HouseKeys.SingleOrDefault(hk => hk.Id == houseKeyUser.HouseKeyId);
            var UserDetails = new UserDetailsViewModel()
            {
                User = singleManager,
                UserImage = _Context.UserImages.SingleOrDefault(ui => ui.UserId == id),
                Document = _Context.Documents.SingleOrDefault(ud => ud.UserId == id),
                HouseKey = houseKey.Key
                
            };

            return View(UserDetails);
        }

        public ActionResult ViewAddDetails(int id)
        {
            var advertisement = _Context.Advertisements.SingleOrDefault(a => a.Id == id);
            var addImages = _Context.AdvertiseImages.Where(ai => ai.AdvertisementId == advertisement.Id).ToList();
            var division = _Context.Divisions.Find(advertisement.DivisionId);
            var district = _Context.Districts.Find(advertisement.DistrictId);
            var thana = _Context.Thanas.Find(advertisement.ThanaId);
            var addViewModel=new AddDetailsViewModel()
            {
                Advertisement = advertisement,
                AdvertiseImages = addImages,
                Division = division,
                District = district,
                Thana = thana
            };
            return View(addViewModel);
        }

    }
}