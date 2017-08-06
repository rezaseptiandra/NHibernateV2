using System;
using System.Text;
using System.Collections.Generic;


namespace NHibernateV2.Models
{

    public class Menu
    {
        public virtual int Menuid { get; set; }
        public virtual string Menudesc { get; set; }
        public virtual string Url { get; set; }
        public virtual string Visibility { get; set; }
    }
}
