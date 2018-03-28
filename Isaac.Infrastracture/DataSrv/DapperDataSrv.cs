using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Infrastracture.DataSrv
{
    public abstract class DapperDataSrv<T> : IDataSrv<T>
        where T : class
    {
        public virtual bool Delete(T t)
        {
            return Db.Delete(t);
        }

        public virtual T FindBy<TId>(TId id, bool useMasterDb = false)
        {
            return Db.Get<T>(id);
        }

        public virtual int Insert(T t)
        {
            return Db.Insert(t);
        }

        public virtual void Insert(IEnumerable<T> t)
        {
            try
            {
                Db.BeginTransaction();
                Db.Insert(t);
                Db.Commit();
            }
            catch (Exception exp)
            {
                Db.Rollback();
                throw new DataException("批量插入发生错误！", exp);
            }
        }

        public virtual bool Update(T t)
        {
            return Db.Update(t);
        }

        protected abstract IDatabase Db { get; }
    }
}
