using UnityEngine;
using System.Collections;

public class FirstPersonCamera : MonoBehaviour
{
	const float SLOPE = -1f/90f;
	const float B = 4;
	
	public Vector3 Direction
	{
		get
		{
			float angle = transform.rotation.eulerAngles.x * Mathf.Deg2Rad;
			return new Vector3(0f, Mathf.Sin(-angle), Mathf.Cos(angle));
				
		}
	}
	
	void Update()
	{
		Quaternion rotation = Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") *
			UserPreferences.Instance.MouseSensitivity, Vector3.right);
		transform.rotation *= rotation;
	}
}
