using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

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
    [SerializeField, ReadOnly] private bool _isPaused;

    private GameSceneManager _gsManager;
    private RaceManager _rManager;

    private void Start()
    {
        Time.timeScale = 1;

        _rManager = FindObjectOfType<RaceManager>();
        if(_rManager == null)
            Debug.LogWarning("UI MANAGER: RACE manager was NULL");

        _gsManager = FindObjectOfType<GameSceneManager>();
        if (_gsManager == null)
            Debug.LogWarning("UI MANAGER: GS Manager was NULL");
    }

    public void TogglePause()
    {
        _isPaused = !_isPaused;

        if(_isPaused)
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
        _gsManager.RestartScene();
    }

    public void QuitGame() => _gsManager.QuitGame();

    public void ChangeScene(string _sceneName) => _gsManager.ChangeScene(_sceneName);

    private void Update()
    {
        float speedVal = (car.carRB.velocity.x + car.carRB.velocity.y) * 1000 * Time.deltaTime;

        speed.text = $"Speed: {(int)(speedVal)}";
        laps.text = $"Laps: {_rManager.currentLap}/{_rManager.LapAmount}";
        checkpoints.text = $"Checkpoints: {_rManager.currentCheckpoint}/{_rManager.checkpointAmount}";

        if(pauseAction.action.triggered)
        {
            TogglePause();
        }
    }

    private void UnloadUI()
    {
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);

        _isPaused = false;
        Time.timeScale = 1;
    }

    private void OnEnable() => pauseAction.action.Enable();

    private void OnDisable() => pauseAction.action.Disable();
}
