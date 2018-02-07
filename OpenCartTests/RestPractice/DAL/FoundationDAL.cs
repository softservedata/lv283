using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestPractice.Rest;

namespace RestPractice.DAL
{
    public class FoundationDAL : RestGeneral<FoundationNET>
        {
            public FoundationDAL() :
            base(FoundationRepository.Get().UrlGutHub(),
                FoundationRepository.Get().MediaTypeHeaderValue(),
                FoundationRepository.Get().RequestHeaders())
                {
                }
        }
   
}
