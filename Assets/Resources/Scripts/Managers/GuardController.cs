using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using System.Linq;

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
	public Vector2 movementDirection = Vector2.right;
	[SerializeField]
	float movementSpeed = 10f;
	[SerializeField]
	[Range(0, .3f)] 
	float movementSmoothing = .05f;

	[SerializeField]
	float waitTimer = 1.5f;
	bool isWaiting = false;

	public bool flipBeforeWait = false;
	public bool isFacingRight = true;
	Vector3 _velocity = Vector3.zero;

	public bool isAutomoving;
	public UnityEvent OnTurnEvent = new UnityEvent();

    private void FixedUpdate()
	{
		if (isAutomoving && !isWaiting)
		{
			bool canMoveForward = false;

			Collider2D[] colliders = Physics2D.OverlapCircleAll(FloorCheck.position, checkRadius, groundLayers);
			canMoveForward = colliders.Count(x => x.gameObject != gameObject) > 0;

			if (!canMoveForward)
            {
				fullStop();
			}

			if (canMoveForward)
			{
				colliders = Physics2D.OverlapCircleAll(FrontCheck.position, checkRadius, groundLayers);
				canMoveForward = colliders.Count(x => x.gameObject != gameObject) <= 0;
			}

			if (canMoveForward)
			{
				Move();
			}
			else
			{
				Wait();
			}
        }
	}


	void Move()
	{
		Vector3 targetVelocity = movementDirection * movementSpeed;
		rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref _velocity, movementSmoothing);
		CheckAndFlip();
	}

	void CheckAndFlip()
	{
		if ((movementDirection.x > 0 && !isFacingRight) || (movementDirection.x < 0 && isFacingRight))
		{
			isFacingRight = !isFacingRight;
			transform.Rotate(0, 180, 0);
		}
	}

	public void SwitchMovement(bool isMoving, int direction)
    {
		isAutomoving = isMoving;
		isFacingRight = direction == 0 ? isFacingRight : (direction > 0);
		movementDirection = direction * Vector2.right;
	}

	public void Wait()
	{
		isWaiting = true;
		StartCoroutine(WaitForTimer(waitTimer));
	}

	IEnumerator WaitForTimer(float waitTimer)
	{
		if(flipBeforeWait)
		{
			movementDirection *= -1;
			OnTurnEvent?.Invoke();
			CheckAndFlip();
		}
		yield return new WaitForSeconds(waitTimer);
		if (!flipBeforeWait)
		{
			movementDirection *= -1;
			OnTurnEvent?.Invoke();
			CheckAndFlip();
		}
		isWaiting = false;
	}

	void fullStop()
    {
		rb2d.velocity = Vector3.zero;
	}
}
