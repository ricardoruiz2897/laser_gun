using System;
using System.Collections.Generic;
using CocosSharp;

namespace lasergun
{
	public class emissile: CCNode
	{
		CCSprite e_missile;

		//reference to the GameLayer
		GameLayer layer;

		//velocities
		public float velX = 400;
		public float velY = 400;

		//target
		float targetX;
		float targetY;

		//rotation
		float rotation;
		float rotation_rad;

		//Cuadrants representation
		bool cuadrant1;
		bool cuadrant2;
		bool cuadrant3;
		bool cuadrant4;

		public emissile (): base()
		{

			e_missile = new CCSprite ("enemy_missile");
			e_missile.AnchorPoint = CCPoint.AnchorMiddle;
			this.AddChild (e_missile);

			//set target X and Y
			layer = new GameLayer ();
			targetX = layer.lasergun.PositionX;
			targetY = layer.lasergun.PositionY;

			Schedule (Shoot);

		}

		void AddRotation(){

			//get targets x and y
			var a_file = new angle_file ();
			targetX = layer.lasergun.PositionX;
			targetY = layer.lasergun.PositionY;

			//cuadrants
			cuadrant1 = this.PositionX < targetX && this.PositionY > targetY;
			cuadrant2 = this.PositionX < targetX && this.PositionY < targetY;
			cuadrant3 = this.PositionX > targetX && this.PositionY > targetY;
			cuadrant4 = this.PositionX > targetX && this.PositionY < targetY;

			//cuadrant is a space on which the missile can come from **currently on testing**
			if(cuadrant1){ 

				rotation_rad = a_file.get_radians (targetX,targetY,this.PositionX,this.PositionY);
				rotation = (a_file.angle_degrees_ (rotation_rad)) *-1;


			}if(cuadrant2){

				rotation_rad = a_file.get_radians (targetX,targetY,this.PositionX,this.PositionY);
				rotation = (a_file.angle_degrees_ (rotation_rad) *-1);
				
			}if(cuadrant3){

				rotation_rad = a_file.get_radians (targetX,targetY,this.PositionX,this.PositionY);
				rotation = -a_file.angle_degrees_ (rotation_rad)+180;

			}if(cuadrant4){
				
				rotation_rad = a_file.get_radians (targetX,targetY,this.PositionX,this.PositionY);
				rotation = -a_file.angle_degrees_ (rotation_rad)+180;
			}

			//set rotation in missile
			e_missile.Rotation = rotation;
		}

		void Shoot(float FrameTimeInSeconds){

			var a_file = new angle_file ();

			//call add rotation
			this.AddRotation ();

			//testing only
			if(cuadrant1 || cuadrant2){

				e_missile.PositionX += ((a_file.get_cos (rotation_rad) * FrameTimeInSeconds) * velX);
				e_missile.PositionY += ((a_file.get_sin (rotation_rad) * FrameTimeInSeconds) * velY);

			}else if(cuadrant3 || cuadrant4){
				
				 e_missile.PositionX -= ((a_file.get_cos (rotation_rad) * FrameTimeInSeconds) * velX);
				 e_missile.PositionY -= ((a_file.get_sin (rotation_rad) * FrameTimeInSeconds) * velY);
			}

		}
	}
}

