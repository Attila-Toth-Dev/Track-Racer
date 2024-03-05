using UnityEngine;

namespace Managers.Checkpoint_System
{
	public class CheckpointManagerUI : MonoBehaviour
	{
		private CheckpointManager checkpointManager;
		
	    private void Awake()
	    {
	        checkpointManager = FindObjectOfType<CheckpointManager>();
	        if(checkpointManager == null)
		        Debug.LogWarning("TRACK MANAGER UI: Track Manager is NULL");
	    }

	    private void Start()
		{
			checkpointManager.onPlayerCorrectCheckpoint += CheckpointManagerOnPlayerCorrectCheckpoint;
			checkpointManager.onPlayerWrongCheckpoint += CheckpointManagerOnPlayerWrongCheckpoint;
		}

		private void CheckpointManagerOnPlayerWrongCheckpoint(object _sender, System.EventArgs _e) => Show();

		private void CheckpointManagerOnPlayerCorrectCheckpoint(object _sender, System.EventArgs _e) => Hide();

		private void Show() => gameObject.SetActive(true);

		private void Hide() => gameObject.SetActive(false);
	}
}