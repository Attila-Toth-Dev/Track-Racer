using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private RaceManager _rManager;

    [SerializeField, ReadOnly] private bool _isPaused;

    void Start()
    {
        _rManager = FindObjectOfType<RaceManager>();
        if (_rManager != null)
            Debug.Log(_rManager.name);
        else
            Debug.LogError("GM MANAGER: RACE Manager was NULL");
    }

    public void RestartScene(string _sceneName)
    {
        Scene current = SceneManager.GetActiveScene();

        SceneManager.UnloadSceneAsync(current);
        SceneManager.LoadSceneAsync(_sceneName);
    }

    public void ChangeScene(string _sceneName)
    {
        Scene current = SceneManager.GetActiveScene();

        SceneManager.UnloadSceneAsync(current);
        SceneManager.LoadSceneAsync(_sceneName);
    }
}
