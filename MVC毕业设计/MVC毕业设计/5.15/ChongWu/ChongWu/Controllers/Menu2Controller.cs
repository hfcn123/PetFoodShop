using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChongWu.Models;


namespace ChongWu.Controllers
{
    public class Menu2Controller : Controller
    {
        PetEF db = new PetEF();
        // GET: Menu2
        //第二个购物车  登陆后的详情页跳转到此购物车
        public ActionResult Index()
        {
            var useon = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
            int uso = db.Userr.Where(a => a.onlinet == 1).ToList().Count();
            //标识用来检测是否有人在线！
            ViewData["biaoshi"] = uso;
            if (uso == 0)
            {

                int userid = 999;
                var cartlist = db.cartinfo.Where(a => a.useid == userid).ToList();
                #region 购物车快捷键
                var cart = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["sl"] = db.cartinfo.ToList().Count();
                ViewData["cart"] = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["zj"] = cart.Select(a => a.cartprice * a.cartcount).Sum();
                ViewData["zj2"] = cart.Select(a => a.cartprice * a.cartcount).Sum() + 5;


                #endregion

                return View(cartlist);



            }
            else
            {

                #region 购物车快捷键
                var cart = db.cartinfo.Where(a => a.useid == useon.Usid).ToList();
                ViewData["sl"] = db.cartinfo.ToList().Count();
                ViewData["cart"] = db.cartinfo.ToList();
                ViewData["zj"] = cart.Select(a => a.cartprice * a.cartcount).Sum();
                ViewData["zj2"] = cart.Select(a => a.cartprice * a.cartcount).Sum() + 5;


                #endregion
                var cartlist = db.cartinfo.Where(a => a.useid == useon.Usid).ToList();
                return View(cartlist);
            }
        }
        //第二个结算页面  登陆后的详情页跳转到此结算页面
        public ActionResult checkout()
        {
            //var useron = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
            //var useon = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
            //int userid = useron.Usid;
            //int uso = db.Userr.Where(a => a.onlinet == 1).ToList().Count();
            //ViewData["userid"] = userid;
            ////标识用来检测是否有人在线！
            //ViewData["biaoshi"] = uso;

            //ViewData["username"] = useon.UName;


            //#region 购物车快捷键

            //var cart = db.cartinfo.Where(a => a.useid == userid).ToList();
            //ViewData["sl"] = cart.ToList().Count();
            //ViewData["cart"] = db.cartinfo.Where(a => a.useid == userid).ToList();
            //ViewData["zj"] = cart.Select(a => a.cartprice * a.cartcount).Sum();
            //ViewData["zj2"] = cart.Select(a => a.cartprice * a.cartcount).Sum() + 5;



            //#endregion
            //var cartlist = db.cartinfo.ToList();

            //return View(cartlist);

            var useron = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();


            int uso = db.Userr.Where(a => a.onlinet == 1).ToList().Count();

            //标识用来检测是否有人在线！
            ViewData["biaoshi"] = uso;
            if (uso == 0)
            {

                int userid = 99999;
                ViewData["userid"] = userid;
                ViewData["username"] = "";

                #region 购物车快捷键

                var cart = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["sl"] = cart.ToList().Count();
                ViewData["cart"] = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["zj"] = cart.Select(a => a.cartprice * a.cartcount).Sum();
                ViewData["zj2"] = cart.Select(a => a.cartprice * a.cartcount).Sum() + 5;



                #endregion
                var cartlist = db.cartinfo.Where(a=>a.useid==userid).ToList();
                return View(cartlist);
            }
            else
            {

                ViewData["username"] = useron.UName;
                int userid = useron.Usid;
                #region 购物车快捷键

                var cart = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["sl"] = cart.ToList().Count();
                ViewData["cart"] = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["zj"] = cart.Select(a => a.cartprice * a.cartcount).Sum();
                ViewData["zj2"] = cart.Select(a => a.cartprice * a.cartcount).Sum() + 5;



                #endregion
                var cartlist = db.cartinfo.Where(a => a.useid == userid).ToList();
                return View(cartlist);
            }


        }
    }
}