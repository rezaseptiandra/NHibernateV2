using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernateV2.Models;
using NHibernate.Linq;
using System.Collections;

namespace NHibernateV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
                //using (ISession session = sessionFactory.OpenSession())
                //using (ITransaction tx = session.BeginTransaction())
                //{
                //    session.Save(
                //       new Parent()
                //       {
                //           Children = new List<Child>()
                //           {
                //    new Child(),
                //    new Child()
                //           }
                //       });
                //    tx.Commit();
                //}
            AppContext.AppConfigure();
            using (ISession session = AppContext.SessionFactory.OpenSession())
            {
                var employees = session.Query<Menu>().ToList();
                IList<Menu> Emplist = session.Query<Menu>().ToList();
                return View(employees);
            }
            /* using (ISession session = NHibertnateSession.OpenSession())
             {
                 var employees = session.Query<Employee>().ToList();
                 IList<Employee> Emplist = session.Query<Employee>().ToList();
                 return View(employees);
             }*/
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
    }
}