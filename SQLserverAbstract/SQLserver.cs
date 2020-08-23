using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLserverAbstract
{
    public abstract class SQLserver
    {
        protected string dbConnect = "server=localhost;database=ITB_CK;user id=ITB_IT;pwd=123456";
        protected SqlConnection con;

        public SQLserver()
        {
            OpenConnection();
        }
        public bool IsConnectionOpen
        {
            get
            {
                if (con.State == System.Data.ConnectionState.Open)
                    return true;
                return false;
            }
        }
        public virtual bool OpenConnection()
        {
            try
            {
                if (con == null)
                    con = new SqlConnection(dbConnect);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public virtual bool CloseConnection()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public virtual string getJsonWithQuery(string sqlQuery)
        {
            if (!IsConnectionOpen)
            {
                OpenConnection();
            }

            string res = "";
            SqlDataReader rdr = null;
            try
            {
                //string sqlQuery = "GetHandInTrans";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.CommandType = System.Data.CommandType.Text;

                //cmd.Parameters.Add(new SqlParameter("@myAccId", accId));

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    res += rdr.GetString(0);
                }
            }
            finally
            {
                if (rdr != null)
                    rdr.Close();
                //con.Close();
            }


            return res;
        }

        public virtual string getJsonWithQuery(string sqlQuery, params SqlParameter[] sqlParams)
        {
            if (!IsConnectionOpen)
            {
                OpenConnection();
            }

            string res = "";
            SqlDataReader rdr = null;
            try
            {
                //string sqlQuery = "GetHandInTrans";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddRange(sqlParams);

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    res += rdr.GetString(0);
                }
            }
            finally
            {
                if (rdr != null)
                    rdr.Close();
                //con.Close();
            }


            return res;
        }

        public virtual string getJsonWithProc(string sqlProc, params SqlParameter[] sqlParams)
        {
            if (!IsConnectionOpen)
            {
                OpenConnection();
            }

            string res = "";
            SqlDataReader rdr = null;
            try
            {
                //string sqlQuery = "GetHandInTrans";
                SqlCommand cmd = new SqlCommand(sqlProc, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddRange(sqlParams);

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    res += rdr.GetString(0);
                }
            }
            finally
            {
                if (rdr != null)
                    rdr.Close();
                //con.Close();
            }


            return res;
        }


        public virtual string getJsonWithProc(string sqlProc)
        {
            if (!IsConnectionOpen)
            {
                OpenConnection();
            }

            string res = "";
            SqlDataReader rdr = null;
            try
            {
                //string sqlQuery = "GetHandInTrans";
                SqlCommand cmd = new SqlCommand(sqlProc, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //cmd.Parameters.Add(new SqlParameter("@myAccId", accId));

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    res += rdr.GetString(0);
                }
            }
            finally
            {
                if (rdr != null)
                    rdr.Close();
                //con.Close();
            }


            return res;
        }


    }
}

