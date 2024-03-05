using UnityEngine;

namespace Tools.Cars
{
	public class CarShowroomRotate : MonoBehaviour
	{
		[SerializeField] private float rotationAmount = 0.5f;
		
		private void FixedUpdate() => transform.Rotate(0, rotationAmount, 0);
	}
}