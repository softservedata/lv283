using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestTests.DAL;
using RestTests.Data;

namespace RestTests.BLL
{
    public class RestBLL
    {
        private FoundationDAL foundationDAL;

        public RestBLL()
        {
            foundationDAL = new FoundationDAL();
        }

        public string GetFoundations()
        {
            return foundationDAL.GetIp();
        }
    }
}
