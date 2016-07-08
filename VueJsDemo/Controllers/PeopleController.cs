using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VueJs.Data;

namespace VueJsDemo.Controllers
{
    public class PeopleController : Controller
    {
        public ActionResult GetAll()
        {
            var repo = new PersonRepo(Properties.Settings.Default.ConStr);
            return Json(repo.GetPeople(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Add(Person person)
        {
            var repo = new PersonRepo(Properties.Settings.Default.ConStr);
            repo.AddPerson(person);
        }

        [HttpPost]
        public void Update(Person person)
        {
            var repo = new PersonRepo(Properties.Settings.Default.ConStr);
            repo.Update(person);
        }

        [HttpPost]
        public void Delete(int id)
        {
            var repo = new PersonRepo(Properties.Settings.Default.ConStr);
            repo.Delete(id);
        }

    }
}
