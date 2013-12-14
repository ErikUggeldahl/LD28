using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	float maxSpeed = 10f;
	float moveSpeed = 10f;
	
	void Start()
	{
	
	}
	
	void FixedUpdate()
	{
		Vector3 movement = Vector3.zero;
		movement.z += Input.GetAxis("Vertical");
		movement.x += Input.GetAxis("Horizontal");
		movement.Normalize();
		
		movement *= moveSpeed * Time.fixedDeltaTime;
		if (rigidbody.velocity.magnitude + movement.magnitude > maxSpeed)
			return;
		
		rigidbody.AddForce(movement, ForceMode.VelocityChange);
	}
	
	void Run()
	{
		Vector3 movement = Vector3.zero;
		movement.z += Input.GetAxis("Vertical");
		movement.x += Input.GetAxis("Horizontal");
		movement.Normalize();
		
		movement *= moveSpeed * Time.fixedDeltaTime;
		if (rigidbody.velocity.magnitude + movement.magnitude > maxSpeed)
			return;
		
		rigidbody.AddForce(movement, ForceMode.VelocityChange);
	}
	
	void OnGUI()
	{
		GUILayout.Label(rigidbody.velocity.magnitude.ToString());
	}
}
