using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using MVC.Model;
namespace MVC.DataLib
{
    public class MyContext:DbContext
    {
        public MyContext() : base("MyContext")
        {
        }

        public DbSet<PersonModel> PersonInfo { get; set; }

        public DbSet<BookMark> BookMark { get; set; }

        public virtual IList<T> ExecuteStoresProcedureList<T>(string commandText, params object[] parameters) where T : class
        {
            if (parameters != null && parameters.Length > 0)
            {
                for (int i = 0; i <= parameters.Length - 1; i++)
                {
                    var p = parameters[i] as DbParameter;
                    if (p == null)
                        throw new Exception("Not support parameter type");

                    commandText += i == 0 ? " " : ", ";

                    commandText += "@" + p.ParameterName;
                    if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                    {
                        //output parameter
                        commandText += " output";
                    }
                }
            }

            var result = this.Database.SqlQuery<T>(commandText, parameters).ToList();
            return result;
        }

        public virtual IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<T>(sql, parameters);
        }

        public virtual int ExecuteSqlCommand(string sql, params object[] parameter)
        {
            return this.Database.ExecuteSqlCommand(sql, parameter);
        }
    }
}