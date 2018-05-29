using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PointsTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            List<int> list = new List<int> { 1, 1, 4, 7, 2, 3, 5, 2, 1, 3, 3, 3 };

            var duplicated = list.GroupBy(g => g).Where(x => x.Count() > 1).ToDictionary(x => x.Key, y => y.Count());

            if (duplicated.Count >= 1)
            {
                Console.WriteLine("true");
                foreach (KeyValuePair<int, int> i in duplicated)
                {
                    foreach (int y in list)
                    {
                        if (y == i.Key)
                        {

                        }
                    }
                }

            }
            else Console.WriteLine("false");
            Console.ReadKey();
        }
    }
}
