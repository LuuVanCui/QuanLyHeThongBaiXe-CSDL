using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.common
{
    class GiaTien
    {
        My_DB mydb = new My_DB();
        public bool insertGiaTien(String id, String Ten, double GiaTien, DateTime NgayApDung, String MaLoaiXe) 
        { 
            SqlCommand command = new SqlCommand("exec p_insertUpdateBangGia 'insert', @ma,@ten ,@gia ,@ngayApDung ,@MaLoaiXe ", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = id;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = Ten;
            command.Parameters.Add("@gia", SqlDbType.Float).Value = GiaTien;
            command.Parameters.Add("@ngayApDung", SqlDbType.DateTime).Value = NgayApDung;
            command.Parameters.Add("@MaLoaiXe", SqlDbType.Char).Value = MaLoaiXe;
     

            mydb.openConnection();
            if (command.ExecuteNonQuery() == 1)
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
        public bool updateGiaTien(String id, String Ten, double GiaTien, DateTime NgayApDung, String MaLoaiXe)
        {
            SqlCommand command = new SqlCommand("exec p_insertUpdateBangGia 'update', @ma,@ten ,@gia ,@ngayApDung ,@MaLoaiXe ", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.Char).Value = id;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = Ten;
            command.Parameters.Add("@gia", SqlDbType.Float).Value = GiaTien;
            command.Parameters.Add("@ngayApDung", SqlDbType.DateTime).Value = NgayApDung;
            command.Parameters.Add("@MaLoaiXe", SqlDbType.Char).Value = MaLoaiXe;


            mydb.openConnection();
            if (command.ExecuteNonQuery() == 1)
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
        public bool deleteGiaTien(String id)
        {
            SqlCommand command = new SqlCommand("exec p_deleteBangGia @id ", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Char).Value = id;

            mydb.openConnection();
            if (command.ExecuteNonQuery() == 1)
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
