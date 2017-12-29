using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wolontariat
{
    public class Event_count
    {
        public int id;
        public int amount;

        public Event_count(int id, int amount)
        {
            this.id = id;
            this.amount = amount;
        }

    }
}