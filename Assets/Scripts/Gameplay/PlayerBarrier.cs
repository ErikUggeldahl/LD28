using UnityEngine;
using System.Collections;

public class PlayerBarrier : MonoBehaviour
{
	
	bool Activate
	{
		set
		{
			renderer.enabled = value;
			collider.enabled = value;
		}
	}
	
	public bool hasKey = false;
	public KeyZoneTrigger unlockTrigger;
	
	void Start()
	{
		renderer.material.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.y) / 4f;
		
		if (!hasKey)
			return;
		
		unlockTrigger.OnKeyEnter += OnKeyIn;
		unlockTrigger.OnKeyExit += OnKeyOut;
	}
	
	void OnKeyIn()
	{
		Activate = false;
	}
	
	void OnKeyOut()
	{
		Activate = true;
	}
}
