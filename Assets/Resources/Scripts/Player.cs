
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Player : SerializedMonoBehaviour
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

    [Header("Visuals")]
    Animator morphAnimator;
    Animator currentAnimator;
    [SerializeField]
    [DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.Foldout)]
    Dictionary<ETriggerType, GameObject> helps = new Dictionary<ETriggerType, GameObject>();


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
        morphAnimator = GetComponent<Animator>();
        isPlaying = true;
        currentForm = EBugType.Silent;
        currentController = (int)currentForm;
        foreach(MovementController mc in movementController)
        {
            mc.gameObject.SetActive(false);
        }
        currentAnimator = movementController[currentController].gameObject.GetComponent<Animator>();
        movementController[currentController].gameObject.SetActive(true);
    }

    void ResetGame()
    {
    }

    private void Update()
    {
        if (isPlaying)
        {
            if (currentForm.Equals(EBugType.Small))
            {
                Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
                currentAnimator.SetFloat("HorizontalSpeed", Mathf.Abs(velocity.x));
                currentAnimator.SetFloat("VerticalSpeed", velocity.y);
                currentAnimator.SetBool("isGrounded", movementController[currentController].isGrounded);
            }
            else if (currentForm.Equals(EBugType.Silent))
            {
                currentAnimator.SetBool("isMoving", movementVector.magnitude > 0.05);
                currentAnimator.SetBool("isOnLadder", isOnLadder);
                currentAnimator.SetBool("isGrounded", movementController[currentController].isGrounded);
            }
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
        movementController[currentController].Move(movementVector, currentForm, crouchingError, jumpingError, isOnLadder);
    }

    public void MoveAction(Vector2 inputVector)
    {
        if (canMove)
        {
            movementVector = inputVector;
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

    public void SetCrouch(bool isCrouch)
    {
        currentAnimator.SetTrigger(isCrouch ? "Crouched" : "Uncrouched");
    }

    // States END

    // Bugs
    public void SetForm(int formId)
    {
        if (isFormLocked || (EBugType)formId == currentForm) return;
        morphAnimator.SetTrigger("Morph");
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
        currentAnimator = movementController[currentController].gameObject.GetComponent<Animator>();
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
            movementVector = Vector2.zero;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            isVisible = !isVisible;
            currentAnimator.SetTrigger(isVisible ? "Unhide" : "Hide");
            isFormLocked = !isFormLocked;
            canMove = !canMove;
            transform.position = usable.transform.position;
            GetComponent<Rigidbody2D>().gravityScale = canMove ? 3 : 0;
        }
        if (usable.CompareTag("Terminal"))
        {
            usable.GetComponent<Terminal>().Use();
        }
    }
    // Silent END

    // Triggers
    void SetTrigger(Trigger trigger, bool enabled=true)
    {
        ETriggerType type = trigger.type;
        switch (type)
        {
            case (ETriggerType.LevelStart):
                trigger.CloseStartDoor();
                break;
            case (ETriggerType.LevelEnd):
                // todo
                break;
            case (ETriggerType.Form1):
                helps[type].SetActive(enabled && 0 != (int)currentForm);
                break;
            case (ETriggerType.Form2):
                helps[type].SetActive(enabled && 1 != (int)currentForm);
                break;
            case (ETriggerType.Form3):
                helps[type].SetActive(enabled && 2 != (int)currentForm);
                break;
            case (ETriggerType.Usable):
                helps[type].SetActive(enabled);
                helps[ETriggerType.Form1].SetActive(enabled && 0 != (int)currentForm);
                break;
            case (ETriggerType.Move):
                helps[type].SetActive(enabled);
                break;
            default:
                break;
        }
    }

    public void MoveToPoint(Vector2 point)
    {
        canMove = false;
        StartCoroutine(MoveToPointCoroutine(point));
    }

    IEnumerator MoveToPointCoroutine(Vector2 point)
    {
        Vector2 direction = point - (Vector2)transform.position;
        while(direction.magnitude > 0.3)
        {
            direction = point - (Vector2)transform.position;
            movementVector = direction.normalized;
            yield return null;
        }
        Debug.Log("DONE");
        movementVector = Vector2.zero;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        canMove = true;
    }

    // Triggers END


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            SetTrigger(collision.GetComponent<Trigger>(), true);
        }
        if (currentForm.Equals(EBugType.Silent) && collision.CompareTag("Ladder"))
        {
            isFormLocked = true;
            isOnLadder = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        if (collision.CompareTag("Door"))
        {
            usable = collision.gameObject;
        }
        if (collision.CompareTag("Terminal"))
        {
            usable = collision.gameObject;
            SetTrigger(collision.GetComponent<Trigger>(), true);
            collision.gameObject.GetComponent<Terminal>().ShowLines(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            SetTrigger(collision.GetComponent<Trigger>(), false);
        }
        if (currentForm.Equals(EBugType.Silent) && collision.CompareTag("Ladder"))
        {
            isFormLocked = false;
            isOnLadder = false;
            GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        if (collision.CompareTag("Door"))
        {
            usable = null;
        }
        if (collision.CompareTag("Terminal"))
        {
            usable = null;
            SetTrigger(collision.GetComponent<Trigger>(), false);
            collision.gameObject.GetComponent<Terminal>().ShowLines(false);
        }
    }
}
