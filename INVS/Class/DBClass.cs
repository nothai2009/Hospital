using System;
using System.Data;
using System.Data.SqlClient;

namespace UDH
{
    internal class DBClass
    {
        //SQL Server Class
        #region
        public static string strCon = "Data Source=192.168.0.5;User ID=homc;Password=homc;Initial Catalog=INVS";
        //public static string strCon = "Data Source=192.168.0.5;User ID=invs;Password=P@ssw0rd;Initial Catalog=INVS;Connection Timeout=10000000";
        public static SqlTransaction tr;
        private int i;

        //New
        public DataTable SqlGetData(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public DataTable SqlGetData3(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public DataTable SqlPROCEDURE(string max, string min)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INVSBILL", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MAX", max));
                cmd.Parameters.Add(new SqlParameter("@MIN", min));
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public DataTable GetDataDB3(SqlParameterCollection para,string pa)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(pa, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in para)
                {
                    cmd.Parameters.AddWithValue(param.ParameterName, param.SqlDbType).Value = param.Value;
                }
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public DataTable SqlCountActiveValueCost()
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("CountActiveValueCost", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public DataTable SqlCountActiveValueCost2(string WORKING_CODE, string STOCK_ID)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("CountActiveValueCost2", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@WORKING_CODE", WORKING_CODE));
                cmd.Parameters.Add(new SqlParameter("@STOCK_ID", STOCK_ID));
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public DataTable SqlShowCARD(string WORKING_CODE, string STOCK_ID)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SHOWDATA_CARD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@WORKING_CODE", WORKING_CODE));
                cmd.Parameters.Add(new SqlParameter("@STOCK_ID", STOCK_ID));
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public DataTable SqlShowDATA(string STOCK_ID, string StoredProcedure)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(StoredProcedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@STOCK_ID", STOCK_ID));
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public DataTable ShowDATA3(string val1,string val2, string StoredProcedure)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(StoredProcedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@dates", val1));
                cmd.Parameters.Add(new SqlParameter("@datee", val2));
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public DataTable SqlSHOWDATA_INV_MD(string WORKING_CODE, string STOCK_ID)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SHOWDATA_INV_MD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@WORKING_CODE", WORKING_CODE));
                cmd.Parameters.Add(new SqlParameter("@STOCK_ID", STOCK_ID));
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public DataTable SqlSHOWDATA_INV_MD_C(string WORKING_CODE, string STOCK_ID)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SHOWDATA_INV_MD_C", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@WORKING_CODE", WORKING_CODE));
                cmd.Parameters.Add(new SqlParameter("@STOCK_ID", STOCK_ID));
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public DataTable SqlSORTROW(string WORKING_CODE, string STOCK_ID)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SORTROW", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@WORKING_CODE", WORKING_CODE));
                cmd.Parameters.Add(new SqlParameter("@STOCK_ID", STOCK_ID));
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        public int SqlExecute3(string WORKING_CODE, string STOCK_ID)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT_INV_MD_C", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@WORKING_CODE", WORKING_CODE));
                cmd.Parameters.Add(new SqlParameter("@STOCK_ID", STOCK_ID));
                i = cmd.ExecuteNonQuery();
                conn.Close();
                return i;
            }
        }

        public int SqlExecute(string sql, SqlParameterCollection parameters)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                tr = conn.BeginTransaction();

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Transaction = tr;

                cmd.Parameters.Clear();

                foreach (SqlParameter param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.ParameterName, param.SqlDbType).Value = param.Value;
                }
                i = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                tr.Commit();
                conn.Close();
                return i;
            }
        }

        public int SqlExecute(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                tr = conn.BeginTransaction();

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Transaction = tr;

                i = cmd.ExecuteNonQuery();
                tr.Commit();
                conn.Close();
                return i;
            }
        }

        public int SqlExecute3(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                tr = conn.BeginTransaction();

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Transaction = tr;

                i = cmd.ExecuteNonQuery();
                tr.Commit();
                conn.Close();
                return i;
            }
        }

        public int SqlExecuteDB3(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                tr = conn.BeginTransaction();

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Transaction = tr;

                i = cmd.ExecuteNonQuery();
                tr.Commit();
                conn.Close();
                return i;
            }
        }

        public int AutoNunber(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                var value = Convert.ToString(cmd.ExecuteScalar());

                if (value == "")
                {
                    i = 1;
                }
                else
                {
                    value = value.Replace("ST", "");
                    i = Convert.ToInt32(value) + 1;
                }
                return i;
            }
        }

        public int AutoNunberInt(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                var value = Convert.ToString(cmd.ExecuteScalar());

                if (value == "")
                {
                    i = 1;
                }
                else
                {
                    i = Convert.ToInt32(value) + 1;
                }
                return i;
            }
        }

        public string AutoNunberNew(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                var value = Convert.ToString(cmd.ExecuteScalar());
                if (value == "")
                {
                    value = 'ค' + DateTime.Now.ToString("yy") + "00001";
                }
                return value;
            }
        }

        public int TOTAL_STANDARD_PRICE(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                try
                {
                    i = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                }
                catch
                {
                    i = 0;
                }

                return i;
            }
        }

        #endregion
    }
}