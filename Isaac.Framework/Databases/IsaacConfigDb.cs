using DapperExtensions;
using DapperExtensions.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Framework.Databases
{
    public class IsaacConfigDb : Database, IDatabase
    {
        public IsaacConfigDb(IDbConnection connection, ISqlGenerator sqlGenerator)
            : base(connection, sqlGenerator)
        {
        }

        new public void Dispose()
        {
            using (Connection)
            {
                base.Dispose();
            }
        }
    }
}
