using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernateV2.Models;


namespace NHibernateV2.Mappings
{


    public class CompanyMap : ClassMapping<Company>
    {

        public CompanyMap()
        {
            Schema("modulattendance");
            Lazy(true);
            Id(x => x.Companyid, map => map.Generator(Generators.Assigned));
            Property(x => x.Companydesc);
            Property(x => x.Industrytype);
        }
    }
}
