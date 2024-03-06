using Managers;

using NaughtyAttributes;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace Tools
{
    public class RaceSettings : MonoBehaviour
    {
        [Header("Race Settings")]
        [ReadOnly] public int lapAmount;
        [ReadOnly] public bool isRaceMode = true;
        [ReadOnly] public bool isFreeMode;
        
        [Header("UI Elements")]
        [SerializeField] private Toggle raceModeToggle;
        [SerializeField] private Toggle freeModeToggle;
        
        [SerializeField] private Slider lapSlider;
        [SerializeField] private TextMeshProUGUI lapSliderText;
        
        private GameSceneManager gsManager;
        
        private void Awake()
        {
            gsManager = FindObjectOfType<GameSceneManager>();
            if(gsManager == null)
                Debug.LogWarning("RACE SETTINGS: Game Scene Manager is NULL");
        }

        private void Start()
        {
            lapAmount = 3;

            raceModeToggle.interactable = true;
            raceModeToggle.isOn = true;

            //lapSlider.interactable = false;
        }

        private void Update() => lapSliderText.text = $"LAP AMOUNT: {lapAmount}";

        public void SliderValue()
        {
            if(isRaceMode)
            {
                lapAmount = (int)lapSlider.value;
                PlayerPrefs.SetInt("Laps", lapAmount);
            }
        }

        public void ToggleRace()
        {
            isRaceMode = !isRaceMode;
            lapAmount = 3;

            freeModeToggle.interactable = !isRaceMode;

            lapSlider.interactable = isRaceMode;
            lapSlider.value = 3;
        }

        public void ToggleFree()
        {
            isFreeMode = !isFreeMode;
            lapAmount = 99;

            PlayerPrefs.SetInt("Laps", lapAmount);

            raceModeToggle.interactable = !isFreeMode;
            
            lapSlider.interactable = !isFreeMode;
            lapSlider.value = 0;
        }
    }
}