using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace romanumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = 9999;
            RomaNumber rm = new RomaNumber();
            string result = rm.GetRoma(inputNumber, "");
            Console.WriteLine(result);
        }
    }

    public class RomaNumber
    {
        private List<string> romaC = new List<string> { "I", "V", "X", "L", "C", "D", "M", "O", "P" };

        public RomaNumber()
        {}
        public RomaNumber(List<string> romanumber)
        {
            romaC = romanumber;
        }

        public string GetRoma(int num, string result)
        {
            string one = romaC[0];
            string five = romaC[1];
            string ten = romaC[2];
            romaC.Remove(one);
            romaC.Remove(five);

            int firstDigi = num % 10;

            if (firstDigi <= 3)
            {
                result = string.Concat(Enumerable.Repeat(one, firstDigi)) + result;
            }
            else if (firstDigi <= 8)
            {
                int temp = firstDigi - 5;
                if (temp < 0)
                {
                    result = string.Concat(Enumerable.Repeat(one, (-temp))) + five + result;
                }
                else if (temp > 0)
                {
                    result = five + string.Concat(Enumerable.Repeat(one, temp)) + result;
                }
                else
                {
                    result = five;
                }
            }
            else if (firstDigi > 8 && firstDigi <= 10)
            {
                int temp = 10 - firstDigi;
                result = string.Concat(Enumerable.Repeat(one, temp)) + ten + result;
            }

            num = num / 10;
            if (num > 0)
            {
                return GetRoma(num, result);
            }
            return result;
        }
    }
}

