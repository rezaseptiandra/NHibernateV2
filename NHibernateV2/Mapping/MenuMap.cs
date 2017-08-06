using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernateV2.Models;


namespace NHibernateV2.Mappings
{


    public class MenuMap : ClassMapping<Menu>
    {

        public MenuMap()
        {
            Schema("modulattendance");
            Lazy(true);
            Id(x => x.Menuid, map => map.Generator(Generators.Assigned));
            Property(x => x.Menudesc);
            Property(x => x.Url);
            Property(x => x.Visibility);
        }
    }
}
