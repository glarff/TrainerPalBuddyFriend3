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
            var list = new List<Types>();
            // Get data for existing Types
            using (ISession _S = MvcApplication.SF.GetCurrentSession())
            {
                Types typ = null;

                var typeList = _S.QueryOver<Types>(() => typ)
                    .SelectList(l => l
                        .Select(x => x.Typepk).WithAlias(() => typ.Typepk)
                        .Select(x => x.Typeid).WithAlias(() => typ.Typeid)
                        .Select(x => x.Name).WithAlias(() => typ.Name)
                        .Select(x => x.Custom).WithAlias(() => typ.Custom)
                    )
                    .TransformUsing(Transformers.AliasToBean<Types>())
                    .List<Types>();

                foreach (var r in typeList)
                {
                    list.Add(r);
                }
            }
            return View(list);
        }

        public ActionResult Workouts()
        {
            return View();
        }

        public ActionResult Form3(List<Types> newList)
        {
            if (ModelState.IsValid)
            {
                // Get existing types
                var newListPKs = new List<int>();
                var oldListPKs = new List<int>();

                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Types typ = null;

                    var oldList = _S.QueryOver<Types>(() => typ)
                        .SelectList(l => l
                            .Select(x => x.Typepk).WithAlias(() => typ.Typepk)
                        )
                        .TransformUsing(Transformers.AliasToBean<Types>())
                        .List<Types>();

                    foreach (var r in oldList)
                    {
                        oldListPKs.Add(r.Typepk);
                    }

                    foreach (var r in newList)
                    {
                        newListPKs.Add(r.Typepk);
                    }

                    foreach (var q in newList)
                    {
                        //updates
                        if (oldListPKs.Contains(q.Typepk))
                        {
                            var persistentType = _S.Load<Types>(q.Typepk);

                            persistentType.Typeid = q.Typeid;
                            persistentType.Name = q.Name;
                            persistentType.Custom = q.Custom;

                            _S.Save(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }

                        //inserts
                        else if (q.Typepk == 0)
                        {
                            var persistentType = new Types();

                            persistentType.Typeid = q.Typeid;
                            persistentType.Name = q.Name;
                            persistentType.Custom = q.Custom;

                            _S.Save(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }

                    }

                    //deletions
                    foreach (var x in oldListPKs)
                    {
                        if (!(newListPKs.Contains(x)))
                        {
                            var persistentType = _S.Load<Types>(x);

                            _S.Delete(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }

                    }

                }
               
                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Form6(Workouts wk)
        {
            if (ModelState.IsValid)
            {
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Workouts newWorkout = new Workouts();
                    newWorkout.Workoutid = wk.Workoutid;
                    newWorkout.Name = wk.Name;
                    newWorkout.Customflg = wk.Customflg;

                    _S.Save(newWorkout);
                    _S.Flush();
                    _S.Clear();
                }

                ViewBag.onSuccess_Message = "Workout " + wk.Name + " Added Successfully";

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

        public ActionResult WkSeg(Wkseg w)
        {          
            if (w.Workouts == null)
            {
                var list = new List<MyListTable>();

                // Get list of workouts
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Workouts wk = null;

                    var typeList = _S.QueryOver<Workouts>(() => wk)
                        .SelectList(l => l
                            .Select(x => x.Workoutpk).WithAlias(() => wk.Workoutpk)
                            .Select(x => x.Name).WithAlias(() => wk.Name)
                        )
                        .TransformUsing(Transformers.AliasToBean<Workouts>())
                        .List<Workouts>();

                    foreach (var r in typeList)
                    {
                        list.Add(new MyListTable
                        {
                            Key = r.Workoutpk,
                            Display = r.Name.ToString()
                        });
                    }
                }

                // Get list of available segments to add to workout

                // Get list of already added segments for workout

                var model = new Wkseg();
                model.DropDownList = new SelectList(list, "Key", "Display");

                return View(model);

            }

            else
            {
                return View();
            }

        }

        public ActionResult Form7(Wkseg wk)
        {
            if (ModelState.IsValid)
            {
                var tmpWk = new Wkseg();
                tmpWk.Workouts = wk.Workouts;

                // Populate available segments
                var list2 = new List<MyListTable>();

                // Get list of workouts
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Segments sg = null;

                    var segmentList = _S.QueryOver<Segments>(() => sg)
                        .SelectList(l => l
                            .Select(x => x.Segmentpk).WithAlias(() => sg.Segmentpk)
                            .Select(x => x.Name).WithAlias(() => sg.Name)
                        )
                        .TransformUsing(Transformers.AliasToBean<Segments>())
                        .List<Segments>();

                    foreach (var r in segmentList)
                    {
                        list2.Add(new MyListTable
                        {
                            Key = r.Segmentpk,
                            Display = r.Name.ToString()
                        });
                    }
                }

                tmpWk.DropDownList2 = new SelectList(list2, "Key", "Display");

                return View("WkSeg", tmpWk);
            }

            else
            {
                return View("Index");
            }
        }
    }
}