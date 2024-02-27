using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CarController car;

    [Header("UI Settings")]
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private TextMeshProUGUI laps;

    [Header("UI Objects")]
    [SerializeField] private GameObject PauseMenu;

    private GameSceneManager _gsManager;
    private RaceManager _rManager;

    void Start()
    {
        _rManager = FindObjectOfType<RaceManager>();
        _gsManager = FindObjectOfType<GameSceneManager>();

        if (_rManager != null)
            Debug.Log(_rManager.name);
        else
            Debug.LogError("UI MANAGER: RACE manager was NULL");

        if (_gsManager != null)
            Debug.Log(_gsManager.name);
        else
            Debug.LogError("UI MANAGER: GS Manager was NULL");
    }

    public void ResumeGame()
    {
        gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        _gsManager.RestartScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {

    }

    void Update()
    {
        speed.text = $"Speed: {(int)car._currentSpeed}";
        laps.text = $"Laps {_rManager.currentLap}/{_rManager.LapAmount}";
    }
}
