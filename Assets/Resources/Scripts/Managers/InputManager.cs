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

        _controls.GameRunning.Move.performed += ctx => player.MoveAction(ctx.ReadValue<Vector2>());
        _controls.GameRunning.Move.canceled += ctx => player.MoveAction(Vector2.zero);
        _controls.GameRunning.Use.performed += ctx => player.UseAction();
        _controls.GameRunning.Plan.performed += ctx => CheckAndStartPlanning();
        _controls.GameRunning.Pause.performed += ctx => Debug.Log("PAUSE");
        _controls.GameRunning.Form1.performed += ctx => player.SetForm(0);
        _controls.GameRunning.Form2.performed += ctx => player.SetForm(1);
        _controls.GameRunning.Form3.performed += ctx => player.SetForm(2);
        _controls.GameRunning.FormPrev.performed += ctx => player.SetForm(-1);

        //_controls.GamePlanning.Back.performed += ctx => gm.SetState(EGameState.GameRunning);
        //_controls.GamePlanning.Move.performed += ctx => ui.PlanningChangeSelectedEntry(-Math.Sign(ctx.ReadValue<Vector2>().y));
        //_controls.GamePlanning.Use.performed += ctx => ui.PlanningChangeEntryState();
    }
    // Start is called before the first frame update
    void Start()
    {
        ui = UIManager.GetInstance();
        player = Player.GetInstance();

        _controls.GameRunning.Enable();
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
        if (!player.isInArea)
        {
            //gm.SetState(EGameState.GamePlanning);
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
