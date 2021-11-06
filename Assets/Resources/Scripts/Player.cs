
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Essentials")]
    static Player instance;
    bool isPlaying;
    bool isGameOver;
    float timer;

    [Header("Movement Inner Variables")]
    [VerticalGroup("Movement")]
    [SerializeField]
    MovementController movementController;
    [VerticalGroup("Movement")]
    [SerializeField]
    float jumpingError;
    [VerticalGroup("Movement")]
    [SerializeField]
    float crouchingError;
    [VerticalGroup("Movement")]
    Vector2 movementVector;

    public static Player GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    void Start()
    {
        isPlaying = false;
        isGameOver = false;
    }

    void ResetGame()
    {
    }

    private void Update()
    {
        if (isPlaying && !isGameOver)
        {
        }
    }
    
    private void FixedUpdate()
    {
        if (isPlaying && !isGameOver)
        {
            Move();
        }
    }

    void Move()
    {
        if (!movementVector.Equals(Vector2.zero))
        {
            float movement = movementVector.x;
            bool isJumping = movementVector.y > jumpingError;
            bool isCrouching = movementVector.y < -crouchingError;
            movementController.Move(movement, isCrouching, isJumping);
        }
    }

    public void AttackAction()
    {
    }

    public void MoveAction(UnityEngine.InputSystem.InputAction.CallbackContext ctx, ActionState state)
    {
        if (state.Equals(ActionState.Started) || state.Equals(ActionState.Performed))
        {
            movementVector = ctx.ReadValue<Vector2>();
        }
        else if (state.Equals(ActionState.Cancelled))
        {
            movementVector = Vector2.zero;
        }
    }

    public void SetRunning()
    {
        isPlaying = true;
        Time.timeScale = 1;
    }

    public void SetPlanning()
    {
        isPlaying = false;
        Time.timeScale = 0;
    }

    public void SetPaused()
    {
        isPlaying = false;
        Time.timeScale = 0;
    }
}
