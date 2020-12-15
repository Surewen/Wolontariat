using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wolontariat
{
    
    public class Event_ranking
    {
        public int id;
        public int id_event;
        public int id_user;

        public Event_ranking(SqlDataReader dr)
    {
            id = dr.GetInt32(0);
            id_event = dr.GetInt32(1);
            id_user = dr.GetInt32(2);
    }

}
    
}