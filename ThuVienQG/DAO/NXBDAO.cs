using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ThuVienQG.DTO;

namespace ThuVienQG.DAO
{
    public class NXBDAO
    {
        public static List<NXBDTO> SelecSuppliers()
        {
            string sqlstr = "EXEC dbo.SelecSuppiers ";
            List<NXBDTO> nXBs = new List<NXBDTO>();
            MySQL.Open();
            using(SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    nXBs.Add(new NXBDTO(
                        dataReader["manxb"].ToString(),
                        dataReader["ten"].ToString(),
                        dataReader["email"].ToString(),
                        dataReader["sdt"].ToString(),
                        dataReader["fax"].ToString()
                    ));
                }
            }
            MySQL.Close();
            return nXBs;
        }
        public static int UpdatSupplier(NXBDTO nXB)
        {
            string sqlstr = $"EXEC dbo.UpdatSupplier '{nXB.Manxb}', N'{nXB.Ten}', '{nXB.Email}', '{nXB.Sdt}', '{nXB.Fax}'";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int InserSupplier(NXBDTO nXB)
        {
            string sqlstr = $"EXEC dbo.InserSupplier N'{nXB.Ten}', '{nXB.Email}', '{nXB.Sdt}', '{nXB.Fax}'";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
    }
}
