using System.Collections.Generic;

namespace Tanks_Game_Core.Mathematics
{
	public class Vectora
	{
		double[] body;
		public Vectora(double[] body)
		{
			this.body = body;
		}
		public Vectora(double x, double y)
		{
			this.body = new double[2];
			this.body[0] = x;
			this.body[1] = y;
		}
		public Vectora(double x, double y, double z)
		{
			this.body = new double[3];
			this.body[0] = x;
			this.body[1] = y;
			this.body[2] = z;
		}

		public double x => body.Length == 0 ? double.NaN : this.body[0];
        public double y => body.Length <= 1 ? double.NaN : this.body[1];
        public double z => body.Length <= 2 ? double.NaN : this.body[2];

        public static Vectora operator +(Vectora v1, Vectora v2)
		{
			double[] newBody = new double[v1.body.Length];
			for (int i = 0; i < newBody.Length; ++i)
			{
				newBody[i] = v1.body[i] + v2.body[i];
			}
			return new Vectora(newBody);
		}
		public static Vectora operator -(Vectora v1, Vectora v2)
		{
			double[] newBody = new double[v1.body.Length];
			for (int i = 0; i < newBody.Length; ++i)
			{
				newBody[i] = v1.body[i] - v2.body[i];
			}
			return new Vectora(newBody);
		}
	}
}
