using System;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public event EventHandler onPlayerCorrectCheckpoint;
    public event EventHandler onPlayerWrongCheckpoint;
    
    private List<Checkpoint> checkpointList;
    private int nextCheckpointIndex;

    private void Awake()
    {
        Transform checkpointTransform = transform;

        checkpointList = new List<Checkpoint>();
        foreach(Transform checkpoint in checkpointTransform)
        {
            Checkpoint checkpointSingle = checkpoint.GetComponent<Checkpoint>();
            checkpointSingle.SetTrackCheckpoints(this);
            
            checkpointList.Add(checkpointSingle);
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

    /*[Header("Waypoint Manager Settings")]
    [SerializeField] private GameObject prefab;

    [Header("Current Saved Position")]
    [ReadOnly] public Vector3 savedPosition;
    [ReadOnly] public Quaternion savedRotation;

    [Header("")] 
    public List<Checkpoint> waypoints = new List<Checkpoint>();
    [ReadOnly] public List<GameObject> waypointGameObject = new List<GameObject>();

    private void Start()
    {
        savedPosition = new Vector3(0, 1, 0);
        savedRotation = new Quaternion(0, 0, 0, 0);

        GameObject obj;
        BoxCollider box;
        foreach (var waypoint in waypoints)
        {
            obj = Instantiate(prefab, waypoint.waypointPositioning.position, waypoint.waypointPositioning.rotation, transform);
            obj.name = waypoint.name;
            obj.tag = "Checkpoint";

            box = obj.AddComponent<BoxCollider>();
            box.isTrigger = true;
            box.size = new Vector3(12f, 6f, waypoint.waypointPositioning.localScale.z);
            box.transform.position = waypoint.waypointPositioning.position;

            waypointGameObject.Add(obj);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        foreach(GameObject waypoint in waypointGameObject)
            Gizmos.DrawWireCube(waypoint.GetComponent<BoxCollider>().bounds.center, waypoint.GetComponent<BoxCollider>().bounds.size);
    }*/
}
