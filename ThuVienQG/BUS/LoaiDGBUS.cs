using System.Collections.Generic;
using ThuVienQG.DAO;
using ThuVienQG.DTO;

namespace ThuVienQG.BUS
{
    public class LoaiDGBUS
    {
        public static List<LoaiDGDTO> GetTypeOfReaders()
        {
            return LoaiDGDAO.SelecTypeOfReaders();
        }
    }
}
