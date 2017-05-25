using System;
using CocosSharp;

namespace lasergun
{
	public class LaserBeam: CCNode 
	{
		CCSprite beam;

		//reference to LaserGun class to access rotation then
		LaserGun gun;

		//have easier control of velocity
		float velX = 600;
		float velY = 600;

		public LaserBeam (): base()
		{
			beam = new CCSprite ("beam");
			beam.AnchorPoint = CCPoint.AnchorMiddle;
			this.AddChild (beam);

			gun = new LaserGun ();

			Schedule (Fire);
		}
			

		void Fire(float FrameTimeinSeconds){

			//access to angle_file
			var a_file = new angle_file();

			//update laserbeam position
			beam.PositionX += (a_file.get_cos(gun.rotation_rad) * FrameTimeinSeconds) * velX;
			beam.PositionY += (a_file.get_sin(gun.rotation_rad) * FrameTimeinSeconds) * velY;

		}

			
	}
}

