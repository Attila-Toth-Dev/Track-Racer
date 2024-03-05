using UnityEngine;

namespace Tools.Track
{
    [CreateAssetMenu (fileName ="New Track", menuName = "Scriptable Objects/Track")]
    public class Track : ScriptableObject
    {
        [Header("Track Details")]
        public string trackName;
        public string trackDescription;
        
        [Header("Track Customisations")]
        public Color trackColour;
        public Sprite trackImage;
        
        public Object sceneToLoad;
    }
}

