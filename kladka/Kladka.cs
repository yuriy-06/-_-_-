/*
 * Created by SharpDevelop.
 * User: yura
 * Date: 28.02.2016
 * Time: 9:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace kladka
{
	public class ValVal
	{
		public static double val (double val, int i)
		{
			double p =  Math.Floor(Math.Log10(Math.Abs(val))); // определяется порядок числа
			double d  = Math.Pow(10,p-i);
			val = d*Math.Round(val/d);
			return val;
		}
	}
	public class Kladka
	{
		public static double SE(float s, float a, float Ru)
		{
			if (s > 1.1*Ru) {s=1.1f*Ru;};
			double e = -1.1f/a*Math.Log(1-s/(1.1f*Ru));  //под знаком логарифма всегда >0 должно быть, отсюда s принадлежит [0 .. 1.1*Ru]
			return e;
		}
		public static double[] SE_m(float s1, float s2, float step, float a, float Ru)
		{
			int len_m = Convert.ToInt32(Math.Floor((s2 - s1)/step));
			
			double[] m  ; float i = s1; int j =0;
			m = new double[len_m];
			foreach (double elem in m)
			{
				m[j]=Kladka.SE(i, a, Ru);
				i+=step;
				j++;
			}
			return m;
		}
	}
	public class Program : Kladka
	{
		public static void main_py(float s1, float s2, float step, float a, float Ru)
		{
			double[] m = Kladka.SE_m(s1, s2, step, a, Ru);
			
			foreach (double elem in m) 
			{
				Console.Write("деф "+ValVal.val(elem, 3).ToString()+ "  напр  " + s1.ToString()  +"МПа\n");
				s1 +=step; 
			}
			Console.Write("деф "+ValVal.val(Kladka.SE(s2, a, Ru), 3).ToString()+ "  напр  " + s2.ToString()  +"МПа\n");
		}
		public static void Main(string[] argc)
		{
			float s1 = -0.08f;  // в МПа
			float s2 = 2.2f;
			float step = 0.1f;
			float a = 1000f;
			float Ru = 2.2f;
			double[] m = Kladka.SE_m(s1, s2, step, a, Ru);
			
			foreach (double elem in m) 
			{
				Console.Write("деф "+ValVal.val(elem, 3).ToString()+ "  напр  " + s1.ToString()  +" МПа\n");
				s1 +=step; 
			}
			Console.Write("деф "+ValVal.val(Kladka.SE(s2, a, Ru), 3).ToString()+ "  напр  " + s2.ToString()  +" МПа\n");
			
		}
	}
}