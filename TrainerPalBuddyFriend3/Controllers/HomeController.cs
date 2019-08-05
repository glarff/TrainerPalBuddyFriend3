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

        public ActionResult Demo()
        {

            return View();
        }

        public ActionResult Conclave()
        {
            var list = new List<Conclave>();
            // Get data for existing Conclave
            using (ISession _S = MvcApplication.SF.GetCurrentSession())
            {
                Conclave typ = null;

                var typeList = _S.QueryOver<Conclave>(() => typ)
                    .SelectList(l => l
                        .Select(x => x.Typepk).WithAlias(() => typ.Typepk)
                        .Select(x => x.Typeid).WithAlias(() => typ.Typeid)
                        .Select(x => x.Name).WithAlias(() => typ.Name)
                        .Select(x => x.Customflg).WithAlias(() => typ.Customflg)
                    )
                    .TransformUsing(Transformers.AliasToBean<Conclave>())
                    .List<Conclave>();

                foreach (var r in typeList)
                {
                    list.Add(r);
                }
            }
            return View(list);
        }

        public ActionResult Workouts()
        {
            var list = new List<Workouts>();

            // Get data for existing Workouts
            using (ISession _S = MvcApplication.SF.GetCurrentSession())
            {
                Workouts wk = null;

                var wkList = _S.QueryOver<Workouts>(() => wk)
                    .SelectList(l => l
                        .Select(x => x.Workoutpk).WithAlias(() => wk.Workoutpk)
                        .Select(x => x.Workoutid).WithAlias(() => wk.Workoutid)
                        .Select(x => x.Name).WithAlias(() => wk.Name)
                        .Select(x => x.Description).WithAlias(() => wk.Description)
                        .Select(x => x.Customflg).WithAlias(() => wk.Customflg)
                    )
                    .TransformUsing(Transformers.AliasToBean<Workouts>())
                    .List<Workouts>();

                foreach (var r in wkList)
                {
                    list.Add(r);
                }
            }
            return View(list);
        }

        public ActionResult Form3(List<Conclave> newList)
        {
            if (ModelState.IsValid)
            {
                // Get existing Conclave
                var newListPKs = new List<int>();
                var oldListPKs = new List<int>();

                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Conclave typ = null;

                    var oldList = _S.QueryOver<Conclave>(() => typ)
                        .SelectList(l => l
                            .Select(x => x.Typepk).WithAlias(() => typ.Typepk)
                        )
                        .TransformUsing(Transformers.AliasToBean<Conclave>())
                        .List<Conclave>();

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
                            var persistentType = _S.Load<Conclave>(q.Typepk);

                            persistentType.Typeid = q.Typeid;
                            persistentType.Name = q.Name;
                            persistentType.Customflg = q.Customflg;

                            _S.Save(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }

                        //inserts
                        else if (q.Typepk == -1)
                        {
                            var persistentType = new Conclave();

                            persistentType.Typeid = q.Typeid;
                            persistentType.Name = q.Name;
                            persistentType.Customflg = q.Customflg;

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
                            var persistentType = _S.Load<Conclave>(x);

                            _S.Delete(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }
                    }
                }

                ViewBag.onSuccess_Message = "Conclave updated successfully.";

                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Form6(List<Workouts> newList)
        {
            if (ModelState.IsValid)
            {
                // Get existing Conclave
                var newListPKs = new List<int>();
                var oldListPKs = new List<int>();

                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Workouts wk = null;

                    var oldList = _S.QueryOver<Workouts>(() => wk)
                        .SelectList(l => l
                            .Select(x => x.Workoutpk).WithAlias(() => wk.Workoutpk)
                        )
                        .TransformUsing(Transformers.AliasToBean<Workouts>())
                        .List<Workouts>();

                    foreach (var r in oldList)
                    {
                        oldListPKs.Add(r.Workoutpk);
                    }

                    foreach (var r in newList)
                    {
                        newListPKs.Add(r.Workoutpk);
                    }

                    foreach (var q in newList)
                    {
                        //updates
                        if (oldListPKs.Contains(q.Workoutpk))
                        {
                            var persistentType = _S.Load<Workouts>(q.Workoutpk);

                            persistentType.Workoutid = q.Workoutid;
                            persistentType.Name = q.Name;
                            persistentType.Description = q.Description;
                            persistentType.Customflg = q.Customflg;

                            _S.Save(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }

                        //inserts
                        else if (q.Workoutpk == -1)
                        {
                            var persistentType = new Workouts();

                            persistentType.Workoutid = q.Workoutid;
                            persistentType.Name = q.Name;
                            persistentType.Description = q.Description;
                            persistentType.Customflg = q.Customflg;

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
                            var persistentType = _S.Load<Workouts>(x);

                            _S.Delete(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }
                    }
                }

                ViewBag.onSuccess_Message = "Workouts updated successfully.";

                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Segments()
        {
            var list = new List<Segments>();

            // Get data for existing Workouts
            using (ISession _S = MvcApplication.SF.GetCurrentSession())
            {
                Segments sg = null;

                var sgList = _S.QueryOver<Segments>(() => sg)
                    .SelectList(l => l
                        .Select(x => x.Segmentpk).WithAlias(() => sg.Segmentpk)
                        .Select(x => x.Segmentid).WithAlias(() => sg.Segmentid)
                        .Select(x => x.Name).WithAlias(() => sg.Name)
                        .Select(x => x.Conclave).WithAlias(() => sg.Conclave)
                        .Select(x => x.Intensity).WithAlias(() => sg.Intensity)
                        .Select(x => x.Customflg).WithAlias(() => sg.Customflg)
                    )
                    .TransformUsing(Transformers.AliasToBean<Segments>())
                    .List<Segments>();

                foreach (var r in sgList)
                {
                    list.Add(r);
                }

                var list2 = new List<MyListTable>();

                Conclave typ = null;

                var typeList = _S.QueryOver<Conclave>(() => typ)
                    .SelectList(l => l
                        .Select(x => x.Typepk).WithAlias(() => typ.Typepk)
                        .Select(x => x.Name).WithAlias(() => typ.Name)
                    )
                    .TransformUsing(Transformers.AliasToBean<Conclave>())
                    .List<Conclave>();

                foreach (var r in typeList)
                {
                    list2.Add(new MyListTable
                    {
                        Key = r.Typepk,
                        Display = r.Name.ToString()
                    });
                }

                foreach (var s in list)
                {
                    s.DropDownList = new SelectList(list2, "Key", "Display", s.Conclave.Typepk);
                }
            }

            return View(list);
        }

        public ActionResult Form4(List<Segments> newList)
        {
            if (ModelState.IsValid)
            {
                // Get existing Conclave
                var newListPKs = new List<int>();
                var oldListPKs = new List<int>();

                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Segments sg = null;

                    var oldList = _S.QueryOver<Segments>(() => sg)
                        .SelectList(l => l
                            .Select(x => x.Segmentpk).WithAlias(() => sg.Segmentpk)
                        )
                        .TransformUsing(Transformers.AliasToBean<Segments>())
                        .List<Segments>();

                    foreach (var r in oldList)
                    {
                        oldListPKs.Add(r.Segmentpk);
                    }

                    foreach (var r in newList)
                    {
                        newListPKs.Add(r.Segmentpk);
                    }

                    foreach (var q in newList)
                    {
                        //updates
                        if (oldListPKs.Contains(q.Segmentpk))
                        {
                            var persistentType = _S.Load<Segments>(q.Segmentpk);

                            persistentType.Segmentid = q.Segmentid;
                            persistentType.Name = q.Name;
                            persistentType.Conclave = q.Conclave;
                            persistentType.Intensity = q.Intensity;
                            persistentType.Customflg = q.Customflg;

                            _S.Save(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }

                        //inserts
                        else if (q.Segmentpk == -1)
                        {
                            var persistentType = new Segments();

                            persistentType.Segmentid = q.Segmentid;
                            persistentType.Name = q.Name;
                            persistentType.Conclave = q.Conclave;
                            persistentType.Intensity = q.Intensity;
                            persistentType.Customflg = q.Customflg;

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
                            var persistentType = _S.Load<Segments>(x);

                            _S.Delete(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }
                    }
                }

                ViewBag.onSuccess_Message = "Segments updated successfully.";

                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }
    

        public ActionResult Tips()
        {
            var list = new List<Tips>();

            // Get data for existing Workouts
            using (ISession _S = MvcApplication.SF.GetCurrentSession())
            {
                Tips tp = null;

                var tpList = _S.QueryOver<Tips>(() => tp)
                    .SelectList(l => l
                        .Select(x => x.Tippk).WithAlias(() => tp.Tippk)
                        .Select(x => x.Tipid).WithAlias(() => tp.Tipid)
                        .Select(x => x.Text).WithAlias(() => tp.Text)
                        .Select(x => x.Conclave).WithAlias(() => tp.Conclave)
                        .Select(x => x.Customflg).WithAlias(() => tp.Customflg)
                    )
                    .TransformUsing(Transformers.AliasToBean<Tips>())
                    .List<Tips>();

                foreach (var r in tpList)
                {
                    list.Add(r);
                }

                var list2 = new List<MyListTable>();

                Conclave typ = null;

                var typeList = _S.QueryOver<Conclave>(() => typ)
                    .SelectList(l => l
                        .Select(x => x.Typepk).WithAlias(() => typ.Typepk)
                        .Select(x => x.Name).WithAlias(() => typ.Name)
                    )
                    .TransformUsing(Transformers.AliasToBean<Conclave>())
                    .List<Conclave>();

                foreach (var r in typeList)
                {
                    list2.Add(new MyListTable
                    {
                        Key = r.Typepk,
                        Display = r.Name.ToString()
                    });
                }

                foreach (var s in list)
                {
                    s.DropDownList = new SelectList(list2, "Key", "Display", s.Conclave.Typepk);
                }
            }

            return View(list);
        }

        public ActionResult Form5(List<Tips> newList)
        {
            if (ModelState.IsValid)
            {
                // Get existing Conclave
                var newListPKs = new List<int>();
                var oldListPKs = new List<int>();

                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Tips tp = null;

                    var oldList = _S.QueryOver<Tips>(() => tp)
                        .SelectList(l => l
                            .Select(x => x.Tippk).WithAlias(() => tp.Tippk)
                        )
                        .TransformUsing(Transformers.AliasToBean<Tips>())
                        .List<Tips>();

                    foreach (var r in oldList)
                    {
                        oldListPKs.Add(r.Tippk);
                    }

                    foreach (var r in newList)
                    {
                        newListPKs.Add(r.Tippk);
                    }

                    foreach (var q in newList)
                    {
                        //updates
                        if (oldListPKs.Contains(q.Tippk))
                        {
                            var persistentType = _S.Load<Tips>(q.Tippk);

                            persistentType.Tipid = q.Tipid;
                            persistentType.Text = q.Text;
                            persistentType.Conclave = q.Conclave;
                            persistentType.Customflg = q.Customflg;

                            _S.Save(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }

                        //inserts
                        else if (q.Tippk == -1)
                        {
                            var persistentType = new Tips();

                            persistentType.Tipid = q.Tipid;
                            persistentType.Text = q.Text;
                            persistentType.Conclave = q.Conclave;
                            persistentType.Customflg = q.Customflg;

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
                            var persistentType = _S.Load<Tips>(x);

                            _S.Delete(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }
                    }
                }

                ViewBag.onSuccess_Message = "Tips updated successfully.";

                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult SelectWorkout()
        {
            if (ModelState.IsValid)
            {
                var d = new Wkseg();

                var list = new List<MyListTable>();

                // Get data for existing Workouts
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Workouts wk = null;

                    var wkList = _S.QueryOver(() => wk)
                        .SelectList(l => l
                            .Select(x => x.Workoutpk).WithAlias(() => wk.Workoutpk)
                            .Select(x => x.Name).WithAlias(() => wk.Name)
                        )
                        .TransformUsing(Transformers.AliasToBean<Workouts>())
                        .List<Workouts>();


                    foreach (var r in wkList)
                    {
                        list.Add(new MyListTable
                        {
                            Key = r.Workoutpk,
                            Display = r.Name.ToString()
                        });
                    }

                    d.DDLWorkouts = new SelectList(list, "Key", "Display");

                }

                return View(d);
            }

            else
            {
                return View("Index");
            }
        }

        public ActionResult Form7(Wkseg d)
        {
            int g = d.Workouts.Workoutpk;

            if (ModelState.IsValid)
            {
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    // Get segment list
                    Segments sg = null;

                    var sgList = _S.QueryOver(() => sg)
                    .SelectList(l => l
                        .Select(x => x.Segmentpk).WithAlias(() => sg.Segmentpk)
                        .Select(x => x.Name).WithAlias(() => sg.Name)
                    )
                    .TransformUsing(Transformers.AliasToBean<Segments>())
                    .List<Segments>();

                    var list2 = new List<MyListTable>();

                    foreach (var r in sgList)
                    {
                        list2.Add(new MyListTable
                        {
                            Key = r.Segmentpk,
                            Display = r.Name.ToString()
                        });
                    }

                    // Get data for existing Wksegs

                    Wkseg wks = null;

                    var wksList = _S.QueryOver<Wkseg>(() => wks)
                        .SelectList(l => l
                            .Select(x => x.Wksegpk).WithAlias(() => wks.Wksegpk)
                            .Select(x => x.Workouts).WithAlias(() => wks.Workouts)
                            .Select(x => x.Segments).WithAlias(() => wks.Segments)
                            .Select(x => x.Duration).WithAlias(() => wks.Duration)
                            .Select(x => x.Sequence).WithAlias(() => wks.Sequence)
                            )
                        .Where(x => x.Workouts.Workoutpk == g)
                        .TransformUsing(Transformers.AliasToBean<Wkseg>())
                        .List<Wkseg>();

                    var h = new List<Wkseg>();

                    foreach (var z in wksList)
                    {
                        var rWksg = new Wkseg
                        {
                            Wksegpk = z.Wksegpk,
                            Workouts = z.Workouts,
                            Segments = z.Segments,
                            Duration = z.Duration,
                            Sequence = z.Sequence,
                            DDLSegments = new SelectList(list2, "Key", "Display", z.Segments.Segmentpk)
                        };

                        h.Add(rWksg);
                    }


                    return View("BuildWorkout", h);
                }
            }

            else
            {
                return View("Index");
            }
        }


        public ActionResult BuildWorkout()
        {
            if (ModelState.IsValid)
            {
                return View("Index");
            }

            else
            {
                return View("Index");
            }
        }
      

        public ActionResult Form8(List<Wkseg> d)
        {
            if (ModelState.IsValid)
            {
                // Get existing Conclave
                var newListPKs = new List<int>();
                var oldListPKs = new List<int>();

                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Wkseg tp = null;

                    var oldList = _S.QueryOver<Wkseg>(() => tp)
                        .SelectList(l => l
                            .Select(x => x.Wksegpk).WithAlias(() => tp.Wksegpk)
                        )
                        .TransformUsing(Transformers.AliasToBean<Wkseg>())
                        .List<Wkseg>();

                    foreach (var r in oldList)
                    {
                        oldListPKs.Add(r.Wksegpk);
                    }

                    foreach (var z in d)
                    {
                        newListPKs.Add(z.Wksegpk);
                    }

                    foreach (var q in d)
                    {
                        //updates
                        if (oldListPKs.Contains(q.Wksegpk))
                        {
                            var persistentType = _S.Load<Wkseg>(q.Wksegpk);

                            persistentType.Workouts = q.Workouts;
                            persistentType.Segments = q.Segments;
                            persistentType.Duration = q.Duration;
                            persistentType.Sequence = q.Sequence;

                            _S.Save(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }

                        //inserts
                        else if (q.Wksegpk == -1)
                        {
                            var persistentType = new Wkseg();

                            persistentType.Workouts = q.Workouts;
                            persistentType.Segments = q.Segments;
                            persistentType.Duration = q.Duration;
                            persistentType.Sequence = q.Sequence;

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
                            var persistentType = _S.Load<Wkseg>(x);

                            _S.Delete(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }
                    }
                }

                ViewBag.onSuccess_Message = "WkSeg updated successfully.";

                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult SelectWorkout2()
        {
            if (ModelState.IsValid)
            {
                var d = new Wkseg();

                var list = new List<MyListTable>();

                // Get data for existing Workouts
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Workouts wk = null;

                    var wkList = _S.QueryOver(() => wk)
                        .SelectList(l => l
                            .Select(x => x.Workoutpk).WithAlias(() => wk.Workoutpk)
                            .Select(x => x.Name).WithAlias(() => wk.Name)
                        )
                        .TransformUsing(Transformers.AliasToBean<Workouts>())
                        .List<Workouts>();


                    foreach (var r in wkList)
                    {
                        list.Add(new MyListTable
                        {
                            Key = r.Workoutpk,
                            Display = r.Name.ToString()
                        });
                    }

                    d.DDLWorkouts = new SelectList(list, "Key", "Display");

                }

                return View(d);
            }

            else
            {
                return View("Index");
            }
        }

        public ActionResult Form9(Workouts w)
        {
            if (ModelState.IsValid)
            {
                // Summon Danimoth
                var d = new Danimoth();

                // Construct additional pylons
                
                // 


                // Get 

                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }
    }
}
