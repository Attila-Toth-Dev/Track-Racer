using System;

using UnityEngine;

[CreateAssetMenu(fileName = "New Car", menuName = "Scriptable Objects/Car"), Serializable]
public class Car : ScriptableObject
{
    [Header("Description")]
    public string carName;
    public string carDescription;

    [Header("Stats")]
    public float speed;
    public float acceleration;
    public float handling;

    [Header("3D Model")] 
    public int carIndex;
    public GameObject carModel;
}
