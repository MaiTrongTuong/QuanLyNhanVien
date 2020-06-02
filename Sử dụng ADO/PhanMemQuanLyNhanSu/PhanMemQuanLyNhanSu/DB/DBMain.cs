using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace PhanMemQuanLyNhanSu.DB
{
    class DBMain
    {
        string ConnStr = "Data Source=(local);Initial Catalog=QuanLyNhanSu;Integrated Security=True";
        SqlConnection conn = null;
        SqlCommand comm = null; 
        SqlDataAdapter da = null;
        public DBMain()
        {
            conn = new SqlConnection(ConnStr);
            comm = conn.CreateCommand();
        }
        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close(); conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            try
            {
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }
        public bool CheckLogin(string strSQL, CommandType ct, ref string err)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            try
            {
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read() == true)
                {
                    f = true;
                }
                else
                {
                    f = false;
                }
            }
            catch (SqlException ex)
            {
                err = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }
        public bool GetLuong(string sql,ref string LuongCB, ref string HeSoLuong)
        {
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sql,conn);

            DataSet dataSet = new DataSet();
            DataAdapter.Fill(dataSet, "Luong");
            DataTable dataTable = dataSet.Tables[0];

            foreach (DataRow dataRow in dataTable.Rows)
            {
                LuongCB = dataRow["LuongCB"].ToString();
                HeSoLuong = dataRow["HeSoLuong"].ToString();
            }
            return true;
        }

        public bool Check(string sql, CommandType ct, ref string error)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = sql;
            comm.CommandType = ct;
            try
            {
                int k = Int32.Parse(comm.ExecuteScalar().ToString());
                if (k > 0)
                {
                    f = true;
                }
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }
    }
}
