using System.Collections.Generic;
using System.Data.SqlClient;
using ThuVienQG.DTO;

namespace ThuVienQG.DAO
{
    public class LoaiDGDAO
    {
        public static List<LoaiDGDTO> SelecTypeOfReaders()
        {
            string sqlstr = "EXEC dbo.SelecTypeOfReaders";
            List<LoaiDGDTO> loais = new List<LoaiDGDTO>();
            MySQL.Open();
            SqlDataReader dataReader = MySQL.ExecuteSQL(sqlstr);
            while (dataReader.Read())
            {
                loais.Add(
                    new LoaiDGDTO(
                        dataReader["maloai"].ToString(),
                        int.Parse(dataReader["socuon"].ToString())
                    )
                );
            }
            MySQL.Close();
            return loais;
        }
    }
}
