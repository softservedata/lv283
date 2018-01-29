using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumTests.Data.Names
{
    public interface INameAdd
    {
        INameBuilder SetName(string name);
    }

    public interface INameBuilder
    {
        IName Build();
    }

    public interface IName
    {
        string GetName();       
    }

    public class Name : IName, INameAdd, INameBuilder
    {
        private string name;

        private Name()
        {

        }

        public static INameAdd Get()
        {
            return new Name();
        }

        public INameBuilder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public IName Build()
        {
            return this;
        }

        //Getters
        public string GetName()
        {
            return name;
        }
    }
}
