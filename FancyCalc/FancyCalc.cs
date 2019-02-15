using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FancyCalc
{
    public class FancyCalcEnguine
    {

        public double Add(int a, int b)
        {
            return checked(a + b);
        }


        public double Subtract(int a, int b)
        {
            //throw new NotImplementedException();
            return checked(a - b);
        }


        public double Multiply(int a, int b)
        {
            return checked(a * b);
        }

        public double Divide(int a, int b)
        {
            if (b == 0) throw new ArgumentNullException();
            return checked(a / b);
        }
        //generic calc method. usage: "10 + 20"  => result 30
        public double Culculate(string expression)
        {
            string tmp = Regex.Replace(expression, "[^0-9.+*/-]+", "");
            Match m = Regex.Match(tmp, "[+*/-]");

            string[] str = Regex.Split(tmp, "[+*/-]");
            int[] resArr = new int[2] { Convert.ToInt32(str[0]), Convert.ToInt32(str[1]) };
            double res = 0;
            char[] v = m.Value.ToCharArray();
            switch (v[0])
            {
                case '+':
                    res = Add(resArr[0],resArr[1]);
                    break;
                case '-':
                    res = Subtract(resArr[0],resArr[1]);
                    break;
                case '/':
                    res = Divide(resArr[0],resArr[1]);
                    break;
                case '*':
                    res = Multiply(resArr[0], resArr[1]);
                    break;
            }

            return res;

        }
    }
}
