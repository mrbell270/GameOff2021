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
    EGameState currentState;


    public UnityEvent OnRunningStart;
    public UnityEvent OnRunningStop;
    public UnityEvent OnPlanningStart;
    public UnityEvent OnPlanningStop;
    public UnityEvent OnPauseStart;
    public UnityEvent OnPauseStop;
    public UnityEvent OnMainMenuStart;
    public UnityEvent OnMainMenuStop;
    public UnityEvent OnDialogStart;
    public UnityEvent OnDialogStop;


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
        SetState(EGameState.GameRunning);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(EGameState newState)
    {
        switch (currentState) {
            case (EGameState.GameRunning):
                OnRunningStop?.Invoke();
                break;
            case (EGameState.GamePlanning):
                OnPlanningStop?.Invoke();
                break;
            case (EGameState.PauseMenu):
                OnPauseStop?.Invoke();
                break;
            case (EGameState.MainMenu):
                OnMainMenuStop?.Invoke();
                break;
            case (EGameState.Dialog):
                OnDialogStop?.Invoke();
                break;
            default:
                OnRunningStop?.Invoke();
                OnPlanningStop?.Invoke();
                OnPauseStop?.Invoke();
                OnMainMenuStop?.Invoke();
                OnDialogStop?.Invoke();
                break;
        }
        switch (newState) {
            case (EGameState.GameRunning):
                currentState = EGameState.GameRunning;
                OnRunningStart?.Invoke();
                break;
            case (EGameState.GamePlanning):
                currentState = EGameState.GamePlanning;
                OnPlanningStart?.Invoke();
                break;
            case (EGameState.PauseMenu):
                currentState = EGameState.PauseMenu;
                OnPauseStart?.Invoke();
                break;
            case (EGameState.MainMenu):
                currentState = EGameState.MainMenu;
                OnMainMenuStart?.Invoke();
                break;
            case (EGameState.Dialog):
                currentState = EGameState.MainMenu;
                OnDialogStart?.Invoke();
                break;
            default:
                break;
        }
    }
}
