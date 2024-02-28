using UnityEngine;

[CreateAssetMenu (fileName ="New Track", menuName = "Scriptable Objects/Track")]
public class Track : ScriptableObject
{
    public int trackIndex;
    public string trackName;
    public string trackDescription;
    public Color trackColour;
    public Sprite trackImage;
    public Object sceneToLoad;
}
