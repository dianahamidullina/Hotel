using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class Clients
    {
        public string full_name;
        public string status;
        public string room;
        public string check;
        public string departure;
        
        public Clients(string full_name, string status, string room, string check, string departure)
        {
            this.full_name = full_name;
            this.status = status;
            this.room = room;
            this.check = check;
            this.departure = departure;
           
        }
    }
}
