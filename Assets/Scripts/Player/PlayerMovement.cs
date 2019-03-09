using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] new Rigidbody2D rigidbody;
	[SerializeField] Animator animator;
	[SerializeField] float speed;
	[SerializeField] float attackDuration;

	[HideInInspector] public bool canMove = true;
	public float direction;

	private void Update()
	{
		direction = Input.GetAxis("Horizontal");

		if (canMove)
		{
			Walking = Mathf.Abs(direction) > 0;

			float newXScale;

			if (direction != 0)
			{
				newXScale = Mathf.Sign(direction) * Mathf.Abs(transform.localScale.x);
				transform.localScale = new Vector3(newXScale, transform.localScale.y, transform.localScale.z);
			}

			if (Input.GetAxis("Fire1") > 0 && !Jumping && !Falling)
			{
				canMove = false;
				animator.SetBool("Attack", true);
				StartCoroutine(AttackFinished());
			}
		}
	}

	IEnumerator AttackFinished()
	{
		yield return new WaitForSeconds(attackDuration);
		animator.SetBool("Attack", false);
		canMove = true;
	}

	private void FixedUpdate()
	{
		if (canMove)
		{
			rigidbody.velocity = new Vector2(direction * speed, rigidbody.velocity.y);

			if (!Jumping && !Falling && Input.GetAxis("Jump") > 0f)
			{
				Jumping = true;
				rigidbody.AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
			}

			if (rigidbody.velocity.y < 0f)
			{
				Jumping = false;
				Falling = true;
			}

			if (Falling && rigidbody.velocity.y == 0f)
			{
				Falling = false;
			}
		}
	}

	private bool falling;
	public bool Falling
	{
		get { return falling; }
		set
		{
			if (value != falling)
			{
				falling = value;
				animator.SetBool("Fall", value);
			}
		}
	}

	private bool jumping;
	public bool Jumping
	{
		get { return jumping; }
		set
		{
			if (value != jumping)
			{
				jumping = value;
				animator.SetBool("Jump", value);
			}
		}
	}

	private bool walking;
	public bool Walking
	{
		get { return walking; }
		set
		{
			if (value != walking)
			{
				walking = value;
				animator.SetBool("Walk", value);
			}
		}
	}
}