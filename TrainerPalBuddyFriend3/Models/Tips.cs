using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TrainerPalBuddyFriend3 {
    
    public class Tips {
        public virtual int Tippk { get; set; }
        public virtual Types Types { get; set; }
        public virtual string Tipid { get; set; }
        public virtual string Text { get; set; }
        public virtual int Custom { get; set; }
        public virtual SelectList DropDownList { get; set; }
    }
}