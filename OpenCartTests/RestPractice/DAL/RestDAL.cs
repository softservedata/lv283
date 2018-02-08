using RestPractice.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPractice.DAL
{
    class RestDAL : RestGeneral<ResultJsonObj>
    {
        public RestDAL() :
            base(RestRepo.Get().Url())
        {
        }
    }
}
