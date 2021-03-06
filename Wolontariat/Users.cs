﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wolontariat
{
    /// <summary>
    /// The class responsible for the User type object. Attributes of this class are equivalent to the attributes of 
    /// the Users table in the database. 
    /// The data downloaded from the Users table is stored using the list of objects of the Users class.
    /// obiektów klasy Users.
    /// </summary>
    public class Users
    {
        public int id;
        public string nickname;
        public string password;
        public string pesel;
        public string email;
        public string telephone;
        public string name;
        public string surname;
        public DateTime birth_date;
        public string sex;
        public string type;

        public Users(SqlDataReader dr)
        {
            id = dr.GetInt32(0);
            nickname = dr.GetString(1);
            password = dr.GetString(2);
            pesel = dr.GetString(3);
            email = dr.GetString(4);
            telephone = dr.GetString(5);
            name = dr.GetString(6);
            surname = dr.GetString(7);
            birth_date = dr.GetDateTime(8);
            sex = dr.GetString(9);
            type = dr.GetString(10);
        }

    }

    

}