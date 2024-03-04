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

    private void Awake()
    {
        _cpManager = FindObjectOfType<CheckpointManager>();
        if (_cpManager == null)
            Debug.LogWarning("RACE MANAGER: CP Manager was NULL");

        _uiManager = FindObjectOfType<UIManager>();
        if (_uiManager == null)
            Debug.LogWarning("RACE MANAGER: UI Manager was NULL");
    }

    private void Start()
    {        
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

        if (currentLap > lapAmount)
            _uiManager.Win();
    }
}
