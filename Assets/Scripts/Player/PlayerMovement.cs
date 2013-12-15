using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	float maxSpeed = 10f;
	float moveForce = 15f;
	
	float jumpForce = 15f;
	
	bool canJump = false;
	bool isJumpReady = true;
	float jumpCooldown = 0.2f;
	
	void Start()
	{
		Screen.lockCursor = true;
	}
	
	void Update()
	{
		Turn();
	}
	
	void FixedUpdate()
	{
		Run();
		Jump();
	}
	
	void Run()
	{
		Vector3 movement = Vector3.zero;
		movement.z += Input.GetAxis("Vertical");
		movement.x += Input.GetAxis("Horizontal");
		movement.Normalize();
		
		movement *= moveForce * Time.fixedDeltaTime;
		movement = transform.TransformDirection(movement);
		if (rigidbody.velocity.magnitude + movement.magnitude > maxSpeed)
			return;
		
		rigidbody.AddForce(movement, ForceMode.VelocityChange);
	}
	
	void Jump()
	{
		if (canJump && isJumpReady && Input.GetKey(KeyCode.Space))
		{
			rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
			StartCoroutine("JumpCooldown");
		}
	}
	
	IEnumerator JumpCooldown()
	{
		isJumpReady = false;
		yield return new WaitForSeconds(jumpCooldown);
		isJumpReady = true;
	}
	
	public void JumpEnter()
	{
		canJump = true;
	}
	
	public void JumpExit()
	{
		canJump = false;
	}
	
	void Turn()
	{
		transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * UserPreferences.Instance.MouseSensitivity);
	}
	
	void OnGUI()
	{
		GUI.color = Color.black;
		GUILayout.Label(rigidbody.velocity.magnitude.ToString());
		GUILayout.Label(canJump.ToString());
	}
}
