using RestTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RestTest.DAL
{
    public class RestDAL : RestGeneral
    {
        public RestDAL() : base(RestRepo.Get().UserAgentUrl())
        {
        }
    }
}
