using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_TeamPointMainScreenInteractor;

namespace SQLserverConnect
{
    internal class DataMapper : PointDataGateway
    {
        DataAccess sqlserver;
        public DataMapper()
        {
            if (sqlserver == null)
            {
                sqlserver = new DataAccess();
            }
        }
        public string GetTeamsInJson()
        {
            return sqlserver.GetTeamsInJson();
            //throw new NotImplementedException();
        }

        public bool IsConnected()
        {
            return sqlserver.IsConnectionOpen;
            //throw new NotImplementedException();
        }
    }
}
