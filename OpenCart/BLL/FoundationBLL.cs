using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Data.Rest;
using OpenCart.DAL;

namespace OpenCart.BLL
{
    public class FoundationBLL
    {
        private FoundationDAL foundationDAL;

        public FoundationBLL()
        {
            foundationDAL = new FoundationDAL();
        }

        public List<FoundationNET> GetFoundations()
        {
            var result = foundationDAL.GetAll();
            return result;
        }

        public FoundationNET GetByName(string name)
        {
            FoundationNET result = null;
            foreach (FoundationNET current in GetFoundations())
            {
                if (current.Name.ToLower().Contains(name))
                {
                    result = current;
                    break;
                }
            }
            return result;
        }
    }
}
