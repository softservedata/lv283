using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soap
{
    public class Data:Runner
    {
        protected static readonly object[] PositiveData =
        {
            new object[] {5.0, 7.0, 12.0},
            new object[] {12.5, 20.1, 32.6},
            new object[] {12.55555, 20.00001, 32.55556}
        };
        protected static readonly object[] NegativeData =
        {
            new object[] {-6.0, -10.0, -16.0},
            new object[] {-25.54, -20.1, -45.64},
            new object[] {-12.55555, -20.00001, -32.55556}
        };

        protected static readonly object[] PositiveAndNegativeData =
        {
            new object[] {-6.0, 4.0, -2.0},
            new object[] { 9.4, - 6.5, 2.9},
            new object[] {-25.54, 25.54, 0},
            new object[] {0, 0, 0},
            new object[] {-0.0001, 1, 0.9999},
            new object[] {-0.0001, 1.1, 1.0999}
        };

        
    }
}
