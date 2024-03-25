using System.Data;
using System.Data.SqlClient;

namespace staff_management
{
    internal class LOPDUNGCHUNG
    {
        static string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.net\winform\staff-management\staff-management\NHANVIEN.mdf;Integrated Security=True";
        static SqlConnection con = new SqlConnection(conStr);

        public static DataTable LoadTB(string sql)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            adapter.Fill(dataTable);
            return dataTable;
        }


        public static int CUD(string sql)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static int CAL(string sql)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                result = (int)cmd.ExecuteScalar();
            }
            return result;
        }
    }

}
