using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ThuVienQG.DAO
{
    public class MySQL
    {
        //Data Source = DESKTOP - 3DQNB33\TVHUY;Initial Catalog = QuanLyThuVien; Integrated Security = True
        private static string datasource = "";
        private static string database = "";
        private static SqlConnection conn = null;
        //private static string root = "";
        //private static string passwd = "";
        public static void GetConnec()
        {
            try
            {
                ReadConfig();
                string connsrt = GetConnecString();
                conn = new SqlConnection(connsrt);
            } catch (SqlException e)
            {
                throw e;
            } catch (FileNotFoundException e)
            {
                throw e;
            }

        }
        public static void Open()
        {
            if (conn == null)
                GetConnec();
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        public static void Close()
        {
            if ((conn != null) && (conn.State == ConnectionState.Open))
                conn.Close();
        }
        public static void DisConnec()
        {
            conn.Dispose();
            conn = null;
        }
        public static SqlDataReader ExecuteSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteReader();
        }
        public static int ExecuteNonSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();
        }
        public static object ExecuteScalar(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteScalar();
        }
        private static void ReadConfig()
        {
            try
            {
                StreamReader myFile = File.OpenText("root.conf");
                string buff;
                while ((buff = myFile.ReadLine()) != null)
                {
                    buff = buff.TrimStart(' ', '\t');
                    int len = buff.IndexOf('#');
                    if (len > -1)
                        buff = buff.Substring(0, len);
                    int i = buff.IndexOf('=');
                    if (buff.StartsWith("Data Source"))
                    {
                        buff = buff.Substring(i + 1);
                        buff = buff.TrimStart(' ', '\t').TrimEnd(' ', '\t');
                        datasource = buff;
                        continue;
                    }
                    if (buff.StartsWith("Initial Catalog"))
                    {
                        buff = buff.Substring(i + 1);
                        buff = buff.TrimStart(' ', '\t').TrimEnd(' ', '\t');
                        database = buff;
                        continue;
                    }
                }
            } catch(FileNotFoundException e)
            {
                throw e;
            }
        }
        private static string GetConnecString()
        {
            return "Data Source=" + datasource + ";Initial Catalog=" + database + ";Integrated Security=True";
        }
    }
}
