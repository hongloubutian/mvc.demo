using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Data;
using System.Data.Entity;
using System.Configuration;
using System.Data.Common;
using System.Linq;

namespace MVC.DataLib
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyContext _context = new MyContext();

        private IDbSet<T> _entities;

        protected virtual IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }

        public virtual T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public virtual void Add(T entity)
        {
            if (entity != null)
            {
                Entities.Add(entity);
                _context.SaveChanges();

            }
            else
                throw new Exception("There is no Entity");
        }

        public virtual void Add(System.Collections.Generic.IEnumerable<T> entities)
        {
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    Entities.Add(entity);
                }
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("There is no Entities");
            }
        }

        public virtual void Delete(T entity)
        {
            if (entity != null)
            {
                Entities.Remove(entity);
                _context.SaveChanges();
            }
            else
                throw new Exception("There is no Entity");
        }

        public virtual void Delete(System.Collections.Generic.IEnumerable<T> entities)
        {
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    Entities.Remove(entity);
                }
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("There is no Entities");
            }
        }

        public virtual void Update(T entity)
        {
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("There is no Entity");
            }
        }

        public void Upadte(System.Collections.Generic.IEnumerable<T> entities)
        {
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    _context.Entry(item).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            else
            {
                throw new Exception("There is no Entities");
            }
        }

        public virtual System.Linq.IQueryable<T> Table
        {
            get { return this.Entities; }
        }

        public virtual IList<TElemet> ExecuteStoresProcedureList<TElemet>(string commandText, params object[] parameter)
            where TElemet : class
        {
            return _context.ExecuteStoresProcedureList<TElemet>(commandText, parameter);
        }

        public virtual IEnumerable<TElemet> SqlQuery<TElemet>(string sql, params object[] parameter)
        {
            return _context.SqlQuery<TElemet>(sql, parameter);
        }

        public virtual int ExecuteSqlCommand(string sql, params object[] parameter)
        {
            return _context.ExecuteSqlCommand(sql, parameter);
        }
    }
}
