using UnityEngine;
using System.Collections;

public class FirstPersonCamera : MonoBehaviour
{
	
	void Start()
	{
	
	}
	
	void Update()
	{
		Quaternion rotation = Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") *
			UserPreferences.Instance.MouseSensitivity, Vector3.right);
		transform.rotation *= rotation;
	}
}
