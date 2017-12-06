using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wolontariat
{
    public class Invitation
    {
        public int id;
        public int id_event;
        public int id_sender;
        public int id_receiver;
        public String title;
        public String content;
        public DateTime post_date;

        public Invitation(SqlDataReader dr)
        {
            id = dr.GetInt32(0);
            id_event = dr.GetInt32(1);
            id_sender = dr.GetInt32(2);
            id_receiver = dr.GetInt32(3);
            title = dr.GetString(4);
            content = dr.GetString(5);
            post_date = dr.GetDateTime(6);
        }
    }
}