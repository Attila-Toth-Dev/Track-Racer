using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrackDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI trackName;
    [SerializeField] private TextMeshProUGUI trackDesc;
    [SerializeField] private Image trackImage;
    [SerializeField] private Image backgroundTrackImage;

    [SerializeField] private Button playButton;
    
    public void DisplayTrack(Track _track)
    {
        trackName.text = _track.trackName;
        trackName.color = _track.trackColour;
        
        trackDesc.text = _track.trackDescription;
        
        trackImage.sprite = _track.trackImage;
        backgroundTrackImage.sprite = _track.trackImage;
        backgroundTrackImage.color = new Color(.1f, .1f, .1f);
        
        // Track Unlocking
        /*bool trackUnlocked = PlayerPrefs.GetInt("currentScene", 0) >= _track.trackIndex;
        lockIcon.SetActive(!trackUnlocked);
        playButton.interactable = mapUnlocked;
        
        if(trackUnlocked)
            trackImage.color = Color.white;
        else
            trackImage.color = Color.gray;*/
        
        PlayerPrefs.SetString("Track", _track.sceneToLoad.name);
        
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(()=>SceneManager.LoadScene(PlayerPrefs.GetString("Track")));
    }
}
