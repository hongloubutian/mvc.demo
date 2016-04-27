using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC.API.Models
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();
        Reservation Get(int id);
        Reservation Add(Reservation item);
        void Remove(int id);
        bool Update(Reservation item);
    }
}
