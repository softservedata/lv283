using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestTests.Data.Rest;

namespace RestTests.DAL
{
    public class FoundationDAL : RestGeneral
    {
        public FoundationDAL() :
            base(RestRepository.Get().UrlHttpBin())
        {
        }
    }
}
