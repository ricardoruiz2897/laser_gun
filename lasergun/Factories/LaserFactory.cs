using System;

namespace lasergun
{
	public class LaserFactory
	{
		static Lazy<LaserFactory> self = new Lazy<LaserFactory>(()=>new LaserFactory());

		public static LaserFactory Self {

			get{ 
				return self.Value;
			}

		}

		//create missile
		public event Action<LaserBeam> LaserBeamCreated;

		public LaserFactory ()
		{
		}

		public LaserBeam CreateNew(){

			LaserBeam nLaserBeam = new LaserBeam ();

			if (LaserBeamCreated != null) {

				LaserBeamCreated (nLaserBeam);

			}

			return nLaserBeam;
		}
	}
}
	

