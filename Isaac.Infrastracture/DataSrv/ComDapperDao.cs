using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;

namespace Isaac.Infrastracture.DataSrv
{
    public class ComDapperDao<T> : DapperDataSrv<T>
        where T : class
    {
        public override T FindBy<TId>(TId id, bool useMasterDb = false)
        {
            using (var db = Db) return db.Get<T>(id);
        }

        public override int Insert(T t)
        {
            using (var db = Db) return db.Insert(t);
        }

        public override void Insert(IEnumerable<T> t)
        {
            using (var db = Db)
            {
                try
                {
                    db.BeginTransaction();
                    db.Insert(t);
                    db.Commit();
                }
                catch (Exception ex)
                {
                    db.Rollback();
                    throw new DataException("批量插入数据时发生错误！", ex);
                }
            }
        }

        public override bool Update(T t)
        {
            using (var db = Db) return db.Update(t);
        }

        public override bool Delete(T t)
        {
            using (var db = Db) return db.Delete(t);

        }

        protected override IDatabase Db { get { return null; } }
    }
}
