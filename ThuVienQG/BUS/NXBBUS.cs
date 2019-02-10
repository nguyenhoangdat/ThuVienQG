using System.Collections.Generic;
using ThuVienQG.DAO;
using ThuVienQG.DTO;

namespace ThuVienQG.BUS
{
    public class NXBBUS
    {
        public static List<NXBDTO> GetSuppliers()
        {
            return NXBDAO.SelecSuppliers();
        }
        public static int ChangeInfSupplier(string manxb, string ten,string email,string sdt,string fax)
        {
            return NXBDAO.UpdatSupplier(new NXBDTO(manxb, ten, email, sdt, fax));
        }
        public static int AddSupplier(string ten, string email, string sdt,string fax)
        {
            return NXBDAO.InserSupplier(new NXBDTO(ten, email, sdt, fax));
        }
    }
}
