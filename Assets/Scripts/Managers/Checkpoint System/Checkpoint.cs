using System;

using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	private TrackManager trackCheckpoints;
	[SerializeField] private MeshRenderer meshRenderer;
	
	private void Start()
	{
		Hide();
	}

	private void OnTriggerEnter(Collider _other)
	{
		if(_other.TryGetComponent<CarCollisionChecking>(out CarCollisionChecking car))
			trackCheckpoints.PlayerThroughCheckpoint(this);
	}

	public void SetTrackCheckpoints(TrackManager _trackCheckpoints) => this.trackCheckpoints = _trackCheckpoints;

	public void Show() => meshRenderer.enabled = true;

	public void Hide() => meshRenderer.enabled = false;
}
