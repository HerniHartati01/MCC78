using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.Context
{
    public class MyConnection
    {
        private static readonly string connectionString =
        "Data Source=DESKTOP-T05CUER;Database=db_booking_room;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        public static SqlConnection Get()
        {
            return new SqlConnection(connectionString);
        }
    }
}
