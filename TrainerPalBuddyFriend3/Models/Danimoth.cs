using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainerPalBuddyFriend3
{
    public class Raszagal
    {
        public Wkseg rWkseg;
        public Tips rTip;
    }

    public class Danimoth
    {
        public Danimoth() { }
        public virtual Gateway SelectedWorkout { get; set; }
        public List<Raszagal> Dts { get; set; }
        public virtual SelectList DropDownList1 { get; set; }
    }
}