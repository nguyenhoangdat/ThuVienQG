using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ThuVienQG.DTO;

namespace ThuVienQG.DAO
{
    public class TheLoaiDAO
    {
        public static List<TheLoaiDTO> SelecBookCategorys()
        {
            string sqlstr = "EXEC dbo.SelecBookCategorys";
            List<TheLoaiDTO> theLoais = new List<TheLoaiDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    theLoais.Add(
                        new TheLoaiDTO(
                            dataReader["matl"].ToString(),
                            dataReader["ten"].ToString()
                        )
                    );
                }
            }
            MySQL.Close();
            return theLoais;
        }
        public static int InserBookCategory(TheLoaiDTO theLoai)
        {
            string sqlstr = $"EXEC dbo.InserBookCategory N'{theLoai.Ten}'";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int UpdatBookCategory(TheLoaiDTO theLoai)
        {
            string sqlstr = $"EXEC dbo.UpdatBookCategory '{theLoai.Matl}', N'{theLoai.Ten}' ";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
    }
}
