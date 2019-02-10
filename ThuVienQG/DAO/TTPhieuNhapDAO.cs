using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ThuVienQG.DTO;

namespace ThuVienQG.DAO
{
    public class TTPhieuNhapDAO
    {
        public static List<PhieuDTO> SelecReceiptNotes()
        {
            string sqlstr = "EXEC dbo.SelecReceiptNotes";
            List<PhieuDTO> phieuNhaps = new List<PhieuDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    phieuNhaps.Add(
                        new PhieuDTO(DateTime.Parse(dataReader["ngaynhap"].ToString()))
                    );
                }
            }
            MySQL.Close();
            return phieuNhaps;
        }
        public static List<PhieuDTO> SelecDeliveryNotes()
        {
            string sqlstr = "EXEC dbo.SelecDeliveryNotes";
            List<PhieuDTO> phieuGiaos = new List<PhieuDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    phieuGiaos.Add(
                        new PhieuDTO(DateTime.Parse(dataReader["ngaygiao"].ToString()))
                    );
                }
            }
            MySQL.Close();
            return phieuGiaos;
        }
        public static List<PhieuDTO> SelecReceiptNotesNotDeliveryNotes()
        {
            string sqlstr = "EXEC dbo.SelecReceiptNotesNotDeliveryNotes";
            List<PhieuDTO> phieuNhaps = new List<PhieuDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    phieuNhaps.Add(
                        new PhieuDTO(DateTime.Parse(dataReader["ngaynhap"].ToString()))
                    );
                }
            }
            MySQL.Close();
            return phieuNhaps;
        }
        public static List<TTPhieuNhapDTO> SelecReceiptNote(PhieuDTO phieuNhap)
        {
            string sqlstr = $"EXEC dbo.SelecReceiptNote '{phieuNhap.Ngaynhap}'";
            List<TTPhieuNhapDTO> chiTiet = new List<TTPhieuNhapDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    chiTiet.Add(new TTPhieuNhapDTO(
                            phieuNhap.Ngaynhap,
                            new DauSachDTO(dataReader["mads"].ToString(), dataReader["dausach"].ToString()),
                            Int32.Parse(dataReader["dongia"].ToString()),
                            Int32.Parse(dataReader["soluong"].ToString()),
                            DateTime.Parse(dataReader["ngaygiao"].ToString()),
                            DateTime.TryParse(dataReader["mapg"].ToString(), out DateTime mapg) ? mapg : new DateTime(),
                            new NXBDTO(dataReader["nxb"].ToString())
                    ));
                }
            }
            MySQL.Close();
            return chiTiet;
        }
        public static List<TTPhieuNhapDTO> SelecDeliveryNote(PhieuDTO phieuGiao)
        {
            string sqlstr = $"EXEC dbo.SelecDeliveryNote '{phieuGiao.Ngaynhap}'";
            List<TTPhieuNhapDTO> chiTiet = new List<TTPhieuNhapDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    chiTiet.Add(new TTPhieuNhapDTO(
                            DateTime.Parse(dataReader["mapn"].ToString()),
                            new DauSachDTO(dataReader["dausach"].ToString()),
                            Int32.Parse(dataReader["dongia"].ToString()),
                            Int32.Parse(dataReader["soluong"].ToString()),
                            DateTime.Parse(dataReader["ngaygiao"].ToString()),
                            phieuGiao.Ngaynhap,
                            new NXBDTO(dataReader["nxb"].ToString())
                    ));
                }
            }
            MySQL.Close();
            return chiTiet;
        }
        public static List<TTPhieuNhapDTO> SelecReceiptNotesOfSupplier(NXBDTO nhaCungCap)
        {
            string sqlstr = $"EXEC dbo.SelecReceiptNotesOfSupplier '{nhaCungCap.Manxb}'";
            List<TTPhieuNhapDTO> phieuNhaps = new List<TTPhieuNhapDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    phieuNhaps.Add(new TTPhieuNhapDTO(
                        DateTime.Parse(dataReader["mapn"].ToString()),
                        new DauSachDTO(dataReader["mads"].ToString(), dataReader["dausach"].ToString()),
                        Int32.Parse(dataReader["dongia"].ToString()),
                        Int32.Parse(dataReader["soluong"].ToString()),
                        DateTime.Parse(dataReader["ngaygiao"].ToString()),
                        nhaCungCap
                    ));
                }
            }
            MySQL.Close();
            return phieuNhaps;
        }
        public static int InserReceiptNote(PhieuDTO phieuNhap)
        {
            string sqlstr = $"EXEC dbo.InserReceiptNote '{phieuNhap.Ngaynhap}' ";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int InserDetailReceiptNote(List<TTPhieuNhapDTO> phieuNhaps)
        {
            string sqlstr;
            int numrow = 0;
            MySQL.Open();
            foreach (TTPhieuNhapDTO phieuNhap in phieuNhaps)
            {
                sqlstr = $"EXEC dbo.InserDetailReceiptNote '{phieuNhap.Mapn}', '{phieuNhap.Mads.Mads}', {phieuNhap.Dongia}, {phieuNhap.Soluong}, '{phieuNhap.Ngaygiao.ToShortDateString()}', '{phieuNhap.Manxb.Manxb}' ";
                numrow += MySQL.ExecuteNonSQL(sqlstr);
            }
            MySQL.Close();
            return numrow;
        }
        public static int ChangDetailReceiptNote(TTPhieuNhapDTO chitiet)
        {
            string sqlstr = $"EXEC dbo.UpdatDetailReceiptNote '{chitiet.Mapn}', '{chitiet.Mads.Mads}', {chitiet.Dongia}, {chitiet.Soluong}, '{chitiet.Ngaygiao}' ";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int DeletDetailReceiptNote(TTPhieuNhapDTO chitiet)
        {
            string sqlstr = $"EXEC dbo.DeletDetailReceiptNote '{chitiet.Mapn}', '{chitiet.Mads.Mads}' ";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int DeletReceiptNote(PhieuDTO phieuNhap)
        {
            string sqlstr = $"EXEC dbo.DeletReceiptNote '{phieuNhap.Ngaynhap}' ";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int InserDeliveryNote(PhieuDTO phieuGiao)
        {
            string sqlstr = $"EXEC dbo.InserDeliveryNote '{phieuGiao.Ngaynhap}' ";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int InserDetailDeliveryNote(List<TTPhieuNhapDTO> phieuGiaos)
        {
            string sqlstr;
            int numrow = 0;
            MySQL.Open();
            foreach (TTPhieuNhapDTO phieuGiao in phieuGiaos)
            {
                sqlstr = $"EXEC dbo.InserDetailDeliveryNote '{phieuGiao.Mapn}', '{phieuGiao.Mads.Mads}', '{phieuGiao.Mapg}'";
                numrow += MySQL.ExecuteNonSQL(sqlstr);
            }
            MySQL.Close();
            return numrow;
        }
    }
}
