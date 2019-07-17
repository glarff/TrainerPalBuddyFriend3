using NHibernate;
using System;
using System.Data;
using System.Web.Mvc;
using System.IO;
using System.Collections.Generic;
using NHibernate.Linq;
using System.Linq;
using NHibernate.Transform;

namespace TrainerPalBuddyFriend3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Types()
        {
            return View();
        }

        public ActionResult Workouts()
        {
            return View();
        }

        public ActionResult Form3(Types tp)
        {
            if (ModelState.IsValid)
            {
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Types newType = new Types();
                    newType.Typeid = tp.Typeid;
                    newType.Name = tp.Name;
                    newType.Custom = tp.Custom;

                    _S.Save(newType);
                    _S.Flush();
                    _S.Clear();
                }

                ViewBag.onSuccess_Message = "Type " + tp.Name + " Added Successfully"; 
               
                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Segments()
        {
            var list = new List<MyListTable>();

            using (ISession _S = MvcApplication.SF.GetCurrentSession())
            {
                Types typ = null;

                var typeList = _S.QueryOver<Types>(() => typ)
                    .SelectList(l => l
                        .Select(x => x.Typepk).WithAlias(() => typ.Typepk)
                        .Select(x => x.Name).WithAlias(() => typ.Name)
                    )
                    .TransformUsing(Transformers.AliasToBean<Types>())
                    .List<Types>();

                foreach (var r in typeList)
                {
                    list.Add(new MyListTable
                    {
                        Key = r.Typepk,
                        Display = r.Name.ToString()
                    });  
                }
            }

            var model = new Segments();
            model.DropDownList = new SelectList(list, "Key", "Display");

            return View(model);
        }

        public ActionResult Form4(Segments sg)
        {
            if (ModelState.IsValid)
            {
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Segments newSegment = new Segments();
                    newSegment.Segmentid = sg.Segmentid;
                    newSegment.Name = sg.Name;
                    newSegment.Types = sg.Types;
                    newSegment.Customflg = sg.Customflg;

                    _S.Save(newSegment);
                    _S.Flush();
                    _S.Clear();
                }

                ViewBag.onSuccess_Message = "Segment " + sg.Name + " Added Successfully";

                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Tips()
        {
            var list = new List<MyListTable>();

            using (ISession _S = MvcApplication.SF.GetCurrentSession())
            {
                Types typ = null;

                var typeList = _S.QueryOver<Types>(() => typ)
                    .SelectList(l => l
                        .Select(x => x.Typepk).WithAlias(() => typ.Typepk)
                        .Select(x => x.Name).WithAlias(() => typ.Name)
                    )
                    .TransformUsing(Transformers.AliasToBean<Types>())
                    .List<Types>();

                foreach (var r in typeList)
                {
                    list.Add(new MyListTable
                    {
                        Key = r.Typepk,
                        Display = r.Name.ToString()
                    });
                }
            }

            var model = new Tips();
            model.DropDownList = new SelectList(list, "Key", "Display");

            return View(model);
        }

        public ActionResult Form5(Tips wk)
        {
            if (ModelState.IsValid)
            {
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Tips newTip = new Tips();
                    newTip.Tipid = wk.Tipid;
                    newTip.Text = wk.Text;
                    newTip.Types = wk.Types;
                    newTip.Custom = wk.Custom;

                    _S.Save(newTip);
                    _S.Flush();
                    _S.Clear();
                }

                ViewBag.onSuccess_Message = "Tip " + wk.Text + " Added Successfully";

                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }
    }
}