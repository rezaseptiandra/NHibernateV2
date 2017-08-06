using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernateV2.Models;


namespace NHibernateV2.Mappings
{


    public class RoleMap : ClassMapping<Role>
    {

        public RoleMap()
        {
            Schema("modulattendance");
            Lazy(true);
            Id(x => x.Roleid, map => map.Generator(Generators.Assigned));
            Property(x => x.Roledesc);
        }
    }
}
