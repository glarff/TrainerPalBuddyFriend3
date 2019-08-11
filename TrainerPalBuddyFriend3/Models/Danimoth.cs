using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainerPalBuddyFriend3
{
    public class Raszagal
    {
        public virtual Warpgate RWkseg { get; set; }
        public virtual Prophecy RTip { get; set; }
        public virtual string RSegmentName { get; set; }
        public virtual int RSegmentIntensity { get; set; }
    }

    public class Danimoth
    {
        public Danimoth() { }
        public virtual string DWorkoutName { get; set; }

        public List<Raszagal> Dts { get; set; }
    }

    public class RandomOrder : Order
    {
        public RandomOrder() : base("", true) { }
        public override SqlString ToSqlString(
            ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            return new SqlString("RAND()");
        }
    }
}