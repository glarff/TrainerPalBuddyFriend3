using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TrainerPalBuddyFriend3 {
    
    public class Segments {
        public Segments() { }
        public virtual int Segmentpk { get; set; }
        public virtual Types Types { get; set; }
        public virtual string Segmentid { get; set; }
        public virtual string Name { get; set; }
        public virtual int Intensity { get; set; }
        public virtual bool Customflg { get; set; }
        public virtual SelectList DropDownList { get; set; }
    }

    public class MyListTable
    {
        public int Key { get; set; }
        public string Display { get; set; }
    }
}
