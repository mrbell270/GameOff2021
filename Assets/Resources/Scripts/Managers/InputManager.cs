using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    static InputManager instance;
    static InputControls _controls;

    [Header("Recievers")]
    Player player;
    GameStateManager gm;
    BugManager bm;
    UIManager ui;

    public static InputManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;

        _controls = new InputControls();

        _controls.GameRunning.Move.performed += ctx => player.MoveAction(ctx, EActionState.Performed);
        _controls.GameRunning.Move.canceled += ctx => player.MoveAction(ctx, EActionState.Cancelled);
        _controls.GameRunning.Attack.performed += ctx => player.AttackAction();
        _controls.GameRunning.Use.performed += ctx => CheckAndStartPlanning();
        _controls.GameRunning.Pause.performed += ctx => gm.SetState(EGameState.PauseMenu);

        _controls.GamePlanning.Back.performed += ctx => gm.SetState(EGameState.GameRunning);
        _controls.GamePlanning.Move.performed += ctx => ui.PlanningChangeSelectedEntry(-Math.Sign(ctx.ReadValue<Vector2>().y));
        _controls.GamePlanning.Use.performed += ctx => ui.PlanningChangeEntryState();
    }
    // Start is called before the first frame update
    void Start()
    {
        gm = GameStateManager.GetInstance();
        bm = BugManager.GetInstance();
        ui = UIManager.GetInstance();
        player = Player.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnableActionMap(InputActionMap actionMap)
    {
        if (actionMap == null || actionMap.enabled)
        {
            return;
        }
        actionMap.Enable();
    }

    public void EnableActionMap(string actionMapName)
    {
        EnableActionMap(_controls.asset.FindActionMap(actionMapName));
    }

    public void DisableActionMap(InputActionMap actionMap)
    {
        actionMap.Disable();
    }

    public void DisableActionMap(string actionMapName)
    {
        DisableActionMap(_controls.asset.FindActionMap(actionMapName));
    }

    private void CheckAndStartPlanning()
    {
        if (player.isAtTerminal)
        {
            gm.SetState(EGameState.GamePlanning);
        }
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        _controls.Disable();
    }
}
