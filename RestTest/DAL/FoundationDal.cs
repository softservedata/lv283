using RestTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTest.DAL
{
    public class FoundationDal : RestGeneral
    {
        public FoundationDal(string url) : base(
            FoundationRepository.Get().GetUrl(url), FoundationRepository.Get().MediaTypeHeaderValue())
        { }
    }
}
