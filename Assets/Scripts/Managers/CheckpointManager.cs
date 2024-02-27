using System;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class CheckpointManager : MonoBehaviour
{
    [Serializable]
    public struct Waypoint
    {
        [Header("Waypoint Properties")]
        public string name;
        public Vector3 colliderSize;

        [Header("Waypoint Positioning")]
        public Transform transform;
    }

    [Header("Waypoint Manager Settings")]
    [SerializeField] private GameObject prefab;

    [Header("Current Saved Position")]
    [ReadOnly] public Vector3 savedPosition;
    [ReadOnly] public Quaternion savedRotation;

    [Header("")] public List<Waypoint> waypoints = new List<Waypoint>();

    private readonly List<GameObject> _waypointGO = new List<GameObject>();

    private GameObject _gameObject;
    private BoxCollider _boxCollider;

    private void Start()
    {
        savedPosition = new Vector3(0, 1, 0);
        savedRotation = new Quaternion(0, 0, 0, 0);

        foreach (Waypoint waypoint in waypoints)
        {
            _gameObject = Instantiate(prefab, waypoint.transform.position, waypoint.transform.rotation, transform);
            _gameObject.name = waypoint.name;

            _gameObject.tag = "Waypoint";

            _boxCollider = _gameObject.AddComponent<BoxCollider>();
            _boxCollider.isTrigger = true;
            _boxCollider.size = waypoint.colliderSize;

            _boxCollider.transform.position = waypoint.transform.position;

            _waypointGO.Add(_gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        foreach(GameObject waypoint in _waypointGO)
            Gizmos.DrawWireCube(waypoint.GetComponent<BoxCollider>().bounds.center, waypoint.GetComponent<BoxCollider>().bounds.size);
    }
}
