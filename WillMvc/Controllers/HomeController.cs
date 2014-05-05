using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WillMvc.Models;

namespace WillMvc.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreateClient()
        {
            return View();
        }

        public ActionResult Report()
        {
            CustomerEntities db = new CustomerEntities();

            var data = db.Database.SqlQuery<ReportVM>(@"
select * 
, (select count(*) from dbo.客戶聯絡人 a where a.客戶Id = c.Id ) NumOfContact
, (select count(*) from dbo.客戶銀行資訊 b where b.客戶Id = c.Id) NumOfBankInfo
from dbo.客戶資料 c");

            return View(data);
        }

        public ActionResult ClientSimple()
        {
            var repo = RepositoryHelper.Get客戶資料Repository();

            var data = from p in repo.CustomersFromTaipei() //db.客戶資料
                       select new ClientSimple
                       {
                           Name = p.客戶名稱,
                           No = p.統一編號
                       };

            return View(data);
        }

        public ActionResult CRUD()
        {
            var repo = RepositoryHelper.Get客戶資料Repository();

            // Create
            客戶資料 c = new 客戶資料
            {
                 郵件 = "99@email.com",
                統一編號 = "55667788",
                客戶名稱 = "Walter",
                電話 = "999"
            };

            repo.Add(c);
            repo.UnitOfWork.Commit();

            //db.客戶資料.Add(c);
            //db.SaveChanges();

            // Update
            var c2 = repo.Find(c.Id); //db.客戶資料.Find(c.Id);
            c2.傳真 = "666";
            repo.UnitOfWork.Commit(); //db.SaveChanges();

            // Delete
            repo.Delete(c2);
            repo.UnitOfWork.Commit();

            //db.客戶資料.Remove(c2);
            //db.SaveChanges();

            return View();
        }
    }
}