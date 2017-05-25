using System;

namespace lasergun
{
	public class angle_file
	{
		public angle_file ()
		{
		}

		//returns the angle in radians: need it to get cos and sin for x and y vel respectively
		public float get_radians(float x1, float y1, float x2, float y2){

			//
			float distancex = x2 - x1;
			float distancey = y2 - y1;
			float d = distancey / distancex;

			//conversions..get arctan and convert again
			double d_double = Convert.ToSingle (d);
			double d_angle = Math.Atan (d);
			float angle = Convert.ToSingle (d_angle);

			//returns angle in radians as a float
			return angle;

		}

		public float get_cos(float angle){

			double dcos_angle = Math.Cos (angle);
			float cos_angle = Convert.ToSingle (dcos_angle);
			return cos_angle;

		}

		public float get_sin(float angle){

			double dsin_angle = Math.Sin (angle);
			float sin_angle = Convert.ToSingle (dsin_angle);
			return sin_angle;

		}

		public float angle_degrees_(float angle_radians){
			float angle_degrees = (360 * angle_radians) / Convert.ToSingle (2 * Math.PI);
			return angle_degrees;
		}

		public float radians_minus180(float angle){

			double dangle = Convert.ToDouble (angle);
			double conversion = dangle - Math.PI;
			float t_angle = Convert.ToSingle (dangle);

			return t_angle;

		}

	}
}