using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
	public Transform a;
	public Transform b;
	
	public float time;
	public float endDelay;
	
	void Start()
	{
		time = 1f / time;
		StartCoroutine(MoveTo(a, b));
	}
	
	IEnumerator MoveTo(Transform fromT, Transform toT)
	{
		float t = 0;
		
		while (t < 1f)
		{
			t += time * Time.deltaTime;
			transform.position = Vector3.Lerp(fromT.position, toT.position, t);
			yield return null;
		}
		
		yield return new WaitForSeconds(endDelay);
		StartCoroutine(MoveTo(toT, fromT));
	}
}
