using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wolontariat
{
    public class Announcement
    {
        public int id;
        public int id_user;
        public DateTime post_date;
        public DateTime? end_date;
        public string type_help;
        public string current_status;
        public string title;
        public string content;

        public Announcement(SqlDataReader dr)
        {
            id = dr.GetInt32(0);
            id_user = dr.GetInt32(1);
            post_date = dr.GetDateTime(2);
            if (dr.IsDBNull(3)) end_date = null;
            else end_date = dr.GetDateTime(3);
            type_help = dr.GetString(4);
            current_status = dr.GetString(5);
            title = dr.GetString(6);
            content = dr.GetString(7);
        }
    }
}