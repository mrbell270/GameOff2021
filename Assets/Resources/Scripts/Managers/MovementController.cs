using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class MovementController : MonoBehaviour
{
	[VerticalGroup("Movement")]
	[SerializeField]
	Rigidbody2D rb2d;
	[SerializeField]
	float movementSpeed = 10f;                          
	[SerializeField]
	float jumpForce = 400f;                          
	[SerializeField]
	[Range(0, 3)] 
	float crouchSpeedMultiplier = .36f;          
	[SerializeField]
	[Range(0, .3f)]
	float movementSmoothing = .05f;  
	[SerializeField]
	bool airControl = false;
	[SerializeField]
	bool canCrouch = false;
	[SerializeField]
	bool canJump = false;
	[SerializeField]
	LayerMask groundLayers;                          
	[SerializeField]
	Transform feetCheck;                           
	[SerializeField]
	Transform headCheck;                          
	[SerializeField]
	Collider2D crouchDisableCollider;                

	const float groundedRadius = .2f;
	bool isGrounded;
	const float ceilingRadius = .2f;
	bool isFacingRight = true;
	Vector3 _velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	bool _wasCrouching = false;

	private void Awake()
	{
		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = isGrounded;
		isGrounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(feetCheck.position, groundedRadius, groundLayers);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				isGrounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(Vector2 movement, EBugType form, float crouchError, float jumpError, bool isMovingVertically)
	{
		if (form == EBugType.Flying || isMovingVertically)
		{
			Vector3 targetVelocity = movement * movementSpeed;
			rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref _velocity, movementSmoothing);

			if (movement.x > 0 && !isFacingRight)
			{
				Flip();
			}
			else if (movement.x < 0 && isFacingRight)
			{
				Flip();
			}
		}
		else
		{
			float move = movement.x;
			bool crouch = canCrouch && movement.y < -crouchError;
			if (!crouch && _wasCrouching)
			{
				if (Physics2D.OverlapCircle(headCheck.position, ceilingRadius, groundLayers))
				{
					crouch = true;
				}
			}
			bool jump = !crouch && canJump && movement.y > jumpError;

			if (isGrounded || airControl)
			{
				if (crouch)
				{
					if (!_wasCrouching)
					{
						_wasCrouching = true;
						OnCrouchEvent.Invoke(true);
					}

					move *= crouchSpeedMultiplier;

					if (crouchDisableCollider != null)
						crouchDisableCollider.enabled = false;
				}
				else
				{
					if (crouchDisableCollider != null)
						crouchDisableCollider.enabled = true;

					if (_wasCrouching)
					{
						_wasCrouching = false;
						OnCrouchEvent.Invoke(false);
					}
				}

				Vector3 targetVelocity = new Vector2(move * movementSpeed, rb2d.velocity.y);
				rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref _velocity, movementSmoothing);

				if (move > 0 && !isFacingRight)
				{
					Flip();
				}
				else if (move < 0 && isFacingRight)
				{
					Flip();
				}
			}
			if (isGrounded && jump)
			{
				isGrounded = false;
				rb2d.AddForce(new Vector2(0f, jumpForce));
			}
		}
	}


	private void Flip()
	{
		isFacingRight = !isFacingRight;
		transform.Rotate(0, 180, 0);
	}

	public void AddGroundLayer(int layerId)
    {
		groundLayers += 1 << layerId;
	}

	public void RemoveGroundLayer(int layerId)
    {
		groundLayers -= 1 << layerId;
	}
}
