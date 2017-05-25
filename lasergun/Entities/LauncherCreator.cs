using System;
using CocosSharp;

namespace lasergun
{
	public class LauncherCreator: CCNode
	{
		CCSprite launcherCreator;
	
		Random rpositionX = new Random(); //the whole horizontal bounds
		Random rpositionY = new Random(); //either up or down

		//creation interval
		//for testing 1.0, for real 7.0
		const float c_interval = 1.0f;

		public LauncherCreator (): base()
		{
			//no need to position it
			launcherCreator = new CCSprite ();
			launcherCreator.AnchorPoint = CCPoint.AnchorMiddle;
			this.AddChild (launcherCreator);

			Schedule (createLauncher, interval: c_interval);
		}
			
		void createLauncher(float frameTimeInSeconds){

			//create new Laucher every 7 seconds in a random position
			Launcher nLauncher = LauncherFactory.Self.CreateNew ();
			nLauncher.PositionX = rpositionX.Next(0,1200);

			//for positionY
			if (rpositionY.Next (2) == 0) {
				nLauncher.PositionY = 100;
			} else {
				nLauncher.PositionY = 750;
			}
		}

	}
}

///// for tessting only
//void createLauncher(float frameTimeInSeconds){
//
//	//create new Laucher every 7 seconds in a random position
//	Launcher nLauncher = LauncherFactory.Self.CreateNew ();
//
//	//For testing Im checking how the missiles move cuadrant by quadrant.
//
//	//this is for testing only 
//	//testing cuadrant4 **04/7/2017 5:04**
//	nLauncher.PositionX = 750;
//	nLauncher.PositionY = 100;
//
//	//lasergun.PositionX = 600;
//	//lasergun.PositionY = 384;
//
//}