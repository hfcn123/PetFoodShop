using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChongWu.Models;

namespace ChongWu.Controllers
{
    public class MenuController : Controller
    {
        PetEF db = new PetEF();
        // GET: Menu
        //首页
        [HttpGet]
        public ActionResult Index()
        {
            #region 商品列表
            var shop = db.petInfo.ToList();
            ViewData["shop"] = shop.ToList();
            #endregion
            ViewData["shuju"] = db.pettype.ToList();
            //接收登录传来的值

            var user = db.Userr.ToList();
            var useon = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
            int uso = db.Userr.Where(a => a.onlinet == 1).ToList().Count();
            //标识用来检测是否有人在线！
            ViewData["biaoshi"] = uso;
            if (uso == 0)
            {
                int userid = 999;
                ViewData["shuju"] = db.pettype.ToList();
                ViewData["username"] = "未登录";

                var cart = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["cart"] = db.cartinfo.Where(a => a.useid == userid).ToList();
                var cart1 = db.cartinfo.Where(a => a.useid == userid).ToList().Count();
                if (cart1 == 0) { ViewData["ts"] = "您没有登录哦！请先登录"; }
                ViewData["sl"] = db.cartinfo.Where(a => a.useid == userid).ToList().Count();

                ViewData["zj"] = cart.Select(a => a.cartprice * a.cartcount).Sum();
                ViewData["cid"] = 9999;
            } else {
                ViewData["cid"] = 999;
                int userid = (int)useon.Usid;
                ViewData["username"] = useon.UName;
                var cart = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["cart"] = db.cartinfo.Where(a => a.useid == userid).ToList();
                var cart1 = db.cartinfo.Where(a => a.useid == userid).ToList().Count();
                if (cart1 == 0) { ViewData["ts"] = "您没有登录哦！请先登录"; }
                ViewData["sl"] = db.cartinfo.Where(a => a.useid == userid).ToList().Count();

                ViewData["zj"] = cart.Select(a => a.cartprice * a.cartcount).Sum();



            }
            //广告
            ViewData["adv"] = db.guangaoinfo.ToList();


            return View();


        }
        [HttpPost]
        public ActionResult Index(string search)
        {
            #region 商品列表
            var shop = db.petInfo.ToList();
            if (!string.IsNullOrEmpty(search)) { shop = shop.Where(a => a.Cname.Contains(search)).ToList(); }
            ViewData["shop"] = shop.ToList();
            #endregion
            ViewData["shuju"] = db.pettype.ToList();

            var user = db.Userr.ToList();
            var useon = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
            int uso = db.Userr.Where(a => a.onlinet == 1).ToList().Count();
            //标识用来检测是否有人在线！
            ViewData["biaoshi"] = uso;
            if (uso == 0)
            {
                int userid = 999;


                ViewData["shuju"] = db.pettype.ToList();

                ViewData["username"] = "未登录";
                var cart = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["cart"] = db.cartinfo.Where(a => a.useid == userid).ToList();
                var cart1 = db.cartinfo.Where(a => a.useid == userid).ToList().Count();
                if (cart1 == 0) { ViewData["ts"] = "您没有登录哦！请先登录"; }
                ViewData["sl"] = db.cartinfo.Where(a => a.useid == userid).ToList().Count();

                ViewData["zj"] = cart.Select(a => a.cartprice * a.cartcount).Sum();
                ViewData["cid"] = 9999;
            }
            else
            {
                ViewData["cid"] = 999;
                int userid = (int)useon.Usid;
                ViewData["username"] = useon.UName;
                var cart = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["cart"] = db.cartinfo.Where(a => a.useid == userid).ToList();
                var cart1 = db.cartinfo.Where(a => a.useid == userid).ToList().Count();
                if (cart1 == 0) { ViewData["ts"] = "您没有登录哦！请先登录"; }
                ViewData["sl"] = db.cartinfo.Where(a => a.useid == userid).ToList().Count();

                ViewData["zj"] = cart.Select(a => a.cartprice * a.cartcount).Sum();



            }


            //广告
            ViewData["adv"] = db.guangaoinfo.ToList();


            return View();





        }
        //退出登录
        public ActionResult indexout() {


            var list = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
            list.onlinet = 0;
            int i = db.SaveChanges();
            if (i > 0) { return Content(@"<script>alert('您已退出个人账户！');location.href='/Menu/Index'</script>"); } else { return Content(@"<script>alert('退出失败！')</script>"); }

        }
        //购物车
        public ActionResult Shopcart() {


            var useon = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
            int uso = db.Userr.Where(a => a.onlinet == 1).ToList().Count();
            //标识用来检测是否有人在线！
            ViewData["biaoshi"] = uso;
            if (uso == 0) {

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
            else {
                var listname = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
                ViewData["username"] = listname.UName;
                #region 购物车快捷键
                var cart = db.cartinfo.Where(a => a.useid == useon.Usid).ToList();
                ViewData["sl"] = db.cartinfo.ToList().Count();
                ViewData["cart"] = db.cartinfo.ToList();
                ViewData["zj"] = cart.Select(a => a.cartprice * a.cartcount).Sum();
                ViewData["zj2"] = cart.Select(a => a.cartprice * a.cartcount).Sum() + 5;


                #endregion
                var cartlist = db.cartinfo.Where(a => a.useid == useon.Usid).ToList();
                return View(cartlist); }








        }
        //减商品
        public ActionResult jian(int id) {


            var cart = db.cartinfo.Where(a => a.cartid == id).FirstOrDefault();

            cart.cartcount--;
            var cart1 = db.cartinfo.Where(a => a.cartid == id).ToList();
            ViewData["zj"] = cart1.Select(a => a.cartprice * a.cartcount).Sum();

            int i = db.SaveChanges();
            return Json(i, JsonRequestBehavior.AllowGet);
        }
        //加商品
        public ActionResult jia(int id)
        {

            var cart = db.cartinfo.Where(a => a.cartid == id).FirstOrDefault();

            cart.cartcount++;
            var cart1 = db.cartinfo.Where(a => a.cartid == id).ToList();
            ViewData["zj"] = cart1.Select(a => a.cartprice * a.cartcount).Sum();

            int i = db.SaveChanges();
            return Json(i, JsonRequestBehavior.AllowGet);
        }
       //加入购物车
        public ActionResult addcart(int id)
        {

            var useron = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
            int uso = db.Userr.Where(a => a.onlinet == 1).ToList().Count();

            int userid = useron.Usid;
            ViewData["userid"] = userid;
            cartinfo item = new cartinfo();
            var list = db.petInfo.Where(a => a.Cid == id).FirstOrDefault();

            var cart = db.cartinfo.ToList();
            var cart1 = db.cartinfo.Where(a => a.cid == id).ToList().Count();
            if (cart1 == 0)
            {
                item.cartname = list.Cname;
                item.cartphoto = list.Cphoto;
                item.cartprice = list.Cprice;
                item.cid = list.Cid;
                item.useid = userid;
                item.cartcount = 1;
                db.cartinfo.Add(item);
            }
            else
            {
                var shuliang = db.cartinfo.Where(a => a.cid == id).FirstOrDefault();
                shuliang.cartcount++;

            }
            int i = db.SaveChanges();
            return Json(i, JsonRequestBehavior.AllowGet);



        }

        //移除购物车
        public ActionResult movecart(int id)
        {
            var useron = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
            int userid = useron.Usid;
            ViewData["userid"] = userid;
            var list = db.cartinfo.Where(a => a.cartid == id && a.useid == userid).FirstOrDefault();

            db.cartinfo.Remove(list);
            int i = db.SaveChanges();
            return Json(i, JsonRequestBehavior.AllowGet);
        }
        public ActionResult checkout() {
            var useron = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
          
           
            int uso = db.Userr.Where(a => a.onlinet == 1).ToList().Count();
         
            //标识用来检测是否有人在线！
            ViewData["biaoshi"] = uso;
            if (uso == 0)
            {
                
                int userid =99999;
                ViewData["userid"] = userid;
                ViewData["username"] = "";

                #region 购物车快捷键

                var cart = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["sl"] = cart.ToList().Count();
                ViewData["cart"] = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["zj"] = cart.Select(a => a.cartprice * a.cartcount).Sum();
                ViewData["zj2"] = cart.Select(a => a.cartprice * a.cartcount).Sum() + 5;



                #endregion
                var cartlist = db.cartinfo.ToList();
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
                var cartlist = db.cartinfo.ToList();

                return View(cartlist);
            }
        


         }

      
        public ActionResult shop(int id) {
            var useron = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
            int uso = db.Userr.Where(a => a.onlinet == 1).ToList().Count();
            //标识用来检测是否有人在线！
            ViewData["biaoshi"] = uso;
            if (uso == 0) {


                int userid = 999;
                ViewData["userid"] = userid;
                #region 购物车快捷键
                var cart = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["sl"] = cart.ToList().Count();
                ViewData["cart"] = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["zj"] = cart.Select(a => a.cartprice * a.cartcount).Sum();
                #endregion

            }
            else {

                int userid = useron.Usid;
                ViewData["userid"] = userid;
                #region 购物车快捷键
                var cart = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["sl"] = cart.ToList().Count();
                ViewData["cart"] = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["zj"] = cart.Select(a => a.cartprice * a.cartcount).Sum();
                #endregion

            }


            var shuju = db.petInfo.Where(a => a.PetID == id).ToList();
            return View(shuju);
        }

        public ActionResult xiangqing(int id)
        {
            var useron = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
            int uso = db.Userr.Where(a => a.onlinet == 1).ToList().Count();
            //标识用来检测是否有人在线！
            ViewData["biaoshi"] = uso;
            if (uso == 0)
            {
                int userid = 9999;
                ViewData["userid"] = userid;

                #region 购物车快捷键
                var cart = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["sl"] = cart.ToList().Count();
                ViewData["cart"] = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["zj"] = cart.Select(a => a.cartprice * a.cartcount).Sum();
                #endregion
                ViewData["pro"] = db.single_product.Where(a => a.Cid == id).ToList();
                var list1 = db.single_product.Where(a => a.Cid == id).FirstOrDefault();
                int tid = list1.typeid;
                #region 图片
                var pro = db.single_product.Where(a => a.Cid == id).Select(a => new { a.picture, a.picture1, a.picture2, a.picture3 }).FirstOrDefault();
                ViewData["pic"] = pro.picture;
                ViewData["pic1"] = pro.picture1;
                ViewData["pic2"] = pro.picture2;
                ViewData["pic3"] = pro.picture3;

                #endregion
                ViewData["shop"] = db.petInfo.Where(a => a.Ctype == 1 && a.PetID == tid).ToList();
                petInfo shop = new petInfo();
                #region 右侧代码
                var list = db.petInfo.Where(a => a.Cid == id).FirstOrDefault();

                ViewData["price"] = list.Cprice;
                ViewData["name"] = list.Cname;
                ViewData["tags"] = list.CTags;
                ViewData["dec"] = list.CDescription;
                ViewData["res"] = list.CReviews;
                ViewData["id"] = 9999;
                #endregion
            }
            else
            {
                int userid = useron.Usid;
                ViewData["userid"] = userid;
                var listname = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
                ViewData["username"] = listname.UName;
                #region 购物车快捷键
                var cart = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["sl"] = cart.ToList().Count();
                ViewData["cart"] = db.cartinfo.Where(a => a.useid == userid).ToList();
                ViewData["zj"] = cart.Select(a => a.cartprice * a.cartcount).Sum();
                #endregion



                ViewData["pro"] = db.single_product.Where(a => a.Cid == id).ToList();
                var list1 = db.single_product.Where(a => a.Cid == id).FirstOrDefault();
                int tid = list1.typeid;
                #region 图片
                var pro = db.single_product.Where(a => a.Cid == id).Select(a => new { a.picture, a.picture1, a.picture2, a.picture3 }).FirstOrDefault();
                ViewData["pic"] = pro.picture;
                ViewData["pic1"] = pro.picture1;
                ViewData["pic2"] = pro.picture2;
                ViewData["pic3"] = pro.picture3;

                #endregion
                ViewData["shop"] = db.petInfo.Where(a => a.Ctype == 1 && a.PetID == tid).ToList();
                petInfo shop = new petInfo();

                #region 右侧代码
                var list = db.petInfo.Where(a => a.Cid == id).FirstOrDefault();

                ViewData["price"] = list.Cprice;
                ViewData["name"] = list.Cname;
                ViewData["tags"] = list.CTags;
                ViewData["dec"] = list.CDescription;
                ViewData["res"] = list.CReviews;
                ViewData["id"] = list.Cid;
                #endregion

            }

            return View();



        }
        [HttpGet]
        public ActionResult CY() {

            var useron = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
            int uso = db.Userr.Where(a => a.onlinet == 1).ToList().Count();
            //标识用来检测是否有人在线！
            ViewData["biaoshi"] = uso;


            return View();

        }
        [HttpPost]
        public ActionResult CY(string loginname, string loginpassword, FormCollection collection)
        {
            var useron = db.Userr.Where(a => a.onlinet == 1).FirstOrDefault();
            int uso = db.Userr.Where(a => a.onlinet == 1).ToList().Count();
            //标识用来检测是否有人在线！
            ViewData["biaoshi"] = uso;


            if (collection.GetValue("chec") != null)
            {
                var count1 = db.Userr.Where(a => a.Tel == loginname || a.email == loginname || a.UName == loginname).ToList().Count();
                if (count1 == 0)
                {

                    return Content(@"<script>alert('您还未注册是否前往注册！');location.href=' " + Url.Action("Zc") + " '</script>");
                }
                else
                {
                    Userr v = db.Userr.Where(a => a.Tel == loginname || a.email == loginname || a.UName == loginname).FirstOrDefault();

                    if (v.Tel == loginname && v.Pwd == loginpassword || v.UName == loginname && v.Pwd == loginpassword || v.email == loginname && v.Pwd == loginpassword)
                    {


                        int id = v.Usid;
                        v.onlinet = 1;
                        int i = db.SaveChanges();
                        return Content(@"<script>alert('登陆成功');location.href='/Menu/Index/'</script>");
                        //return Content(@"<script>alert('登陆成功');location.href='/Menu/Index1/"+id+"'</script>");

                    }
                    else
                    {

                        return Content(@"<script>alert('密码有误，请重新输入！');location.href='/Menu/CY/" + loginname + "'</script>");
                    }



                }
            }
            else {

                return Content(@"<script>alert('请先勾选已阅读用户协议');location.href='/Menu/CY/" + loginname + "'</script>");
            }

        }
        public ActionResult register() {

            int uso = db.Userr.Where(a => a.onlinet == 1).ToList().Count();
            //标识用来检测是否有人在线！
            ViewData["biaoshi"] = uso;



            return View();

        }
        [HttpPost]
        public ActionResult register(HttpPostedFileBase files, Userr us)
        {

            int uso = db.Userr.Where(a => a.onlinet == 1).ToList().Count();
            //标识用来检测是否有人在线！
            ViewData["biaoshi"] = uso;


            var list = db.Userr.FirstOrDefault();

            files.SaveAs(Server.MapPath("/img/uimg/" + files.FileName));
     
           list.Uimg = files.FileName;
            list.UName = us.UName;
            list.Tel = us.Tel;
            list.adress = us.adress;
            list.Pwd = us.Pwd;
            list.onlinet = 0;
            list.vipcode ="";
            list.adminid = 0;
            list.adminpwd = null;
            db.Userr.Add(list);
            int i = db.SaveChanges();
            if (i > 0) {
                return Content(@"<script>alert('注册成功!');location.href='/Menu/CY/'</script>");
            } else { return Content(@"<script>alert('注册失败！')'</script>"); }
           

        }
        //首页产品只展示9个
        public ActionResult shopmenu()
        {

            ViewData["shoplist"] = db.petInfo.Where(a=>a.Cid<=9).ToList();
        return View();
        }
        public ActionResult shopmenu1()
        {

            ViewData["shoplist"] = db.petInfo.Where(a => a.Cid >= 9).ToList();
            return View();
        }
        [HttpGet]
        public ActionResult bidaxiao()
        {

            return View();
        }
        [HttpPost]
        public ActionResult bidaxiao(int one,int two)
        {

            if (one>two) {
                return Content(@"<script>alert('"+one+","+two+ "!');location.href='/Menu/bidaxiao/'</script>");

            } else { return Content(@"<script>alert('" + two + "," + one + "!');location.href='/Menu/bidaxiao/'</script>"); }
            return View();
        }
    }
}