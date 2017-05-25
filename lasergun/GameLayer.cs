using System;
using System.Collections.Generic;
using CocosSharp;

namespace lasergun
{
	public class GameLayer : CCLayerColor
	{
		//classes
		public LaserGun lasergun; //every missile need to access this
		LauncherCreator launcherCreator;

		//Lists
		public List<LaserBeam> _beams;

		List<Launcher> _launchers;
		List<emissile> _emissiles;

		//Map objects
		CCSprite map1;
		CCSprite map2;
		CCSprite boat;

		float mapVel = 100;

		//score objects
		CCLabel scoreLabel;

		int score;
		int frameCounter;

		public GameLayer () : base (CCColor4B.Aquamarine)
		{
			//boat
			boat = new CCSprite("boat");
			boat.AnchorPoint = CCPoint.AnchorMiddle;
			boat.PositionX = 600;
			boat.PositionY = 384;
			AddChild (boat);

			//lasergun
			lasergun = new LaserGun();
			lasergun.PositionX = 600;
			lasergun.PositionY = 384;
			AddChild(lasergun);

			//launcher creator, position doesn't matter for this one
			launcherCreator = new LauncherCreator();
			AddChild(launcherCreator);

			//handle beam creation
			_beams = new List<LaserBeam>();
			LaserFactory.Self.LaserBeamCreated += HandleBeamCreation;

			//handle laucher creation
			_launchers = new List<Launcher>();
			LauncherFactory.Self.LauncherCreated += HandleLauncherCreation;

			//handle emissile creation
			_emissiles = new List<emissile>();
			emissileFactory.Self.emissileCreated += HandleMissileCreation;

			//map
			map1 = new CCSprite("background");
			map1.AnchorPoint = CCPoint.AnchorMiddle;
			map1.PositionX = 600;
			map1.PositionY = 384;
			AddChild (map1);

			map2 = new CCSprite("background");
			map2.AnchorPoint = CCPoint.AnchorMiddle;
			map2.PositionX = 1800;
			map2.PositionY = 384;
			AddChild (map2);

			//Score
			scoreLabel = new CCLabel("","Arial",60,CCLabelFormat.SystemFont);
			scoreLabel.AnchorPoint = CCPoint.AnchorMiddle;
			scoreLabel.PositionX = 600;
			scoreLabel.PositionY = 100;
			AddChild (scoreLabel);

			//game
			Schedule (game);
	
		}

		protected override void AddedToScene ()
		{
			base.AddedToScene ();

			// Use the bounds to layout the positioning of our drawable assets
			CCRect bounds = VisibleBoundsWorldspace;

		}

		//The next three functions handle object creations

		void HandleBeamCreation(LaserBeam nLaserBeam){

			//add to game and list
			AddChild (nLaserBeam);
			_beams.Add (nLaserBeam);
		
		}

		void HandleLauncherCreation(Launcher nLauncher){

			//add to game and list
			AddChild (nLauncher);
			_launchers.Add (nLauncher);

		}

		void HandleMissileCreation(emissile nemissile){

			//add to game and list
			AddChild (nemissile);
			_emissiles.Add (nemissile);

		}

		//this function is in charge of moving the backgroud the correct way
		void moveBackground(float FrameTimeInSeconds){			

			//infinite maps
			map1.PositionX -= (mapVel * FrameTimeInSeconds);
			map2.PositionX -= (mapVel * FrameTimeInSeconds);

			//wrap backgrounsd
			if(map1.PositionX > 580 && map1.PositionX < 620){

				map2.PositionX = 1800;

			}			

			if(map2.PositionX > 580 && map2.PositionX < 620){

				map1.PositionX = 1800;

			}
		
		}

		//this funciton handles collision
		void collision(){

			if(_emissiles.Count > 0){

				for(int i = 0; i<_emissiles.Count; i++){

					//Main collision
					if(_emissiles[0].BoundingBox.IntersectsRect(boat.BoundingBox)){

							_emissiles [0].velX = 0;
							_emissiles [0].velY = 0;

						}

					}	
			}

		}

		void game(float FrameTimeInSeconds){

			collision ();

			//update map
			moveBackground (FrameTimeInSeconds);

			//update score every 1.5 sec
			score = Convert.ToInt32((frameCounter++) * FrameTimeInSeconds - (((frameCounter++) * FrameTimeInSeconds)/2));

			//testing
			scoreLabel.Text = string.Format("{0}", _emissiles.Count);

			//real one:
			//scoreLabel.Text = string.Format ("{0}",score);
		
		}
	}
}
