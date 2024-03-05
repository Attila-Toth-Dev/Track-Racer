using System;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake() => Instance = this;

    private void Start()
    {
        UpdateGameState(GameState.TrackSelection);
    }

    public void UpdateGameState(GameState _newState)
    {
        state = _newState;

        switch(_newState)
        {
            case GameState.TrackSelection:
                break;
            
            case GameState.RaceSettings:
                break;
            
            case GameState.CarSelection:
                break;
            
            default:
                throw new ArgumentOutOfRangeException(nameof(_newState), _newState, null);
        }

        OnGameStateChanged?.Invoke(_newState);
    }

    private void HandleTrackSelection()
    {
        throw new NotImplementedException();
    }
}

public enum GameState
{
    TrackSelection,
    RaceSettings,
    CarSelection,
}
