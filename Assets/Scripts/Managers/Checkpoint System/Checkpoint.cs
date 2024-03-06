using Controllers;

using UnityEngine;

namespace Managers.Checkpoint_System
{
	public class Checkpoint : MonoBehaviour
	{
		[SerializeField] private MeshRenderer meshRenderer;
		
		private CheckpointManager checkpointManager;
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
				checkpointManager.PlayerThroughCheckpoint(this);

				if(checkpointManager.nextCheckpointIndex == 1)
					checkpointManager.currentLap++;

				if(checkpointManager.currentLap > checkpointManager.lapAmount)
				{
					checkpointManager.currentLap = checkpointManager.lapAmount;	
					uiManager.Win();
				}
				
				checkpointManager.SaveTransform(_other.transform.position, _other.transform.localRotation);
			}
		}

		public void SetTrackCheckpoints(CheckpointManager checkpointCheckpoints) => this.checkpointManager = checkpointCheckpoints;

		public void Show() => meshRenderer.enabled = true;

		public void Hide() => meshRenderer.enabled = false;
	}
}