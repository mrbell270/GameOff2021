
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

    [Header("Planning Mode")]
    public bool isAtTerminal;

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
        isPlaying = true;
    }

    void ResetGame()
    {
    }

    private void Update()
    {
        if (isPlaying)
        {
        }
    }
    
    private void FixedUpdate()
    {
        if (isPlaying)
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

    public void MoveAction(UnityEngine.InputSystem.InputAction.CallbackContext ctx, EActionState state)
    {
        if (state.Equals(EActionState.Started) || state.Equals(EActionState.Performed))
        {
            movementVector = ctx.ReadValue<Vector2>();
        }
        else if (state.Equals(EActionState.Cancelled))
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Terminal"))
        {
            isAtTerminal = true;
            collision.GetComponent<Terminal>().SetPlayerNear(isAtTerminal);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Terminal"))
        {
            isAtTerminal = false;
            collision.GetComponent<Terminal>().SetPlayerNear(isAtTerminal);
        }
    }
}
