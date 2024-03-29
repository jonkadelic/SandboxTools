﻿using Sandbox;
using Sandbox.UI;

namespace Sandbox.ScreenShake
{
	public class Random : CameraModifier
	{
		float Length = 5.0f;
		float Speed = 1.0f;
		float Size = 1.0f;

		TimeSince lifeTime = 0;

		public Random( float length = 1.5f, float speed = 1.0f, float size = 1.0f )
		{
			Length = length;
			Speed = speed;
			Size = size;
		}

		public override bool Update( Camera cam )
		{
			var delta = ((float)lifeTime).LerpInverse( 0, Length, true );
			delta = Easing.EaseOut( delta );

			Vector3 rand = Vector3.Random;
			rand.z = 0;
			rand = rand.Normal;

			cam.Pos += (cam.Rot.Right * rand.x + cam.Rot.Up * rand.y) * (1 - delta) * Size;

			return lifeTime < Length;
		}
	}
}
