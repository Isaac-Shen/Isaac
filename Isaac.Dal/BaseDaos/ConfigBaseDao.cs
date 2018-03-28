using Autofac;
using DapperExtensions;
using Isaac.Framework.Databases;
using Isaac.Infrastracture.DataSrv;
using Isaac.Infrastracture.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Dal.BaseDaos
{
    public class ConfigBaseDao<T> : ComDapperDao<T>
        where T: class
    {
        protected override IDatabase Db
        {
            get
            {
                return ContainerRef<ILifetimeScope>.GetContainer().Resolve<IsaacConfigDb>();
            }
        }
    }
}
