using System;
using CocosSharp;

namespace lasergun
{
	public class LaserGun: CCNode
	{
		CCSprite lasergun;

		//touch vars
		float touchX;
		float touchY;

		/*
		 * When the user is touching shoot
		 * When the user is moving, shoot
		 * When the user in not touching, dont shoot
		*/

		//wait till first touch
		bool _shoot = false;

		//rotation to get and set, set to public cuase there is acces in LaserBeam class
		public float rotation {
			get;
			set;
		}

		//this is the one we apply to cos and sin
		public float rotation_rad {
			get;
			set;
		}

		public LaserGun (): base()
		{
			lasergun = new CCSprite ("lasergun");
			//anchor in the middle for better control
			lasergun.AnchorPoint = CCPoint.AnchorMiddle;
			this.AddChild (lasergun);

			//User input
			var touchBegan = new CCEventListenerTouchAllAtOnce();
			touchBegan.OnTouchesBegan = HandleTouchesBegan;
			AddEventListener (touchBegan, this);

			var touchEnded = new CCEventListenerTouchAllAtOnce ();
			touchEnded.OnTouchesEnded = HandleTouchesEnded;
			AddEventListener (touchEnded, this);

			var touchMoved = new CCEventListenerTouchAllAtOnce ();
			touchMoved.OnTouchesMoved = HandleTouchesMoved;
			AddEventListener (touchMoved, this);

			Schedule (shoot);

		}

		void HandleTouchesBegan(System.Collections.Generic.List<CCTouch> touches, CCEvent onTouch){

			//shoot here
			_shoot = true;

			//get location of first touch
			CCTouch touch = touches[0];
			touchX = touch.LocationOnScreen.X;
			touchY = touch.LocationOnScreen.Y;

		}

		void HandleTouchesEnded(System.Collections.Generic.List<CCTouch> touches, CCEvent onTouch){

			//do not shoot here
			_shoot = false;

			//we don't need to get location here
		}

		void HandleTouchesMoved(System.Collections.Generic.List<CCTouch> touches, CCEvent onTouch){

			//shoot here
			_shoot = true;

			//get location of first touch
			CCTouch touch = touches[0];
			touchX = touch.LocationOnScreen.X;
			touchY = touch.LocationOnScreen.Y;

		}

		void AddRotation(){

			//angle file object
			var a_file = new angle_file ();

			if(touchX > this.PositionX){

				this.rotation_rad = a_file.get_radians (touchX,touchY,this.PositionX,this.PositionY);
				this.rotation = a_file.angle_degrees_ (rotation_rad);


			}else{
				
				this.rotation_rad = a_file.get_radians (touchX,touchY,this.PositionX,this.PositionY);
				this.rotation = a_file.angle_degrees_ (this.rotation_rad) - 180;

			}

			//Set lasergun rotation
			lasergun.Rotation = this.rotation;

		}

		public void shoot(float FrameTimeInSeconds){

			AddRotation ();

			//if shooting is activated create new lassers in current position and rotation
			if(_shoot){

				//create new laserbeam, set position and rotation.
				LaserBeam nLaserBeam = LaserFactory.Self.CreateNew ();
				nLaserBeam.Position = this.Position;
				nLaserBeam.Rotation = this.rotation;
			}
		}
	}
}

