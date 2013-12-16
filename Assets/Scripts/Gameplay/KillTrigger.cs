using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour
{
	public AudioSource deathSound;
	
	float delay = 0.3f;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			StartCoroutine(Die());
	}
	
	IEnumerator Die()
	{
		deathSound.Play();
		yield return new WaitForSeconds(delay);
		Application.LoadLevel(Application.loadedLevel);
	}
}
