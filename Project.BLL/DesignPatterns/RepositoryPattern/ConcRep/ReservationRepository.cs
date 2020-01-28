using Project.BLL.DesignPatterns.RepositoryPattern.BaseRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.RepositoryPattern.ConcRep
{
    public class ReservationRepository:BaseRepository<Reservation>
    {
        public void Update(Reservation item)
        {
            Reservation guncellenecek = FirstOrDefault(x=> x.CustomerID == item.CustomerID && x.RoomID == item.RoomID);
            item.Status = MODEL.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            db.Entry(guncellenecek).CurrentValues.SetValues(item);
            Save();
        }
    }
}
