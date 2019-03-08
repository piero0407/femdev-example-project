using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] new Rigidbody2D rigidbody;
	[SerializeField] Animator animator;
	[SerializeField] float speed;

	private void Awake()
	{

	}

	private void Update()
	{
		Walking = Mathf.Abs(Direction) > 0;

		float newXScale;

		if (Direction != 0)
		{
			newXScale = Mathf.Sign(Direction) * Mathf.Abs(transform.localScale.x);
			transform.localScale = new Vector3(newXScale, transform.localScale.y, transform.localScale.z);
		}
	}

	private void FixedUpdate()
	{
		rigidbody.velocity = new Vector2(Direction * speed, 0f);
	}

	public float Direction
	{
		get
		{
			return Input.GetAxis("Horizontal");
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