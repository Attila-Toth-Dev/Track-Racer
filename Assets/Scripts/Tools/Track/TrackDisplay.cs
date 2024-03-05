using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tools.Track
{
    public class TrackDisplay : MonoBehaviour
    {
        [Header("Track Display Objects")]
        [SerializeField] private TextMeshProUGUI trackName;
        [SerializeField] private TextMeshProUGUI trackDesc;
        [SerializeField] private Image trackImage;
        [SerializeField] private Image backgroundTrackImage;

        [SerializeField] private Button playButton;
        
        public void DisplayTrack(Track _track)
        {
            trackName.text = _track.trackName;
            
            trackDesc.text = _track.trackDescription;
            
            trackImage.sprite = _track.trackImage;
            backgroundTrackImage.sprite = _track.trackImage;
            backgroundTrackImage.color = new Color(.1f, .1f, .1f);
            
            // Set Chosen track to "Track"
            PlayerPrefs.SetString("Track", _track.sceneToLoad.name);
            
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(()=>SceneManager.LoadScene("Race Settings Menu"));
        }
    }
}