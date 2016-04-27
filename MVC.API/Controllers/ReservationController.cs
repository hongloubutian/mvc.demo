using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC.API.Models;

namespace MVC.API.Controllers
{
    public class ReservationController : ApiController
    {
       private readonly  IReservationRepository _repository=new ReservationRepository();

        public IEnumerable<Reservation> GetAll()
        {
            return _repository.GetAll();
        }

        public Reservation Get(int id)
        {
            return _repository.Get(id);
        }

        public Reservation Add(Reservation item)
        {
            return _repository.Add(item);
        }

        public void Remove(int id)
        {
             _repository.Remove(id);
        }

        public bool Update(Reservation item)
        {
            return _repository.Update(item);
        }
    }
}
