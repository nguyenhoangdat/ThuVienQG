using System;
using System.Collections.Generic;
using ThuVienQG.DAO;
using ThuVienQG.DTO;

namespace ThuVienQG.BUS
{
    public class DocGiaBUS
    {
        public static List<DocGiaDTO> GetReaders(LoaiDGDTO loaiDG)
        {
            List<DocGiaDTO> docGias = DocGiaDAO.SelecReaders(loaiDG);
            foreach(DocGiaDTO docGia in docGias)
            {
                if (0 < docGia.Ngaymo.Ticks && docGia.Ngaymo.Ticks < DateTime.Now.Ticks)
                {
                    docGia.Ngaymo = docGia.Ngaymo.AddTicks(-docGia.Ngaymo.Ticks);
                    docGia.Ngaykhoa = docGia.Ngaykhoa.AddTicks(-docGia.Ngaykhoa.Ticks);
                }
                DocGiaDAO.UnBlockReader(docGia);
            }
            return docGias;
        }
        public static int ChangeInfReader(string madg, string ten, string sdt, LoaiDGDTO loai)
        {
            return DocGiaDAO.UpdatReader(new DocGiaDTO(madg, ten, sdt, loai));
        }
        public static int LockOrUnlock(ref DocGiaDTO docGia, int month)
        {
            if (month > -1)
            {
                docGia.Ngaykhoa = DateTime.Now;
                if (month != 0)
                    docGia.Ngaymo = docGia.Ngaykhoa.AddMonths(month);
                else docGia.Ngaymo = docGia.Ngaymo.AddTicks(-docGia.Ngaymo.Ticks);
            }
            else
            {
                docGia.Ngaykhoa = docGia.Ngaykhoa.AddTicks(-docGia.Ngaykhoa.Ticks);
                docGia.Ngaymo = docGia.Ngaymo.AddTicks(-docGia.Ngaymo.Ticks);
            }
            return DocGiaDAO.UnBlockReader(docGia);
        }
        private static bool CheckUnlock(DocGiaDTO docGia)
        {
            return (docGia.Ngaykhoa.Ticks == 0);
        }
        public static int AddReader(string ten, string phone, LoaiDGDTO loai)
        {
            return DocGiaDAO.InserReader(new DocGiaDTO(ten, phone, loai));
        }
    }
}
