using System;
using System.Collections.Generic;
using System.Linq;
using MVC.Model;


namespace MVC.DataLib
{
   public  class BookDao
    {
       private readonly IRepository<BookMark> _repository = new Repository<BookMark>();

       public void Add(BookMark model)
       {
           _repository.Add(model);
       }

       public void Delete(BookMark model)
       {
           _repository.Delete(model);
       }

       public BookMark GetById(Guid id)
       {
           return _repository.GetById(id);
       }

       public List<BookMark> GetlistList()
       {
           return _repository.Table.ToList();
       }

       public void Update(BookMark model)
       {
           _repository.Update(model); 
       }
    }
}
