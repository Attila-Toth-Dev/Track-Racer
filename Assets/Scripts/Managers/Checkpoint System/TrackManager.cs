using NaughtyAttributes;
using System;
using System.Collections.Generic;

using UnityEngine;

namespace Managers.Checkpoint_System
{
    public class TrackManager : MonoBehaviour
    {
        public event EventHandler onPlayerCorrectCheckpoint;
        public event EventHandler onPlayerWrongCheckpoint;
        
        [Header("Checkpoint List")]
        [ReadOnly] public List<Checkpoint> checkpointList;

        [Header("Track Settings")]
        public int lapAmount;
        
        [Header("Tracker")]
        [ReadOnly] public int nextCheckpointIndex;
        [ReadOnly] public int currentLap;
        
        [SerializeField, ReadOnly] private Vector3 savedPosition;
        [SerializeField, ReadOnly] private Quaternion savedRotation;

        private void Awake()
        {
            Transform checkpointTransform = transform;

            checkpointList = new List<Checkpoint>();
            foreach(Transform checkpoint in checkpointTransform)
            {
                Checkpoint checkpointSingle = checkpoint.GetComponent<Checkpoint>();
                checkpointSingle.SetTrackCheckpoints(this);
                
                checkpointList.Add(checkpointSingle);
                
                checkpointSingle.Hide();
            }
            
            nextCheckpointIndex = 0;
        }

        public void PlayerThroughCheckpoint(Checkpoint _checkpoint)
        {
            if(checkpointList.IndexOf(_checkpoint) == nextCheckpointIndex)
            {
                // Correct Checkpoint
                Debug.Log("Correct");
                Checkpoint correctCheckpoint = checkpointList[nextCheckpointIndex];
                correctCheckpoint.Hide();
                
                nextCheckpointIndex = (nextCheckpointIndex + 1) % checkpointList.Count;
                onPlayerCorrectCheckpoint?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                // Wrong Checkpoint
                Debug.Log("Wrong");
                onPlayerWrongCheckpoint?.Invoke(this, EventArgs.Empty);

                Checkpoint correctCheckpoint = checkpointList[nextCheckpointIndex];
                correctCheckpoint.Show();
            }
        }

        public void SaveTransform(Vector3 _position, Quaternion _rotation)
        {
            savedPosition = _position;
            savedRotation = _rotation;
        }
    }
}