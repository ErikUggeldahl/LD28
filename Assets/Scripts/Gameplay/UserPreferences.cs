using UnityEngine;
using System.Collections;

public class UserPreferences : MonoBehaviour
{
	
	static UserPreferences instance;
	public static UserPreferences Instance { get { return instance; } }
	
	float mouseSensitivity = 1.5f;
	public float MouseSensitivity { get { return mouseSensitivity; } }
	
	void Awake()
	{
		instance = this;
	}
	
	void OnDestroy()
	{
		instance = null;
	}
}
