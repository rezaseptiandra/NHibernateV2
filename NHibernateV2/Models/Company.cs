using System;
using System.Text;
using System.Collections.Generic;


namespace NHibernateV2.Models
{

    public class Company
    {
        public virtual string Companyid { get; set; }
        public virtual string Companydesc { get; set; }
        public virtual string Industrytype { get; set; }
    }
}
