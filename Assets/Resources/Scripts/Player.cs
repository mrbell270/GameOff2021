
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
    List<MovementController> movementController;
    [VerticalGroup("Movement")]
    [SerializeField]
    int currentController;
    [VerticalGroup("Movement")]
    [SerializeField]
    float jumpingError;
    [VerticalGroup("Movement")]
    [SerializeField]
    float crouchingError;
    [VerticalGroup("Movement")]
    Vector2 movementVector;
    [VerticalGroup("Movement")]
    bool isOnLadder;
    [VerticalGroup("Movement")]
    bool canMove = true;

    [Header("Planning Mode")]
    public bool isInArea;

    [Header("Bugs")]
    [SerializeField]
    EBugType currentForm;
    EBugType previousForm;

    bool isFormLocked;

    [Header("Silent")]
    GameObject usable = null;
    public bool isVisible = true;

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
        currentForm = EBugType.Silent;
        currentController = (int)currentForm;
        foreach(MovementController mc in movementController)
        {
            mc.gameObject.SetActive(false);
        }
        movementController[currentController].gameObject.SetActive(true);
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
        if (canMove)
        {
            movementController[currentController].Move(movementVector, currentForm, crouchingError, jumpingError, isOnLadder);
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

    // States

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

    // States END

    // Bugs
    public void SetForm(int formId)
    {
        if (isFormLocked || (EBugType)formId == currentForm) return;
        movementController[currentController].gameObject.SetActive(false);
        StopForm(currentForm);
        if (formId == -1)
        {
            EBugType newForm = previousForm;
            previousForm = currentForm;
            currentForm = newForm;
        }
        else
        {
            previousForm = currentForm;
            currentForm = (EBugType)formId;
        }
        StartForm(currentForm);
        currentController = (int)currentForm;
        movementController[currentController].gameObject.SetActive(true);
    }

    void StartForm(EBugType form)
    {
        switch (form)
        {
            case (EBugType.Silent):
                break;
            case (EBugType.Flying):
                GetComponent<Rigidbody2D>().gravityScale = 1;
                break;
            case (EBugType.Small):
                break;
        }
    }
    void StopForm(EBugType form)
    {
        switch (form)
        {
            case (EBugType.Silent):
                break;
            case (EBugType.Flying):
                GetComponent<Rigidbody2D>().gravityScale = 3;
                break;
            case (EBugType.Small):
                break;
        }
    }
    // Bugs END

    // Silent
    public void UseAction()
    {
        if (usable == null || !currentForm.Equals(EBugType.Silent)) return;
        if (usable.CompareTag("Door"))
        {
            isVisible = !isVisible;
            isFormLocked = !isFormLocked;
            canMove = !canMove;
            transform.position = usable.transform.position;
        }
    }
    // Silent END

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentForm.Equals(EBugType.Silent) && collision.CompareTag("Ladder"))
        {
            isFormLocked = true;
            isOnLadder = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        if (currentForm.Equals(EBugType.Silent) && collision.CompareTag("Door"))
        {
            usable = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (currentForm.Equals(EBugType.Silent) && collision.CompareTag("Ladder"))
        {
            isFormLocked = false;
            isOnLadder = false;
            GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        if (currentForm.Equals(EBugType.Silent) && collision.CompareTag("Door"))
        {
            usable = null;
        }
    }
}
