using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wolontariat
{
    public class Event
    {
        public int id;
        public int? id_announcement;
        public int id_user;
        public DateTime post_date;
        public DateTime due_date;
        public String title;
        public String content;

        public Event(SqlDataReader dr)
        {
            id = dr.GetInt32(0);
            if (dr.IsDBNull(1)) id_announcement = null;
            else id_announcement = dr.GetInt32(1);
            id_user = dr.GetInt32(2);
            post_date = dr.GetDateTime(3);
            due_date = dr.GetDateTime(4);
            title = dr.GetString(5);
            content = dr.GetString(6);
        }


    }
}