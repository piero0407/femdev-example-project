using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
	[SerializeField] PlayerCollision player;

	[SerializeField] Image startBar;
	[SerializeField] Image middleBar;
	[SerializeField] Image endBar;

	private void Update()
	{
		if (player.HP < player.MaxHP)
		{
			endBar.enabled = false;
		}

		if (player.HP == 0)
		{
			startBar.enabled = false;
			middleBar.enabled = false;
		}

		middleBar.fillAmount = (float) player.HP / player.MaxHP;
	}
}