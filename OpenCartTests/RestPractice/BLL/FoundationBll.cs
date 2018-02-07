using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestPractice.Rest;
using RestPractice.DAL;

namespace RestPractice.BLL
{
    class FoundationBLL
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

        public FoundationNET GetFoundationByName(string name)
        {
            Console.WriteLine("Search name = " + name);
            FoundationNET result = null;
            foreach (FoundationNET current in GetFoundations())
            {
                Console.WriteLine("current Name = " + current.Name);
                if (current.Name.ToLower().Trim().Equals(name.ToLower().Trim()))
                {
                    result = current;
                    break;
                }
            }
            return result;
        }
    }
}
