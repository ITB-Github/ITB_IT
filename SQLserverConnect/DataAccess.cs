using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLserverAbstract;

namespace SQLserverConnect
{
    internal class DataAccess:SQLserver
    {
        public DataAccess() : base()
        {

        }

        public string GetTeamsInJson()
        {
            string sqlProc = "GetTeamsInJson";
            return base.getJsonWithProc(sqlProc);
        }

        //internal string GetTheTeamInJson(string teamId)
        //{
        //    //throw new NotImplementedException();
        //    string sqlProc = "GetTheTeamInJson";
        //    SqlParameter parameter = new SqlParameter("@TeamID", teamId);
        //    return base.getJsonWithProc(sqlProc, parameter);
        //}
    }
}
