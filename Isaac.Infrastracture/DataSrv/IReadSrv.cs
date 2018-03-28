using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Infrastracture.DataSrv
{
    public interface IReadSrv<T>
        where T : class
    {
        T FindBy<TId>(TId id, bool useMasterDb = false);
    }
}
