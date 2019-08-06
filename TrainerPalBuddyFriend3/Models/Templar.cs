using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TrainerPalBuddyFriend3 {
    
    public class Templar {
        public Templar() { }
        public virtual int Segmentpk { get; set; }
        public virtual Conclave Conclave { get; set; }
        public virtual string Segmentid { get; set; }
        public virtual string Name { get; set; }
        public virtual int Intensity { get; set; }
        public virtual bool Customflg { get; set; }
        public virtual SelectList DDLTypes { get; set; }
    }

    public class Archon
    {
        public int Key { get; set; }
        public string Display { get; set; }
    }
}
