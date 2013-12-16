using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour
{

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			Application.LoadLevel(Application.loadedLevel);
	}
}
