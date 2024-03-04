using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class CheckpointManager : MonoBehaviour
{
    [Header("Waypoint Manager Settings")]
    [SerializeField] private GameObject prefab;

    [Header("Current Saved Position")]
    [ReadOnly] public Vector3 savedPosition;
    [ReadOnly] public Quaternion savedRotation;

    [Header("")] 
    public List<Waypoint> waypoints = new List<Waypoint>();
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
    }
}
