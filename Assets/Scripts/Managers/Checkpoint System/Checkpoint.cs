using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	private TrackManager trackCheckpoints;
	[SerializeField] private MeshRenderer meshRenderer;

	private UIManager uiManager;
	
	private void Start()
	{
		Hide();

		uiManager = FindObjectOfType<UIManager>();
	}

	private void OnTriggerEnter(Collider _other)
	{
		if(_other.TryGetComponent<CarCollisionChecking>(out CarCollisionChecking car))
		{
			trackCheckpoints.PlayerThroughCheckpoint(this);

			if(trackCheckpoints.nextCheckpointIndex == 1)
				trackCheckpoints.currentLap++;

			if(trackCheckpoints.currentLap > trackCheckpoints.lapAmount)
			{
				trackCheckpoints.currentLap = trackCheckpoints.lapAmount;	
				uiManager.Win();
			}
		}
	}

	public void SetTrackCheckpoints(TrackManager _trackCheckpoints) => this.trackCheckpoints = _trackCheckpoints;

	public void Show() => meshRenderer.enabled = true;

	public void Hide() => meshRenderer.enabled = false;
}
