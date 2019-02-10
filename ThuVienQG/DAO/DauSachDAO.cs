using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ThuVienQG.DTO;

namespace ThuVienQG.DAO
{
    public class DauSachDAO
    {
        public static List<DauSachDTO> SelecTitleBooks(TheLoaiDTO theLoai)
        {
            string sqlstr;
            if (theLoai != null)
                sqlstr = $"EXEC dbo.SelecTitleBooks '{theLoai.Matl}'";
            else
                sqlstr = "EXEC dbo.SelecTitleBooks null ";
            List<DauSachDTO> dauSaches = new List<DauSachDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    dauSaches.Add(
                        new DauSachDTO(
                            dataReader["mads"].ToString(),
                            dataReader["ten"].ToString(),
                            Int32.Parse(dataReader["soluong"].ToString()),
                            Int32.Parse(dataReader["songaytoida"].ToString()),
                            Int32.Parse(dataReader["sotienphat"].ToString()),
                            Int32.Parse(dataReader["giabia"].ToString()),
                            theLoai
                        )
                    );
                }
            }
            MySQL.Close();
            return dauSaches;
        }
        public static int UpdatTitleBook(DauSachDTO dauSach)
        {
            string sqlstr = $"EXEC dbo.UpdatTitleBook '{dauSach.Mads}', N'{dauSach.Ten} ', {dauSach.Soluong} , {dauSach.Songaytoida} , {dauSach.Sotienphat}, {dauSach.Giabia},'{dauSach.Matl.Matl}'";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int DeletTitleBook(DauSachDTO dauSach)
        {
            string sqlstr = $"EXEC dbo.DeletTitleBook '{dauSach.Mads}'";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int InsertTitleBook(DauSachDTO dauSach)
        {
            string sqlstr = $"EXEC dbo.InserTitle N'{dauSach.Ten}', '{dauSach.Soluong}', '{dauSach.Songaytoida}', '{dauSach.Sotienphat}', '{dauSach.Giabia}', '{dauSach.Matl.Matl}' ";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
    }
}
