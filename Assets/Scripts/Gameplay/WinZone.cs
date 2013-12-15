using UnityEngine;
using System.Collections;

public class WinZone : MonoBehaviour
{

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (Application.loadedLevel < Application.levelCount - 1)
				Application.LoadLevel(Application.loadedLevel + 1);
			else
				Application.LoadLevel(0);
		}
	}
}
