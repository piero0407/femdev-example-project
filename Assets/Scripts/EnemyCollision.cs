using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
	[SerializeField] Animator animator;
	[SerializeField] new Collider2D collider;

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("PlayerAttack"))
		{
			animator.SetTrigger("Death");
			collider.enabled = false;
		}
	}
}