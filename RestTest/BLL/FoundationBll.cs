using RestTest.DAL;
using RestTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTest.BLL
{
    public class FoundationBll
    {
        FoundationDal foundationDal;

        public FoundationBll(string url)
        {
            foundationDal = new FoundationDal(url);
        }

        public Foundation GetRepository()
        {
            return foundationDal.GetRepository();
        }

        public string GetFoundationMethod()
        {
            return GetRepository().Method;
        }

        public string GetFoundationUrl()
        {
            return GetRepository().Url;
        }
    }
}
