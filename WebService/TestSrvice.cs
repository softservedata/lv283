using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    class TestSrvice
    {
        [TestFixture]
        public class SrviceTest : SqrFunc
        {
            [Test, Order(2)]
            public void SqrOne(
                        [Range(15, 25)] int bases
                       )
            {
                Set(bases);
                Check(expected, actual);
            }

            [Test, Order(3)]
            public void SqrZero(
                        [Values(0)] int bases)
            {
                Set(bases);
                Check(expected, actual); ;
            }

            [Test, Order(4)]
            public void SqrRightLimit(
                        [Values(double.MaxValue)] int bases
                        )
            {
                Set(bases);
                Check(expected, actual);
            }

            [Test, Order(5)]
            public void SqrOverLimit(
                        [Values(double.MaxValue + 1)] int bases
                        )
            {
                Set(bases);
                CheckSpec(expected, actual);
            }

            [Test, Order(6)]
            public void SqrNegativeLimit(
                        [Values(double.MinValue)] int bases
                       )
            {
                Set(bases);
                Check(expected, actual);
            }

            [Test, Order(6)]
            public void SqrOverNegativeLimit(
                        [Values(double.MinValue - 1)] int bases
                       )
            {
                Set(bases);
                CheckSpec(expected, actual);
            }


            [Test, Order(9)]
            public void SqrNegative(
                        [Values(-17.85)] int bases
                        )
            {
                Set(bases);
                Check(expected, actual);
            }


        }
    }
}
