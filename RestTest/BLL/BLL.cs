using RestTest.DAL;
using RestTest.Data;
using System.Collections.Generic;
using RestSharp;

namespace RestTest.BLL
{
    public class RestBLL
    {
        private RestDAL restDAL;

        public RestBLL()
        {
            restDAL = new RestDAL();
        }
    }
}
