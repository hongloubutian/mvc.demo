
using System;
using System.Collections.Generic;
using System.Linq;
using MVC.Model;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

namespace MVC.DataLib
{
    public class PersonDao
    {
        private readonly IRepository<PersonModel> _repository = new Repository<PersonModel>();
        public void Add(PersonModel model)
        {
            _repository.Add(model);
        }

        public void Delete(PersonModel model)
        {
            _repository.Delete(model);
        }

        public PersonModel GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public int LoginSuccess(string username, string userpwd, out string personid)
        {
            //object[] parameters = {
            //    new SqlParameter("@UserName",username), 
            //    new SqlParameter("@UserPwd",userpwd)
            //};
                       
            //string sql = "SELECT * FROM dbo.PersonInfo WHERE UserName=@UserName and UserPwd=@UserPwd";
            //var list = _repository.SqlQuery<PersonModel>(sql, parameters).ToList();


            var list0 = _repository.Table.Where(x => x.UserName == username && x.UserPwd == userpwd).ToList();
            int result = list0.Count;

            string personId = list0.Select(x => x.PersonModelId).FirstOrDefault().ToString();
            personid = personId;
            return result;
        }
    }
}