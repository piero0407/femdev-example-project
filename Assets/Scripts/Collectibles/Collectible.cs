using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Collectible : MonoBehaviour
{
	[SerializeField] ScoreManager scoreManager;
	[SerializeField] int score = 1;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			scoreManager.Score += score;
			gameObject.SetActive(false);
		}
	}
}