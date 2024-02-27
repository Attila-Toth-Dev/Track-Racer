using NaughtyAttributes;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public float LapAmount { get; private set; }
    [SerializeField, ReadOnly] private CheckpointManager _cpManager;

    [Header("Race Manager Settings")]
    [SerializeField] private float lapAmount;
    [ReadOnly] public float checkpointAmount;
    [ReadOnly] public float currentCheckpoint;
    [ReadOnly] public float currentLap;

    private void Start()
    {
        _cpManager = FindObjectOfType<CheckpointManager>();
        if (_cpManager != null)
            Debug.Log(_cpManager.name);
        else
            Debug.LogError("RACE MANAGER: CP Manager was NULL");

        checkpointAmount = _cpManager.waypoints.Count;

        currentCheckpoint = 0;
        currentLap = 1;

        LapAmount = lapAmount;
    }

    private void Update()
    {
        if (currentCheckpoint > checkpointAmount)
        {
            currentCheckpoint = 1;
            currentLap++;
        }

        if (currentLap > LapAmount)
            Debug.Log("YOU WIN");
    }
}
