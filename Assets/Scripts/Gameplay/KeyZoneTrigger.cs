using UnityEngine;
using System.Collections;

public class KeyZoneTrigger : MonoBehaviour
{
	public delegate void KeyEventHandler();
	public event KeyEventHandler OnKeyEnter;
	public event KeyEventHandler OnKeyExit;
	
	int keyCount = 0;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Key")
			return;
		
		if (OnKeyEnter != null && keyCount == 0)
			OnKeyEnter();
		
		keyCount++;
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.tag != "Key")
			return;
		
		keyCount--;
		
		if (OnKeyExit != null && keyCount == 0)
			OnKeyExit();
	}
}
