using NaughtyAttributes;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public float LapAmount { get; private set; }

    [Header("Race Manager Settings")]
    [SerializeField] private float lapAmount;
    [ReadOnly] public float checkpointAmount;
    [ReadOnly] public float currentCheckpoint;
    [ReadOnly] public float currentLap;

    private CheckpointManager _cpManager;
    private UIManager _uiManager;
    
    private void Start()
    {
        _cpManager = FindObjectOfType<CheckpointManager>();
        if (_cpManager == null)
            Debug.LogWarning("RACE MANAGER: CP Manager was NULL");

        _uiManager = FindObjectOfType<UIManager>();
        if(_uiManager == null)
            Debug.LogWarning("RACE MANAGER: UI Manager was NULL");

        checkpointAmount = _cpManager.waypoints.Count;

        currentCheckpoint = 0;
        currentLap = 1;

        LapAmount = lapAmount;
    }

    private void Update()
    {
        // Lap Counting
        if (currentCheckpoint > checkpointAmount)
        {
            currentCheckpoint = 1;
            currentLap++;
        }

        // Toggle Win State
        if(currentLap > LapAmount)
            _uiManager.Win();
    }
}
