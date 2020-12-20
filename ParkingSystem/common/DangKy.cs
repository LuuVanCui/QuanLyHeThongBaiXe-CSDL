using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.common
{
    class DangKy
    {
        My_DB mydb = new My_DB();
        public bool insertDangKy(string khId, string maTheXe, DateTime ngayCap, DateTime ngayHetHan)
        {
            string query = "exec p_insertDangKy @kh_id, @mathexe, @ngaycap, @ngayhethan";
            SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
            cmd.Parameters.Add("@kh_id", SqlDbType.Char).Value = khId;
            cmd.Parameters.Add("@mathexe", SqlDbType.Char).Value = maTheXe;
            cmd.Parameters.Add("@ngaycap", SqlDbType.DateTime).Value = ngayCap;
            cmd.Parameters.Add("@ngayhethan", SqlDbType.DateTime).Value = ngayHetHan;

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
