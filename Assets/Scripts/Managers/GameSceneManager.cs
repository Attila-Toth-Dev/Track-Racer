using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private RaceManager _rManager;

    private void Start()
    {
        _rManager = FindObjectOfType<RaceManager>();
        if (_rManager == null)
            Debug.LogError("GM MANAGER: RACE Manager was NULL");
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeScene(string _sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(_sceneName);
    }

    public void QuitGame() => Application.Quit();
}
