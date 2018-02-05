using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Data.Commodities
{

    public interface IName
    {
        ICommodityBuilder SetName(string name);
    }

    public interface ICommodityBuilder
    {
        ICommodity Build();
    }

    public interface ICommodity
    {
        string GetName();
    }

    public class Commodity : IName, ICommodityBuilder, ICommodity
    {
        private string name;

        private Commodity() { }

        public string GetName()
        {
            return name;
        }

        public static IName Get()
        {
            return new Commodity();
        }

        public ICommodityBuilder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public ICommodity Build()
        {
            return this;
        }
    }
}
