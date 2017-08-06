using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernateV2.Models;


namespace NHibernateV2.Mappings
{


    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Schema("modulattendance");
            Lazy(true);
            Id(x => x.Userid, map => map.Generator(Generators.Assigned));
            Property(x => x.Roleid);
            Property(x => x.Employeeid);
            Property(x => x.Companyid);
            Property(x => x.Password);
        }
    }
}
