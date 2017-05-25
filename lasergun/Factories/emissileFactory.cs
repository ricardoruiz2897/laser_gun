using System;

namespace lasergun
{
	public class emissileFactory
	{
		static Lazy<emissileFactory> self = new Lazy<emissileFactory>(()=>new emissileFactory());

		public static emissileFactory Self {

			get{ 
				return self.Value;
			}

		}

		//create missile
		public event Action<emissile> emissileCreated;

		public emissileFactory ()
		{
		}

		public emissile CreateNew(){

			emissile nemissile = new emissile ();

			if (emissileCreated != null) {

				emissileCreated (nemissile);

			}

			return nemissile;
		}
	}
}


