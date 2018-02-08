using RestPractice.DAL;
using RestPractice.Data;
using System.Collections.Generic;

namespace RestPractice.BLL
{
    class RestBLL
    {
        private RestDAL restDAL;

        public RestBLL()
        {
            restDAL = new RestDAL();
        }

        public ResultJsonObj GetResult()
        {
            var result = restDAL.GetAll();
            return result;
        }

    }
}
