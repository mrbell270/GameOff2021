using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class NpcMovementController : MonoBehaviour
{
	[VerticalGroup("Movement")]
	[SerializeField] private Rigidbody2D rb2d;
	[SerializeField] private float movementSpeed = 10f;
	[SerializeField] private float jumpForce = 400f;
	[Range(0, 3)] [SerializeField] private float crouchSpeedMultiplier = .36f;
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
	[SerializeField] private bool airControl = false;
	[SerializeField] private bool canCrouch = false;
	[SerializeField] private bool canJump = false;
	[SerializeField] private LayerMask groundLayers;
	[SerializeField] private Transform feetCheck;
	[SerializeField] private Transform headCheck;
	[SerializeField] private Collider2D crouchDisableCollider;

	const float groundedRadius = .2f;
	private bool isGrounded;
	const float ceilingRadius = .2f;
	private bool isFacingRight = true;
	private Vector3 _velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool _wasCrouching = false;

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
			bool jump = canJump && movement.y > jumpError;
			bool crouch = canCrouch && movement.y < -crouchError;
			if (!crouch && _wasCrouching)
			{
				if (Physics2D.OverlapCircle(headCheck.position, ceilingRadius, groundLayers))
				{
					crouch = true;
				}
			}

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
