using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public float colliderRotationValue;

        [Header("Waypoint Positioning")]
        public Transform transform;
    }

    [Serializable]
    public struct SavedPlayerTransform
    {
        public Vector3 savedPosition;
        public Quaternion savedRotation;
    }

    [Header("Waypoint Manager Settings")]
    [SerializeField] private GameObject prefab;

    [Header("Current Saved Position")]
    [NaughtyAttributes.ReadOnly] public SavedPlayerTransform savedPlayerTransform;

    [Header("")] public List<Waypoint> waypoints = new List<Waypoint>();

    private readonly List<GameObject> _waypointGO = new List<GameObject>();

    private GameObject _gameObject;
    private BoxCollider _boxCollider;

    private void Start()
    {
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

        savedPlayerTransform.savedPosition = new Vector3(0, 1, 2.7f);
        savedPlayerTransform.savedRotation = new Quaternion(0, 180, 0, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        foreach(GameObject waypoint in _waypointGO)
            Gizmos.DrawWireCube(waypoint.GetComponent<BoxCollider>().bounds.center, waypoint.GetComponent<BoxCollider>().bounds.size);
    }
}
