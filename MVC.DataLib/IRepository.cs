using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace MVC.DataLib
{
    public partial interface IRepository<T> where T :class
    {
        T GetById(object id);
        void Add(T entity);

        void Add(IEnumerable<T> entities);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

        void Update(T entity);

        void Upadte(IEnumerable<T> entities);

        IQueryable<T> Table { get; }

        IList<TElemet> ExecuteStoresProcedureList<TElemet>(string commandText, params object[] parameter) where TElemet : class;

        IEnumerable<TElemet> SqlQuery<TElemet>(string sql, params object[] parameter);

        int ExecuteSqlCommand(string sql,params object [] parameter);
    }
}