using System;

using UnityEngine;

namespace Tools.Cars
{
	public class CarShowroomRotate : MonoBehaviour
	{
		private void FixedUpdate()
		{
			transform.Rotate(0, .5f, 0);
		}
	}
}