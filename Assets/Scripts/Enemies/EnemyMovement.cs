using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] Animator animator;
	[SerializeField] new Rigidbody2D rigidbody;
	[SerializeField] float speed;
	[SerializeField] int direction;

	bool canMove = true;

	private void Awake()
	{
		animator.SetBool("Walk", true);
	}

	private void FixedUpdate()
	{
		if (canMove)
			rigidbody.velocity = new Vector2(direction * speed, rigidbody.velocity.y);
	}

}