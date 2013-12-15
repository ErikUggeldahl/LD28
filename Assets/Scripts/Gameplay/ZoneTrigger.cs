using UnityEngine;
using System.Collections;

public class ZoneTrigger : MonoBehaviour
{
	public delegate void EventHandler();
	public event EventHandler OnEnter;
	public event EventHandler OnExit;
	
	public string tagFilter;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag != tagFilter)
			return;
		
		if (OnEnter != null)
			OnEnter();
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.tag != tagFilter)
			return;
		
		if (OnExit != null)
			OnExit();
	}
}
