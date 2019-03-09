using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	[SerializeField] new Rigidbody2D rigidbody;
	[SerializeField] new Collider2D collider;
	[SerializeField] Animator animator;

	[SerializeField] PlayerMovement movement;

	[SerializeField] int maxHP = 10;
	[SerializeField] float invulnerabilityFrames;

	private int hp;

	private void Awake()
	{
		hp = maxHP;
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			hp--;
			collider.enabled = false;
			movement.canMove = false;
			animator.SetBool("Hit", true);
			var direction = Mathf.Sign(transform.position.x - other.transform.position.x);
			rigidbody.AddForce(new Vector2(direction, 1f).normalized * 2f, ForceMode2D.Impulse);
			StartCoroutine(EnableCollider());
		}
	}

	IEnumerator EnableCollider()
	{
		yield return new WaitForSeconds(invulnerabilityFrames);
		collider.enabled = true;
		movement.canMove = true;
		animator.SetBool("Hit", false);
	}

}