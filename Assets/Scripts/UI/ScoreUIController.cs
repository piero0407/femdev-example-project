using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ScoreUIController : MonoBehaviour
{
	[SerializeField] ScoreManager scoreManager;
	[SerializeField] Text text;

	// Update is called once per frame
	void Update()
	{
		text.text = "Score: " + scoreManager.Score.ToString();
	}
}