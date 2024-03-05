using UnityEngine;

namespace Tools.Scriptable_Objects
{
    [CreateAssetMenu (fileName ="New Track", menuName = "Scriptable Objects/Track")]
    public class Track : ScriptableObject
    {
        [Header("Track Details")]
        public string trackName;
        public string trackDescription;
        
        [Header("Track Customisations")]
        public Sprite trackImage;
        
        public Object sceneToLoad;
    }
}

