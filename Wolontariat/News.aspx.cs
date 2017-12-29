using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wolontariat
{
    public partial class News : System.Web.UI.Page
    {
        SQLDatabase db;
        List<Event> list_events;
        List<Event_count> ranking_amount_events;
        List<Event_ranking> list_event_ranking;
        StringBuilder html;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new SQLDatabase();
            html = new StringBuilder();
            db.Connect();
            list_event_ranking = db.RankingEvents();
            ranking_amount_events = count_joined_user();
            html.Append("<table border = '1'>");
            html.Append("<tr>");
            html.Append("<th>Ilość osób biorących udział</th><th>Dodane przez</th><th>Data dodania</th><th>Data wydarzenia</th><th>Powiązane z ogłoszeniem potrzebującego</th><th>Temat</th>");
            html.Append("</tr>");
            int k = 0;
            for (int i = 0; i < ranking_amount_events.Count; i++)
            {
                for (int j = 0; j < list_events.Count; j++)
                {
                    if (ranking_amount_events.ElementAt(i).id == list_events.ElementAt(j).id) k = j;
                }
                html.Append("<tr>");
                html.Append("<td>" + ranking_amount_events.ElementAt(i).amount + "</td>");
                html.Append("<td>" + db.getNickname_id(list_events.ElementAt(k).id_user) + "</td>");
                html.Append("<td>" + list_events.ElementAt(k).post_date.ToString("yyyy-MM-dd") + "</td>");
                html.Append("<td>" + list_events.ElementAt(k).due_date.ToString("yyyy-MM-dd") + "</td>");
                if (list_events.ElementAt(k).id_announcement.Equals(null)) html.Append("<td>Nie</td>");
                else html.Append("<td>Tak</td>");
                html.Append("<td>" + list_events.ElementAt(k).title + "</td>");
                html.Append("<td>");
                html.Append("<a href=\"Details.aspx?id_e=" + list_events.ElementAt(k).id + "\">Szczegóły</a>");
                html.Append("</td>");
                html.Append("</tr>");
            }
            html.Append("</table>");
            html.Append("<br/><br/>");

            PlaceHolder.Controls.Add(new Literal { Text = html.ToString() });
            db.Disconnect();

        }

        protected List<Event_count> count_joined_user()
        {
            db = new SQLDatabase();
            db.Connect();
            list_events = db.ListEvents();
            List<Event_count> ranking_amount_events2 = new List<Event_count>();

            for (int i = 0; i < list_events.Count; i++)
            {
                ranking_amount_events2.Add(new Event_count(list_events.ElementAt(i).id, db.Count_Events(list_event_ranking, list_events.ElementAt(i).id)));
            }
           ranking_amount_events2.Sort((Event_count x, Event_count y) => y.amount.CompareTo(x.amount));

            /* for (int i = 0; i < ranking_amount_events2.Count; i++)
            {
                for (int j = i; j < ranking_amount_events2.Count; j++)
                {
                    if (ranking_amount_events2.ElementAt(j).amount > ranking_amount_events2.ElementAt(i).amount)
                    {
                        Event_count temp = ranking_amount_events2.ElementAt(i);
                        ranking_amount_events2.Insert(i, ranking_amount_events2.ElementAt(j));
                        ranking_amount_events2.Insert(j, temp);
                    }
                }
            } */
            // db.Disconnect();
            return ranking_amount_events2;
        }

        

    }
}