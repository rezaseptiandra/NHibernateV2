using System;
using System.Text;
using System.Collections.Generic;


namespace NHibernateV2.Models
{

    public class User
    {
        public virtual string Userid { get; set; }
        public virtual string Roleid { get; set; }
        public virtual string Employeeid { get; set; }
        public virtual string Companyid { get; set; }
        public virtual string Password { get; set; }
    }
}
