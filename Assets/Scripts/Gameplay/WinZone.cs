using UnityEngine;
using System.Collections;

public class WinZone : MonoBehaviour
{
	public AudioSource sound;
	
	float delay = 2f;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			StartCoroutine(SwitchLevel());
	}
	
	IEnumerator SwitchLevel()
	{
		sound.Play();
		
		yield return new WaitForSeconds(delay);
		
		if (Application.loadedLevel < Application.levelCount - 1)
			Application.LoadLevel(Application.loadedLevel + 1);
		else
			Application.LoadLevel(0);
	}
}
