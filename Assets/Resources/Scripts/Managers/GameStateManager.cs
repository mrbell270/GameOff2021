using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{
    static GameStateManager instance;
    public static GameStateManager GetInstance()
    {
        return instance;
    }

    [SerializeField]
    [ReadOnly]
    GameState currentState;


    public UnityEvent OnRunningStart;
    public UnityEvent OnRunningStop;
    public UnityEvent OnPlanningStart;
    public UnityEvent OnPlanningStop;
    public UnityEvent OnPauseStart;
    public UnityEvent OnPauseStop;
    public UnityEvent OnMainMenuStart;
    public UnityEvent OnMainMenuStop;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetState(GameState.GameRunning);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(GameState newState)
    {
        switch (currentState) {
            case (GameState.GameRunning):
                OnRunningStop?.Invoke();
                break;
            case (GameState.GamePlanning):
                OnPlanningStop?.Invoke();
                break;
            case (GameState.PauseMenu):
                OnPauseStop?.Invoke();
                break;
            case (GameState.MainMenu):
                OnMainMenuStop?.Invoke();
                break;
            default:
                break;
        }
        switch (newState) {
            case (GameState.GameRunning):
                currentState = GameState.GameRunning;
                OnRunningStart?.Invoke();
                break;
            case (GameState.GamePlanning):
                currentState = GameState.GamePlanning;
                OnPlanningStart?.Invoke();
                break;
            case (GameState.PauseMenu):
                currentState = GameState.PauseMenu;
                OnPauseStart?.Invoke();
                break;
            case (GameState.MainMenu):
                currentState = GameState.MainMenu;
                OnMainMenuStart?.Invoke();
                break;
            default:
                break;
        }
    }
}
