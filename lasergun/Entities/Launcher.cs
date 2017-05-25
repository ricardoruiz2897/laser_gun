using System;
using CocosSharp;

namespace lasergun
{
	public class Launcher: CCNode
	{
		CCSprite launcher;

		Random time_creation = new Random();

		public Launcher (): base()
		{
			//this handles the missile creation
			launcher = new CCSprite ();
			this.AddChild (launcher);

			Schedule (Fire, interval: time_creation.Next(1,4));

		}
			
		void Fire(float unused){

			//the only use is to create missiles in their position every random interval
			emissile nemissile = emissileFactory.Self.CreateNew ();
			nemissile.Position = this.Position;

		}
	}
}

