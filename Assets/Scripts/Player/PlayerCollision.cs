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
	public int MaxHP
	{
		get { return maxHP; }
		private set { maxHP = value; }
	}

	private int hp;
	public int HP
	{
		get { return hp; }
		private set { hp = value; }
	}

	[SerializeField] float invencibleDuration;

	private void Awake()
	{
		HP = MaxHP;
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			HP--;
			Debug.Log("HP Left: " + HP);

			collider.enabled = false;
			movement.canMove = false;
			animator.SetBool("Hit", true);

			var direction = Mathf.Sign(transform.position.x - other.transform.position.x);
			rigidbody.velocity = Vector2.zero;
			rigidbody.AddForce(new Vector2(direction, 1f).normalized * 5f, ForceMode2D.Impulse);

			StartCoroutine(EnableCollider());
		}
	}

	IEnumerator EnableCollider()
	{
		yield return new WaitForSeconds(invencibleDuration);

		if (HP <= 0)
		{
			animator.SetBool("Hit", false);
			animator.SetTrigger("Death");
			movement.canMove = false;
			collider.enabled = false;
		}
		else
		{
			animator.SetBool("Hit", false);
			collider.enabled = true;
			movement.canMove = true;
		}
	}
}