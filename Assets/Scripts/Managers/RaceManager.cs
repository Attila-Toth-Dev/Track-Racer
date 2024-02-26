using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    [ReadOnly] public CheckpointManager checkpointManager;

    private void Start()
    {
        checkpointManager = FindObjectOfType<CheckpointManager>();

        if (checkpointManager != null)
            Debug.Log("Checkpoint Manager found");
        else
            Debug.LogError("Checkpoint Manager NULL");
    }

    private void Update()
    {
        
    }
}
