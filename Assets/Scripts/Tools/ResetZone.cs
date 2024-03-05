using UnityEngine;

namespace Tools
{
	[RequireComponent(typeof(BoxCollider))]
	public class ResetZone : MonoBehaviour
	{
		private new BoxCollider collider;
			
		private void Start()
		{
			gameObject.tag = "Reset Zone";
			
			collider = GetComponent<BoxCollider>();
			collider.isTrigger = true;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.HSVToRGB(0, 62, 88);
			Gizmos.DrawWireCube(GetComponent<BoxCollider>().bounds.center, GetComponent<BoxCollider>().size);
		}
	}
}