using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainerPalBuddyFriend3
{
    public class Raszagal
    {
        public Warpgate rWkseg;
        public Prophecy rTip;
    }

    public class Danimoth
    {
        public Danimoth() { }
        public virtual Gateway SelectedWorkout { get; set; }
        public List<Raszagal> Dts { get; set; }
    }
}