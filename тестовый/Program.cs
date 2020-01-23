using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace тестовый
{
    class Program
    {
        static string A_divided_B(decimal A,decimal B,int M)
    {
        if(B==0)return "Divided by zero";
        string txt="";
        int F=(int)(A/B);
        txt+=string.Format(" {0},",F);
        for (int i = 1; i <=M; i++)
			{
			 A=(A-F*B)*10;F=(int)(A/B);
        txt+=string.Format("{0}",Math.Abs(F));
			}
    return txt;
    }
        static void Main(string[] args)
        {
            Console.WriteLine(A_divided_B(37,-11,25));
            double x = Convert.ToDouble(A_divided_B(-37, -11, 25)); Console.WriteLine("x={0}", x);
Console.ReadLine();
        }
    }
}
