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

        _controls.GameRunning.Move.performed += ctx => player.MoveAction(ctx, ActionState.Performed);
        _controls.GameRunning.Move.canceled += ctx => player.MoveAction(ctx, ActionState.Cancelled);
        _controls.GameRunning.Attack.performed += ctx => player.AttackAction();
        _controls.GameRunning.Use.performed += ctx => gm.SetState(GameState.GamePlanning);
        _controls.GameRunning.Pause.performed += ctx => gm.SetState(GameState.PauseMenu);

        _controls.GamePlanning.Back.performed += ctx => gm.SetState(GameState.GameRunning);
        _controls.GamePlanning.Use.performed += ctx => bm.ChooseBug(0,0);
        _controls.GamePlanning.Pause.performed += ctx => bm.UnchooseBug(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        gm = GameStateManager.GetInstance();
        bm = BugManager.GetInstance();
        player = Player.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleActionMap(InputActionMap actionMap)
    {
        if (actionMap == null || actionMap.enabled)
        {
            return;
        }

        _controls.Disable();
        actionMap.Enable();
    }

    public void ToggleActionMapByName(string actionMapName)
    {
        ToggleActionMap(_controls.asset.FindActionMap(actionMapName));
    }

    private void OnEnable()
    {
        //_controls.GameRunning.Enable();
    }

    private void OnDisable()
    {
        //_controls.GameRunning.Disable();
    }
}
