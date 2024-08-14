using TranAnhDung_2122110043.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TranAnhDung_2122110043.Context;

namespace DangThanhTu_2122110051.Controllers
{
    public class UserController : Controller
    {

        WebsiteAspEntities5 objAspNetWeb = new WebsiteAspEntities5();
        // GET: User

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User _user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var check = objAspNetWeb.Users.FirstOrDefault(s => s.email == _user.email);
                    if (check == null)
                    {
                        _user.password = GetMD5(_user.password);
                        objAspNetWeb.Configuration.ValidateOnSaveEnabled = false;
                        objAspNetWeb.Users.Add(_user);
                        objAspNetWeb.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.error = "email already exists";
                        return View();
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if necessary
                //ViewBag.error = "An error occurred during registration. Please try again later.";
                throw;
            }
        }


        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

   
            [HttpGet]
            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Login(string email, string password)
            {
                if (ModelState.IsValid)
                {


                    var f_password = GetMD5(password);
                    var data = objAspNetWeb.Users.Where(s => s.email.Equals(email) && s.password.Equals(f_password)).ToList();
                    if (data.Count() > 0)
                    {
                        //add session
                        Session["FullName"] = data.FirstOrDefault().firstname + " " + data.FirstOrDefault().lastname;
                        Session["Email"] = data.FirstOrDefault().email;
                        Session["idUser"] = data.FirstOrDefault().id;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.error = "Login failed";
                        return RedirectToAction("Login");
                    }
                }
                return View();
            }


            //Logout
            public ActionResult Logout()
            {
                Session.Clear();//remove session
                return RedirectToAction("Login");
            }



        }
    }