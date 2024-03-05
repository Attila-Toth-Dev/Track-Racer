using Tools.Track;

using UnityEngine;

namespace Tools
{
    public class ScriptableObjectChanger : MonoBehaviour
    {
        [Header("Scriptable Objects")]
        [SerializeField] private ScriptableObject[] scriptableObjects;
        
        [Header("Display Objects")]
        [SerializeField] private TrackDisplay trackDisplay;

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
            
            if(trackDisplay != null) trackDisplay.DisplayTrack((Track.Track)scriptableObjects[currentIndex]);
        }
    }
}

