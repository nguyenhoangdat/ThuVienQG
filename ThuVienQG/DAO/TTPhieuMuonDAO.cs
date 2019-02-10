namespace ThuVienQG.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using ThuVienQG.DTO;

    public class TTPhieuMuonDAO
    {
        public static List<PhieuMuonDTO> SelecLendNotes()
        {
            string sqlstr = "EXEC dbo.SelecLendNotes";
            List<PhieuMuonDTO> phieuMuons = new List<PhieuMuonDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    phieuMuons.Add(
                        new PhieuMuonDTO(
                            DateTime.Parse(dataReader["ngaymuon"].ToString()),
                            new DocGiaDTO(
                                dataReader["madg"].ToString(),
                                dataReader["ten"].ToString(),
                                dataReader["sdt"].ToString()
                            )
                        )
                    );
                }
            }
            MySQL.Close();
            return phieuMuons;
        }
        public static List<PhieuDTO> SelecPayBackNotes()
        {
            string sqlstr = "EXEC dbo.SelecPayBackNotes";
            List<PhieuDTO> phieuTras = new List<PhieuDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    phieuTras.Add(
                        new PhieuDTO(DateTime.Parse(dataReader["ngaytra"].ToString()))
                    );
                }
            }
            MySQL.Close();
            return phieuTras;
        }
        public static List<PhieuMuonDTO> SelecLendNotesNotPayBackNotes()
        {
            string sqlstr = "EXEC dbo.SelecLendNotesNotPayBackNotes";
            List<PhieuMuonDTO> phieuMuons = new List<PhieuMuonDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    phieuMuons.Add(
                        new PhieuMuonDTO(
                            DateTime.Parse(dataReader["ngaymuon"].ToString()),
                            new DocGiaDTO(
                                dataReader["madg"].ToString(),
                                dataReader["ten"].ToString(),
                                dataReader["sdt"].ToString()
                            )
                        )
                    );
                }
            }
            MySQL.Close();
            return phieuMuons;
        }
        public static List<TTPhieuMuonDTO> SelecLendNote(PhieuMuonDTO phieuMuon)
        {
            string sqlstr = $"EXEC dbo.SelecLendNote '{phieuMuon.Ngaymuon}'";
            List<TTPhieuMuonDTO> chiTiet = new List<TTPhieuMuonDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    chiTiet.Add(
                        new TTPhieuMuonDTO(
                            phieuMuon,
                            new SachDTO(
                                new DauSachDTO(
                                    dataReader["dausach"].ToString(),
                                    Int32.Parse(dataReader["songaytoida"].ToString())
                                ),
                                Int32.Parse(dataReader["stt"].ToString())
                            ),
                            Int32.Parse(dataReader["phat"].ToString()),
                            DateTime.TryParse(dataReader["mapt"].ToString(), out DateTime mapt) ? mapt : new DateTime()
                        )
                    );
                }
            }
            MySQL.Close();
            return chiTiet;
        }
        public static List<TTPhieuMuonDTO> SelecPayBackNote(PhieuDTO phieuTra)
        {
            string sqlstr = $"EXEC dbo.SelecPayBackNote '{phieuTra.Ngaynhap}'";
            List<TTPhieuMuonDTO> chiTiet = new List<TTPhieuMuonDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    chiTiet.Add(
                        new TTPhieuMuonDTO(
                            new PhieuMuonDTO(DateTime.Parse(dataReader["mapm"].ToString())),
                            new SachDTO(
                                new DauSachDTO(dataReader["dausach"].ToString()),
                                Int32.Parse(dataReader["stt"].ToString())
                            ),
                            Int32.Parse(dataReader["phat"].ToString()),
                            phieuTra.Ngaynhap
                        )
                    );
                }
            }
            MySQL.Close();
            return chiTiet;
        }
        public static int InserLendNote(PhieuMuonDTO phieuMuon)
        {
            string sqlstr = $"EXEC dbo.InserLendNote '{phieuMuon.Ngaymuon}', '{phieuMuon.Madg.Madg}'";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int InserDetailLendNote(List<TTPhieuMuonDTO> phieuMuons)
        {
            string sqlstr;
            int numrow = 0;
            MySQL.Open();
            foreach (TTPhieuMuonDTO phieuMuon in phieuMuons)
            {
                sqlstr = $"EXEC dbo.InserDetailLendNote '{phieuMuon.Mapm.Ngaymuon}', '{phieuMuon.Mads.Mads.Mads}', {phieuMuon.Mads.Stt} ";
                numrow += MySQL.ExecuteNonSQL(sqlstr);
            }
            MySQL.Close();
            return numrow;
        }
        public static List<TTPhieuMuonDTO> SelectLendBookNotPayBack(DocGiaDTO docGia)
        {
            string sqlstr = $"EXEC dbo.SelecBookIsLend '{docGia.Madg}'";
            List<TTPhieuMuonDTO> chitiet = new List<TTPhieuMuonDTO>();
            MySQL.Open();
            using (SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr))
            {
                while (dataReader.Read())
                {
                    chitiet.Add(new TTPhieuMuonDTO(
                        new PhieuMuonDTO(DateTime.Parse(dataReader["mapm"].ToString())),
                        new SachDTO(
                            new DauSachDTO(
                                dataReader["mads"].ToString(),
                                dataReader["ten"].ToString(),
                                Int32.Parse(dataReader["songaytoida"].ToString()),
                                Int32.Parse(dataReader["sotienphat"].ToString()),
                                Int32.Parse(dataReader["giabia"].ToString())
                            ),
                            Int32.Parse(dataReader["stt"].ToString())
                        )
                    ));
                }
            }
            MySQL.Close();
            return chitiet;
        }
        public static int InserPayBackNote(PhieuDTO phieuTra)
        {
            string sqlstr = $"EXEC dbo.InserPayBackNote '{phieuTra.Ngaynhap}'";
            MySQL.Open();
            int numrow = MySQL.ExecuteNonSQL(sqlstr);
            MySQL.Close();
            return numrow;
        }
        public static int InserDetailPayBackNote(List<TTPhieuMuonDTO> phieuTras)
        {
            string sqlstr;
            int numrow = 0;
            MySQL.Open();
            foreach(TTPhieuMuonDTO item in phieuTras)
            {
                sqlstr = $"EXEC dbo.InserDetailPayBackNote '{item.Mapm.Ngaymuon}', '{item.Mads.Mads.Mads}', {item.Mads.Stt}, '{item.Mapt}'";
                numrow += MySQL.ExecuteNonSQL(sqlstr);
            }
            MySQL.Close();
            return numrow;
        }
    }
}
