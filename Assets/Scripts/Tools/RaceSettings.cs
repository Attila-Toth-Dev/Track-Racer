using Managers;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

namespace Tools
{
    public class RaceSettings : MonoBehaviour
    {
        [SerializeField] private Toggle freeModeToggle;
        [SerializeField] private Toggle raceModeToggle;

        [SerializeField] private Slider lapSlider;
        
        private GameSceneManager gsManager;
        
        private void Awake()
        {
            gsManager = FindObjectOfType<GameSceneManager>();
            if(gsManager == null)
                Debug.LogWarning("RACE SETTINGS: Game Scene Manager is NULL");
        }

        public void ToggleRaceMode()
        {
            PlayerPrefs.SetInt("Mode", 1);
            freeModeToggle.enabled = false;
        }

        public void ToggleFreeMode()
        {
            PlayerPrefs.SetInt("Mode", -1);
            
            raceModeToggle.enabled = false;
            lapSlider.enabled = false;
        }
    }
}