using Controllers;

using Managers.Checkpoint_System;

using NaughtyAttributes;

using System;

using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private CarController car;

        [Header("UI Settings")]
        [SerializeField] private TextMeshProUGUI speed;
        [SerializeField] private TextMeshProUGUI laps;
        [SerializeField] private TextMeshProUGUI checkpoints;

        [Header("UI Objects")]
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject winMenu;

        [Header("UI Controls")]
        [SerializeField] private InputActionReference pauseAction;
        [SerializeField, ReadOnly] private bool isPaused;

        private GameSceneManager gsManager;
        private CheckpointManager checkpointManager;

        private void Start()
        {
            Time.timeScale = 1;
            
            gsManager = FindObjectOfType<GameSceneManager>();
            if (gsManager == null)
                Debug.LogWarning("UI MANAGER: GS Manager was NULL");

            checkpointManager = FindObjectOfType<CheckpointManager>();
            if (checkpointManager == null)
                Debug.LogWarning("UI MANAGER: Track Manager was NULL");
        }

        public void TogglePause()
        {
            isPaused = !isPaused;

            if(isPaused)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }

        public void Win()
        {
            Time.timeScale = 0;
            winMenu.SetActive(true);
        }

        public void RestartGame()
        {
            UnloadUI();
            gsManager.RestartScene();
        }

        public void QuitGame() => gsManager.QuitGame();
        
        private void Update()
        {
            float speedVal = car.carRb.velocity.magnitude;
            float rounded = (float) (Math.Round(speedVal, 3));
            
            checkpoints.text = $"Checkpoints: {checkpointManager.nextCheckpointIndex}/{checkpointManager.checkpointList.Count}";
            speed.text = $"Speed: {rounded * 5}";
            laps.text = $"Laps: {checkpointManager.currentLap}/{checkpointManager.lapAmount}";
            
            if(pauseAction.action.triggered)
                TogglePause();
        }
        
        private void UnloadUI()
        {
            pauseMenu.SetActive(false);
            winMenu.SetActive(false);

            isPaused = false;
            Time.timeScale = 1;
        }

        private void OnEnable() => pauseAction.action.Enable();

        private void OnDisable() => pauseAction.action.Disable();
    }
}