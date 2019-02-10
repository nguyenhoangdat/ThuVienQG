using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ThuVienQG.DTO;

namespace ThuVienQG.DAO
{
    public class DocGiaDAO
    {
        public static List<DocGiaDTO> SelecReaders(LoaiDGDTO loaiDG)
        {
            string sqlstr;
            List<DocGiaDTO> docGias = new List<DocGiaDTO>();
            MySQL.Open();
            if (loaiDG != null)
            {
                sqlstr = $"EXEC dbo.SelecReaders '{loaiDG.Maloai}'";
                using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
                    while (dataReader.Read())
                    {
                        DateTime date;
                        docGias.Add(new DocGiaDTO(
                            dataReader["madg"].ToString(),
                            dataReader["ten"].ToString(),
                            dataReader["sdt"].ToString(),
                            DateTime.TryParse(dataReader["dayblock"].ToString(), out date) ? date : new DateTime(),
                            DateTime.TryParse(dataReader["dayunblock"].ToString(), out date) ? date : new DateTime(),
                            loaiDG
                        ));
                    }
            }
            else
            {
                sqlstr = "EXEC dbo.SelecReaders null";
                using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
                    while (dataReader.Read())
                    {
                        DateTime date;
                        docGias.Add(new DocGiaDTO(
                            dataReader["madg"].ToString(),
                            dataReader["ten"].ToString(),
                            dataReader["sdt"].ToString(),
                            DateTime.TryParse(dataReader["dayblock"].ToString(),out date) ? date : new DateTime(),
                            DateTime.TryParse(dataReader["dayunblock"].ToString(), out date) ? date : new DateTime(),
                            new LoaiDGDTO(
                                dataReader["maloai"].ToString(),
                                Int32.Parse(dataReader["socuon"].ToString())
                            )
                        ));
                    }
            }
            MySQL.Close();
            return docGias;
        }
        public static int UpdatReader(DocGiaDTO docGia)
        {
            string sqlstr = $"EXEC dbo.UpdatReader '{docGia.Madg}', N'{docGia.Ten}', '{docGia.Sdt}', '{docGia.Maloai.Maloai}'";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int UnBlockReader(DocGiaDTO docGia)
        {
            string sqlstr;
            if (docGia.Ngaykhoa.Ticks != 0)
            {
                if (docGia.Ngaymo.Ticks != 0)
                    sqlstr = $"EXEC dbo.UpdatSttReader '{docGia.Madg}', '{docGia.Ngaykhoa.ToShortDateString()}', '{docGia.Ngaymo.ToShortDateString()}' ";
                else
                    sqlstr = $"EXEC dbo.UpdatSttReader '{docGia.Madg}', '{docGia.Ngaykhoa.ToShortDateString()}', null ";
            }
            else
                sqlstr = $"EXEC dbo.UpdatSttReader '{docGia.Madg}', null, null ";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int InserReader(DocGiaDTO docGia)
        {
            string sqlstr = $"EXEC dbo.InserReader N'{docGia.Ten}', '{docGia.Sdt}', '{docGia.Maloai.Maloai}' ";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
    }
}
