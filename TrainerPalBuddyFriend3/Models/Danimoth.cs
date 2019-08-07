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
        public virtual Warpgate rWkseg { get; set; }
        public virtual Prophecy rTip { get; set; }
        public virtual string rSegmentName { get; set; }
    }

    public class Danimoth
    {
        public Danimoth() { }
        public virtual string dWorkoutName { get; set; }
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