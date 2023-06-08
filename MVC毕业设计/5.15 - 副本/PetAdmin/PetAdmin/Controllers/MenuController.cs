using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetAdmin.Models;
namespace PetAdmin.Controllers
{
    public class MenuController : Controller
    {
        PetEF db = new PetEF();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        //商品信息列表
        public ActionResult shopinfo()
        {

            var list = db.petInfo.ToList();

            return View(list);
        }
        [HttpGet]
        //添加商品
        public ActionResult addshop()
        {
            var list = db.pettype.ToList();
            ViewData["ddl"] = new SelectList(list, "PetID", "PetName");
            return View();
        }
        [HttpPost]
        //添加商品
        public ActionResult addshop(petInfo pet)
        {

            var list = db.pettype.ToList();
            ViewData["ddl"] = new SelectList(list, "PetID", "PetName");
            pet.CReviews = null;
            pet.ISHeart = 0;
            db.petInfo.Add(pet);
            int i = db.SaveChanges();
            if (i > 0)
            {
                return Content(@"<script>alert('添加成功！');location.href=' " + Url.Action("shopinfo") + " '</script>");
            }
            else { return Content(@"<script>alert('添加失败！')</script>"); }

        }
        //修改商品
        public ActionResult editshop() { return View(); }
        //删除商品
        public ActionResult deleshop(int id) {

            var list = db.petInfo.Where(a => a.Cid == id).FirstOrDefault();
            db.petInfo.Remove(list);
            int i = db.SaveChanges();
            return Json(i, JsonRequestBehavior.AllowGet);
            
          }
        //用户信息列表
        public ActionResult userinfo()
        {
            var userlist = db.Userr.ToList();

            return View(userlist);
        }
        [HttpGet]
        //添加用户
        public ActionResult adduser() { return View(); }
        [HttpPost]
        public ActionResult adduser(Userr us) {

            us.onlinet = 0;
                db.Userr.Add(us);
            int i = db.SaveChanges();
            if (i > 0)
            {
                return Content(@"<script>alert('添加成功！正在前往用户列表');location.href=' " + Url.Action("userinfo") + " '</script>");
            }
            else { return Content(@"<script>alert('添加失败！')</script>"); }
           }
        //修改用户
        public ActionResult edituser() { return View(); }
        //删除用户
        public ActionResult deleuser() { return View(); }
    }
}