using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TrainerPalBuddyFriend3 {
    
    public class Wkseg {
        public virtual int Wksegpk { get; set; }
        public virtual Workouts Workouts { get; set; }
        public virtual Segments Segments { get; set; }
        public virtual int Duration { get; set; }
        public virtual int Sequence { get; set; }
        public virtual SelectList DropDownList { get; set; }
        public virtual SelectList DropDownList2 { get; set; }
    }
}
