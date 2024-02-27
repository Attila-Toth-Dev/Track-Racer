using NaughtyAttributes;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    [ReadOnly] public CheckpointManager checkpointManager;
    [ReadOnly] public float checkpointAmount;

    [Header("Race Manager Settings")]
    [SerializeField] private float lapAmount;

    [ReadOnly] public float currentCheckpoint;
    [ReadOnly] public float currentLap;

    private void Start()
    {
        checkpointManager = FindObjectOfType<CheckpointManager>();

        if (checkpointManager != null)
            Debug.Log("Checkpoint Manager found");
        else
            Debug.LogError("Checkpoint Manager NULL");

        checkpointAmount = checkpointManager.waypoints.Count;

        currentCheckpoint = 0;
        currentLap = 1;
    }

    private void Update()
    {
        if (currentCheckpoint > checkpointAmount)
        {
            currentCheckpoint = 1;
            currentLap++;
        }

        if (currentLap > lapAmount)
            Debug.Log("YOU WIN");
    }
}
