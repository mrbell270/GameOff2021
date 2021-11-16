using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class GuardController : MonoBehaviour
{
	[SerializeField]
	Rigidbody2D rb2d;
	[SerializeField]
	LayerMask groundLayers;
	[SerializeField]
	Transform FrontCheck;
	[SerializeField]
	Transform FloorCheck;
	float checkRadius = .05f;
	Vector2 movementDirection = Vector2.right;
	[SerializeField]
	float movementSpeed = 10f;
	[SerializeField]
	[Range(0, .3f)] 
	float movementSmoothing = .05f;
	[SerializeField]
	bool isFacingRight = true;
	Vector3 _velocity = Vector3.zero;

	public bool isAutomoving;
	public UnityEvent OnTurnEvent = new UnityEvent();

    private void FixedUpdate()
	{

		if (isAutomoving)
		{
			bool canMoveForward = false;

			Collider2D[] colliders = Physics2D.OverlapCircleAll(FloorCheck.position, checkRadius, groundLayers);
			for (int i = 0; i < colliders.Length; i++)
			{
				if (colliders[i].gameObject != gameObject)
				{
					canMoveForward = true;
				}
			}

			colliders = Physics2D.OverlapCircleAll(FrontCheck.position, checkRadius, groundLayers);
			for (int i = 0; i < colliders.Length; i++)
			{
				if (colliders[i].gameObject != gameObject)
				{
					canMoveForward = false;
				}
			}

			if (!canMoveForward)
			{
				movementDirection *= -1;
				OnTurnEvent?.Invoke();
			}

			Move(movementDirection);
        }
	}


	void Move(Vector2 movement)
	{
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
	}

	void Flip()
	{
		isFacingRight = !isFacingRight;
		transform.Rotate(0, 180, 0);
	}

	public void SwitchMovement(bool isMoving, int direction)
    {
		isAutomoving = isMoving;
		isFacingRight = direction == 0 ? isFacingRight : (direction > 0);
		movementDirection = direction * Vector2.right;
	}
}
