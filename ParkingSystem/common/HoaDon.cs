using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.common
{
    class HoaDon
    {
        My_DB mydb = new My_DB();
        public bool insertHoaDon(int treGio, double tongTien, DateTime ngayIn, string ghiChu, string maTheXe)
        {
            string query = "exec insertHoaDon @tregio, @tongtien, @ngayin, @ghichu, @mathexe";
            SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
            cmd.Parameters.Add("@tregio", SqlDbType.Int).Value = treGio;
            cmd.Parameters.Add("@tongtien", SqlDbType.Real).Value = tongTien;
            cmd.Parameters.Add("@ngayin", SqlDbType.DateTime).Value = ngayIn;
            cmd.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = ghiChu;
            cmd.Parameters.Add("@mathexe", SqlDbType.Char).Value = maTheXe;

            mydb.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
    }
}
