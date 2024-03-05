using Managers;

using Tools.Scriptable_Objects;

using UnityEngine;

namespace Tools
{
    public class ScriptableObjectChanger : MonoBehaviour
    {
        [Header("Scriptable Objects")]
        [SerializeField] private ScriptableObject[] scriptableObjects;
        
        [Header("Display Objects")]
        [SerializeField] private TrackManager trackManager;

        private int currentIndex;

        private void Awake()
        {
            ChangeScriptableObject(0);
        }

        public void ChangeScriptableObject(int _change)
        {
            currentIndex += _change;
            if(currentIndex < 0) currentIndex = scriptableObjects.Length - 1;
            else if(currentIndex > scriptableObjects.Length - 1) currentIndex = 0;
            
            if(trackManager != null) trackManager.DisplayTrack((Track)scriptableObjects[currentIndex]);
        }
    }
}

