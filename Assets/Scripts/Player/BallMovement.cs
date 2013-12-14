using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour
{
	float attractionForce = 20f;
	float fireForce = 40f;
	
	public void SetPosition(Vector3 position)
	{
		transform.position = position;
	}
	
	public void Freeze(Transform parent)
	{
		rigidbody.isKinematic = true;
		transform.parent = parent;
	}
	
	public void Unfreeze()
	{
		rigidbody.isKinematic = false;
		transform.parent = null;
	}
	
	public void MoveTowards(Vector3 position)
	{
		Vector3 toTarget = (position - transform.position).normalized;
		float velocityNegation = Vector3.Angle(toTarget, rigidbody.velocity) / 180f;
		Vector3 direction = (toTarget - rigidbody.velocity * velocityNegation).normalized;
		
		rigidbody.AddForce(direction * attractionForce, ForceMode.Acceleration);
	}
	
	public void Fire(Vector3 direction)
	{
		rigidbody.AddForce(direction * fireForce, ForceMode.VelocityChange);
	}
}
