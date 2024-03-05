using Controllers;

using Managers;
using Managers.Checkpoint_System;

using UnityEngine;

namespace Managers.Checkpoint_System
{
	public class Checkpoint : MonoBehaviour
	{
		private TrackManager trackManager;
		[SerializeField] private MeshRenderer meshRenderer;

		private UIManager uiManager;

		private void Awake()
		{
			uiManager = FindObjectOfType<UIManager>();
			if(uiManager == null)
				Debug.LogWarning("CHECKPOINT: UI Manager is NULL");
		}

		private void OnTriggerEnter(Collider _other)
		{
			if(_other.TryGetComponent<CarCollisionChecking>(out CarCollisionChecking car))
			{
				trackManager.PlayerThroughCheckpoint(this);

				if(trackManager.nextCheckpointIndex == 1)
					trackManager.currentLap++;

				if(trackManager.currentLap > trackManager.lapAmount)
				{
					trackManager.currentLap = trackManager.lapAmount;	
					uiManager.Win();
				}
				
				trackManager.SaveTransform(_other.transform.position, _other.transform.localRotation);
			}
		}

		public void SetTrackCheckpoints(TrackManager _trackCheckpoints) => this.trackManager = _trackCheckpoints;

		public void Show() => meshRenderer.enabled = true;

		public void Hide() => meshRenderer.enabled = false;
	}
}