using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TrainerPalBuddyFriend3 {

    public class Prophecy
    {
        public Prophecy() { }
        public virtual int Tippk { get; set; }
        public virtual Conclave Conclave { get; set; }
        public virtual string Tipid { get; set; }
        public virtual string Text { get; set; }
        public virtual bool Customflg { get; set; }
        public virtual SelectList DDLTypes { get; set; }
    }
}
