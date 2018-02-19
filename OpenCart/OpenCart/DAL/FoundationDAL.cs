﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Data.Rest;

namespace OpenCart.DAL
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
