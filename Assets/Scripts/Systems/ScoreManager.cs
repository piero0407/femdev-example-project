using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class ScoreManager : ScriptableObject
{
	private int score;
	public int Score
	{
		get { return score; }
		set { score = value; }
	}

	private void OnEnable()
	{
		score = 0;
	}
}