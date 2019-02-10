using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ThuVienQG.DTO;

namespace ThuVienQG.DAO
{
    public class SachDAO
    {
        public static List<SachDTO> SelecBooks(DauSachDTO dauSach)
        {
            string sqlstr = $"EXEC dbo.SelecBooks '{dauSach.Mads}'";
            List<SachDTO> saches = new List<SachDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    saches.Add(
                        new SachDTO(
                            dauSach,
                            Int32.Parse(dataReader["stt"].ToString()),
                            dataReader["trangthai"].ToString()
                        )
                    );
                }
            }
            MySQL.Close();
            return saches;
        }
        public static int UpdatStatusBook(SachDTO sach)
        {
            string sqlstr = $"EXEC dbo.UpdatStatusBook '{sach.Mads.Mads}', {sach.Stt}, {sach.Trangthai}";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int InserBook(SachDTO sach)
        {
            string sqlstr = $"EXEC dbo.InserBook '{sach.Mads.Mads}', {sach.Stt}";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int DeletBook(SachDTO sach)
        {
            string sqlstr = $"EXEC dbo.DeletBook '{sach.Mads.Mads}', {sach.Stt}";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int DeletAllBooks(DauSachDTO dauSach)
        {
            string sqlstr = $"EXEC dbo.DeletAllBooks '{dauSach.Mads}'";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static List<SachDTO> SelecBookIsLend(DocGiaDTO docGia)
        {
            string sqlstr = $"EXEC dbo.SelecBookIsLend '{docGia.Madg}'";
            List<SachDTO> sachmuon = new List<SachDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    sachmuon.Add(new SachDTO(
                        new DauSachDTO(dataReader["ten"].ToString()),
                        Int32.Parse(dataReader["stt"].ToString())
                    ));
                }
            }
            MySQL.Close();
            return sachmuon;
        }
        public static int CountBookIsLend(DocGiaDTO docGia)
        {
            string sqlstr = $"EXEC dbo.CountBookIsLend '{docGia.Madg}'";
            MySQL.Open();
            int num = (Int32)MySQL.ExecuteScalar(sqlstr);
            MySQL.Close();
            return num;
        }
    }
}
