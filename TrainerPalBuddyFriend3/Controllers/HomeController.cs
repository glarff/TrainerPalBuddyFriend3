using NHibernate;
using System;
using System.Data;
using System.Web.Mvc;
using System.IO;
using System.Collections.Generic;
using NHibernate.Linq;
using System.Linq;
using NHibernate.Transform;
using System.Linq.Expressions;
using NHibernate.Criterion;

namespace TrainerPalBuddyFriend3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Aiur()
        {

            return View();
        }

        public ActionResult Conclave()
        {
            // Get data for existing Types and pass to View
            using (ISession _S = MvcApplication.SF.GetCurrentSession())
            {
                Conclave clv = null;

                var conclaveList = _S.QueryOver(() => clv)
                    .SelectList(l => l
                        .Select(x => x.Typepk).WithAlias(() => clv.Typepk)
                        .Select(x => x.Typeid).WithAlias(() => clv.Typeid)
                        .Select(x => x.Name).WithAlias(() => clv.Name)
                        .Select(x => x.Customflg).WithAlias(() => clv.Customflg)
                    )
                    .TransformUsing(Transformers.AliasToBean<Conclave>())
                    .List<Conclave>();

                return View(conclaveList);
            }
        }

        public ActionResult ConclaveForm(List<Conclave> newList)
        {
            if (ModelState.IsValid)
            {
                // Process submission data and return to Home
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    // Get existing Types 
                    Conclave clv = null;

                    var oldList = _S.QueryOver(() => clv)
                        .SelectList(l => l
                            .Select(x => x.Typepk).WithAlias(() => clv.Typepk)
                        )
                        .TransformUsing(Transformers.AliasToBean<Conclave>())
                        .List<Conclave>();

                    // Compare new and old Lists
                    foreach (var r in newList)
                    {
                        // updates
                        if (oldList.Any(p => p.Typepk == r.Typepk))
                        {
                            var persistentType = _S.Load<Conclave>(r.Typepk);
                            persistentType.Typeid = r.Typeid;
                            persistentType.Name = r.Name;
                            persistentType.Customflg = r.Customflg;

                            _S.Save(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }

                        // inserts
                        else if (r.Typepk == -1)
                        {
                            var persistentType = new Conclave
                            {
                                Typeid = r.Typeid,
                                Name = r.Name,
                                Customflg = r.Customflg
                            };

                            _S.Save(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }
                    }

                    // deletions
                    foreach (var x in oldList)
                    {
                        if (!newList.Any(p => p.Typepk == x.Typepk))
                        {
                            var persistentType = _S.Load<Conclave>(x.Typepk);
                            _S.Delete(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }
                    }
                }

                ViewBag.onSuccess_Message = "Types updated successfully.";
                return View("Index");
            }

            else
            {
                ViewBag.onSuccess_Message = "You must construct additional Pylons.";
                return View("Index");
            }
        }

        public ActionResult Gateway()
        {
            // Get data for existing Workouts and pass to View
            using (ISession _S = MvcApplication.SF.GetCurrentSession())
            {
                Gateway gw = null;

                var gatewayList = _S.QueryOver(() => gw)
                    .SelectList(l => l
                        .Select(x => x.Workoutpk).WithAlias(() => gw.Workoutpk)
                        .Select(x => x.Workoutid).WithAlias(() => gw.Workoutid)
                        .Select(x => x.Name).WithAlias(() => gw.Name)
                        .Select(x => x.Description).WithAlias(() => gw.Description)
                        .Select(x => x.Customflg).WithAlias(() => gw.Customflg)
                    )
                    .TransformUsing(Transformers.AliasToBean<Gateway>())
                    .List<Gateway>();

                return View(gatewayList);
            }
        }

        public ActionResult GatewayForm(List<Gateway> newList)
        {
            if (ModelState.IsValid)
            {
                // Process submission data and return to Home
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    // Get existing Workouts
                    Gateway gw = null;

                    var oldList = _S.QueryOver(() => gw)
                        .SelectList(l => l
                            .Select(x => x.Workoutpk).WithAlias(() => gw.Workoutpk)
                        )
                        .TransformUsing(Transformers.AliasToBean<Gateway>())
                        .List<Gateway>();

                    // Compare new and old Lists
                    foreach (var r in newList)
                    {
                        // updates
                        if (oldList.Any(p => p.Workoutpk == r.Workoutpk))
                        {
                            var persistentType = _S.Load<Gateway>(r.Workoutpk);
                            persistentType.Workoutid = r.Workoutid;
                            persistentType.Name = r.Name;
                            persistentType.Description = r.Description;
                            persistentType.Customflg = r.Customflg;

                            _S.Save(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }

                        // inserts
                        else if (r.Workoutpk == -1)
                        {
                            var persistentType = new Gateway
                            {
                                Workoutid = r.Workoutid,
                                Name = r.Name,
                                Description = r.Description,
                                Customflg = r.Customflg
                            };

                            _S.Save(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }
                    }

                    // deletions
                    foreach (var x in oldList)
                    {
                        if (!newList.Any(p => p.Workoutpk == x.Workoutpk))
                        {
                            var persistentType = _S.Load<Gateway>(x.Workoutpk);
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

        public ActionResult Templar()
        {
            // Get data for existing Workouts
            using (ISession _S = MvcApplication.SF.GetCurrentSession())
            {
                // CTRL + Select Templar
                Templar tmp = null;
                
                var tmpList = _S.QueryOver(() => tmp)
                    .SelectList(l => l
                        .Select(x => x.Segmentpk).WithAlias(() => tmp.Segmentpk)
                        .Select(x => x.Segmentid).WithAlias(() => tmp.Segmentid)
                        .Select(x => x.Name).WithAlias(() => tmp.Name)
                        .Select(x => x.Conclave).WithAlias(() => tmp.Conclave)
                        .Select(x => x.Intensity).WithAlias(() => tmp.Intensity)
                        .Select(x => x.Customflg).WithAlias(() => tmp.Customflg)
                    )
                    .TransformUsing(Transformers.AliasToBean<Templar>())
                    .List<Templar>();

                // Summon the Conclave
                Conclave clv = null;

                var typeList = _S.QueryOver(() => clv)
                    .SelectList(l => l
                        .Select(x => x.Typepk).WithAlias(() => clv.Typepk)
                        .Select(x => x.Name).WithAlias(() => clv.Name)
                    )
                    .TransformUsing(Transformers.AliasToBean<Conclave>())
                    .List<Conclave>();

                // Morph Archons
                var archList = new List<Archon>();

                foreach (var r in typeList)
                {
                    archList.Add(new Archon
                    {
                        Key = r.Typepk,
                        Display = r.Name.ToString()
                    });
                }

                foreach (var s in tmpList)
                {
                    s.DDLTypes = new SelectList(archList, "Key", "Display", s.Conclave.Typepk);
                }

                return View(tmpList);
            }
        }

        public ActionResult TemplarForm(List<Templar> newList)
        {
            if (ModelState.IsValid)
            {
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Templar tmp = null;

                    var oldList = _S.QueryOver(() => tmp)
                        .SelectList(l => l
                            .Select(x => x.Segmentpk).WithAlias(() => tmp.Segmentpk)
                        )
                        .TransformUsing(Transformers.AliasToBean<Templar>())
                        .List<Templar>();

                    foreach (var q in newList)
                    {
                        //updates
                        if (oldList.Any(p => p.Segmentpk == q.Segmentpk))
                        {
                            Templar persistentType = _S.Load<Templar>(q.Segmentpk);

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
                            Templar persistentType = new Templar
                            {
                                Segmentid = q.Segmentid,
                                Name = q.Name,
                                Conclave = q.Conclave,
                                Intensity = q.Intensity,
                                Customflg = q.Customflg
                            };

                            _S.Save(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }
                    }

                    //deletions
                    foreach (var x in oldList)
                    {
                        if (!newList.Any(p => p.Segmentpk == x.Segmentpk))
                        {
                            var persistentType = _S.Load<Templar>(x.Segmentpk);

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
    
        public ActionResult Prophecy()
        {
            // Get data for existing Workouts
            using (ISession _S = MvcApplication.SF.GetCurrentSession())
            {
                Prophecy phy = null;

                IList<Prophecy> phyList = _S.QueryOver(() => phy)
                    .SelectList(l => l
                        .Select(x => x.Tippk).WithAlias(() => phy.Tippk)
                        .Select(x => x.Tipid).WithAlias(() => phy.Tipid)
                        .Select(x => x.Text).WithAlias(() => phy.Text)
                        .Select(x => x.Conclave).WithAlias(() => phy.Conclave)
                        .Select(x => x.Customflg).WithAlias(() => phy.Customflg)
                    )
                    .TransformUsing(Transformers.AliasToBean<Prophecy>())
                    .List<Prophecy>();

                List<Archon> archList = new List<Archon>();

                Conclave clv = null;

                IList<Conclave> typeList = _S.QueryOver(() => clv)
                    .SelectList(l => l
                        .Select(x => x.Typepk).WithAlias(() => clv.Typepk)
                        .Select(x => x.Name).WithAlias(() => clv.Name)
                    )
                    .TransformUsing(Transformers.AliasToBean<Conclave>())
                    .List<Conclave>();

                foreach (Conclave r in typeList)
                {
                    archList.Add(new Archon
                    {
                        Key = r.Typepk,
                        Display = r.Name.ToString()
                    });
                }

                foreach (Prophecy s in phyList)
                {
                    s.DDLTypes = new SelectList(archList, "Key", "Display", s.Conclave.Typepk);
                }

                return View(phyList);
            }
        }

        public ActionResult ProphecyForm(List<Prophecy> newList)
        {
            if (ModelState.IsValid)
            {
                // Get existing Conclave
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Prophecy phy = null;

                    var oldList = _S.QueryOver(() => phy)
                        .SelectList(l => l
                            .Select(x => x.Tippk).WithAlias(() => phy.Tippk)
                        )
                        .TransformUsing(Transformers.AliasToBean<Prophecy>())
                        .List<Prophecy>();

                    foreach (var q in newList)
                    {
                        //updates
                        if (oldList.Any(p => p.Tippk == q.Tippk))
                        {
                            var persistentType = _S.Load<Prophecy>(q.Tippk);

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
                            var persistentType = new Prophecy();

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
                    foreach (var x in oldList)
                    {
                        if (!newList.Any(p => p.Tippk == x.Tippk))
                        {
                            var persistentType = _S.Load<Prophecy>(x.Tippk);

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

        public ActionResult WarpIn1()
        {
            if (ModelState.IsValid)
            {
                Warpgate d = new Warpgate();
                List<Archon> archList = new List<Archon>();

                // Get data for existing Workouts
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Gateway wk = null;

                    var wkList = _S.QueryOver(() => wk)
                        .SelectList(l => l
                            .Select(x => x.Workoutpk).WithAlias(() => wk.Workoutpk)
                            .Select(x => x.Name).WithAlias(() => wk.Name)
                        )
                        .TransformUsing(Transformers.AliasToBean<Gateway>())
                        .List<Gateway>();

                    foreach (var r in wkList)
                    {
                        archList.Add(new Archon
                        {
                            Key = r.Workoutpk,
                            Display = r.Name.ToString()
                        });
                    }

                    d.DDLWorkouts = new SelectList(archList, "Key", "Display");
                }

                return View(d);
            }

            else
            {
                return View("Index");
            }
        }

        public ActionResult WarpIn1Form(Warpgate d)
        {
            int g = d.Gateway.Workoutpk;

            if (ModelState.IsValid)
            {
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    // Get segment list
                    Templar sg = null;

                    IList<Templar> sgList = _S.QueryOver(() => sg)
                    .SelectList(l => l
                        .Select(x => x.Segmentpk).WithAlias(() => sg.Segmentpk)
                        .Select(x => x.Name).WithAlias(() => sg.Name)
                    )
                    .TransformUsing(Transformers.AliasToBean<Templar>())
                    .List<Templar>();

                    List<Archon> list2 = new List<Archon>();

                    foreach (Templar r in sgList)
                    {
                        list2.Add(new Archon
                        {
                            Key = r.Segmentpk,
                            Display = r.Name.ToString()
                        });
                    }

                    // Get data for existing Wksegs
                    Warpgate wks = null;

                    IList<Warpgate> wksList = _S.QueryOver(() => wks)
                        .SelectList(l => l
                            .Select(x => x.Wksegpk).WithAlias(() => wks.Wksegpk)
                            .Select(x => x.Gateway).WithAlias(() => wks.Gateway)
                            .Select(x => x.Templar).WithAlias(() => wks.Templar)
                            .Select(x => x.Duration).WithAlias(() => wks.Duration)
                            .Select(x => x.Sequence).WithAlias(() => wks.Sequence)
                            )
                        .Where(x => x.Gateway.Workoutpk == g)
                        .TransformUsing(Transformers.AliasToBean<Warpgate>())
                        .List<Warpgate>();

                    List<Warpgate> h = new List<Warpgate>();

                    foreach (Warpgate z in wksList)
                    {
                        Warpgate rWksg = new Warpgate
                        {
                            Wksegpk = z.Wksegpk,
                            Gateway = z.Gateway,
                            Templar = z.Templar,
                            Duration = z.Duration,
                            Sequence = z.Sequence,
                            DDLSegments = new SelectList(list2, "Key", "Display", z.Templar.Segmentpk)
                        };

                        h.Add(rWksg);
                    }

                    return View("Assimilation", h);
                }
            }

            else
            {
                return View("Index");
            }
        }

        public ActionResult Assimilation()
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
      
        public ActionResult AssimilationForm(List<Warpgate> d)
        {
            if (ModelState.IsValid)
            {
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Warpgate tp = null;

                    IList<Warpgate> oldList = _S.QueryOver(() => tp)
                        .SelectList(l => l
                            .Select(x => x.Wksegpk).WithAlias(() => tp.Wksegpk)
                        )
                        .TransformUsing(Transformers.AliasToBean<Warpgate>())
                        .List<Warpgate>();

                    foreach (Warpgate q in d)
                    {
                        //updates
                        if (oldList.Any(p => p.Wksegpk == q.Wksegpk))
                            {
                            Warpgate persistentType = _S.Load<Warpgate>(q.Wksegpk);

                            persistentType.Gateway = q.Gateway;
                            persistentType.Templar = q.Templar;
                            persistentType.Duration = q.Duration;
                            persistentType.Sequence = q.Sequence;

                            _S.Save(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }

                        //inserts
                        else if (q.Wksegpk == -1)
                        {
                            Warpgate persistentType = new Warpgate
                            {
                                Gateway = q.Gateway,
                                Templar = q.Templar,
                                Duration = q.Duration,
                                Sequence = q.Sequence
                            };

                            _S.Save(persistentType);
                            _S.Flush();
                            _S.Clear();
                        }
                    }

                    //deletions
                    foreach (Warpgate x in oldList)
                    {
                        if (!d.Any(p => p.Wksegpk == x.Wksegpk))
                        {
                            Warpgate persistentType = _S.Load<Warpgate>(x);

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

        public ActionResult WarpIn2()
        {
            if (ModelState.IsValid)
            {
                Warpgate d = new Warpgate();

                List<Archon> list = new List<Archon>();

                // Get data for existing Workouts
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    Gateway wk = null;

                    IList<Gateway> wkList = _S.QueryOver(() => wk)
                        .SelectList(l => l
                            .Select(x => x.Workoutpk).WithAlias(() => wk.Workoutpk)
                            .Select(x => x.Name).WithAlias(() => wk.Name)
                        )
                        .TransformUsing(Transformers.AliasToBean<Gateway>())
                        .List<Gateway>();


                    foreach (Gateway r in wkList)
                    {
                        list.Add(new Archon
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

        public ActionResult WarpIn2Form(Gateway w)
        {
            if (ModelState.IsValid)
            {
                using (ISession _S = MvcApplication.SF.GetCurrentSession())
                {
                    // Get Workout
                    Gateway gw = _S.Query<Gateway>()
                        .Where(x => x.Workoutpk == w.Workoutpk)
                        .SingleOrDefault();

                    Danimoth d = new Danimoth
                    {
                        dWorkoutName = gw.Name,
                        Dts = new List<Raszagal>()
                    };

                    // Get data for existing Wksegs
                    Warpgate wks = null;

                    IList<Warpgate> wksList = _S.QueryOver(() => wks)
                        .SelectList(l => l
                            .Select(x => x.Wksegpk).WithAlias(() => wks.Wksegpk)
                            .Select(x => x.Gateway).WithAlias(() => wks.Gateway)
                            .Select(x => x.Templar).WithAlias(() => wks.Templar)
                            .Select(x => x.Duration).WithAlias(() => wks.Duration)
                            .Select(x => x.Sequence).WithAlias(() => wks.Sequence)
                            )
                        .Where(x => x.Gateway.Workoutpk == w.Workoutpk)
                        .TransformUsing(Transformers.AliasToBean<Warpgate>())
                        .List<Warpgate>();

                    // DT Rush
                    foreach (Warpgate z in wksList)
                    {
                        Templar rSeg = _S.Query<Templar>()
                            .Where(x => x.Segmentpk == z.Templar.Segmentpk)
                            .SingleOrDefault();

                        Conclave rTyp = _S.Query<Conclave>()
                             .Where(x => x.Typepk == rSeg.Conclave.Typepk)
                             .SingleOrDefault();

                        // Get a random tip for that type
                        ICriteria criteria = _S
                          .CreateCriteria(typeof(Prophecy))
                          .Add(Restrictions.Eq("TypeFK", rTyp.Typepk))
                          .AddOrder(new RandomOrder())
                          .SetMaxResults(1);

                        Raszagal rz = new Raszagal
                        {
                            rSegmentName = rSeg.Name,
                            rTip = criteria.UniqueResult<Prophecy>(),
                            rWkseg = new Warpgate
                            {
                                Duration = z.Duration,
                                Sequence = z.Sequence
                            }
                        };

                        d.Dts.Add(rz);
                    }

                    return View("Aiur", d);
                    
                }
            }
            else
            {
                return View("Index");
            }
        }
    }
}
