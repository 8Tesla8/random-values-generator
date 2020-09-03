using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomValuesGenerator
{
    public class Generator
    {
        #region V1

        // simple solution
        public List<int> GenerateRandomNumbersV1(int count)
        {
            var rand = new Random();
            List<int> randNumbers = new List<int>();
            for (int i = 0; i < count; i++)
            {
                while (true)
                {
                    var number = rand.Next(0, 50);
                    if (!randNumbers.Contains(number))
                    {
                        randNumbers.Add(number);
                        break;
                    }
                }
            }

            return randNumbers;
        }

        #endregion


        #region V2

        public List<int> GenerateRandomNumbersV2(int count)
        {
            var rand = new Random();

            List<int> values = Enumerable.Range(0, 50).ToList();

            List<int> randNumbers = new List<int>();
            for (int i = 0; i < count; i++)
            {
                int index = rand.Next(0, values.Count);
                randNumbers.Add(values[index]);
                values.RemoveAt(index);
            }

            return randNumbers;
        }


        #endregion


        #region V3

        private Random rand = new Random();
        List<int> values = Enumerable.Range(0, 50).ToList();

        public int[] GenerateRandomNumbersV3(int count)
        {
            int[] randNumber = new int[count];

            for (int i = 0; i < count; i++)
            {
                int maxValuesCount = values.Count - i;

                int index = rand.Next(0, maxValuesCount);

                randNumber[i] = values[index];


                //change value location, move it to the end
                var temp = values[maxValuesCount];
                values[maxValuesCount] = randNumber[i];
                values[index] = temp;
            }

            return randNumber;
        }


        #endregion
    }
}
