using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.API.Models
{
    public class ReservationRepository:IReservationRepository
    {
        #region Data
         private List<Reservation> _data = new List<Reservation> { 
            new Reservation {ReservationId = 1,  ClientName = "Adam",  
                Location = "London"}, 
            new Reservation {ReservationId = 2,  ClientName = "Steve",  
                Location = "New York"},new Reservation {ReservationId = 3,  ClientName = "Jacqui",  
                Location = "Paris"}, 
        };
        #endregion
        public IEnumerable<Reservation> GetAll()
        {
            return _data;
        }

        public Reservation Get(int id)
        {
            return _data.FirstOrDefault(x => x.ReservationId==id);
        }

        public Reservation Add(Reservation item)
        {
            item.ReservationId = _data.Count + 1;
            _data.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            var match = Get(id);
            _data.Remove(match);
        }

        public bool Update(Reservation item)
        {
            var match = Get(item.ReservationId);
            if (match != null)
            {
                match.ClientName = item.ClientName;
                match.Location = item.Location;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}