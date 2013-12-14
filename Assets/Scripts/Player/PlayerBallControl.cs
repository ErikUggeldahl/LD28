using UnityEngine;
using System.Collections;

public class PlayerBallControl : MonoBehaviour
{
	public Transform attachmentPoint;
	
	public GameObject ballObject;
	BallMovement ball;
	
	public FirstPersonCamera fpCamera;
	
	int maxFireCharges = 2;
	int fireCharges;
	
	float catchForceDampening = 7.5f;
	
	void Start()
	{
		ball = ((GameObject)Instantiate(ballObject, attachmentPoint.position, attachmentPoint.rotation)).GetComponent<BallMovement>();
		fireCharges = maxFireCharges;
	}
	
	void Update()
	{
		AttractBall();
		FireBall();
	}
	
	void AttractBall()
	{
		if (Input.GetMouseButton(1))
		{
			ball.MoveTowards(attachmentPoint.position);
		}
	}
	
	public void AttachEnter()
	{
		rigidbody.AddForce(ball.rigidbody.velocity / catchForceDampening, ForceMode.VelocityChange);
		ball.SetPosition(attachmentPoint.position);
		ball.Freeze(attachmentPoint);
		fireCharges = maxFireCharges;
	}
	
	void FireBall()
	{
		if (Input.GetMouseButtonDown(0) && fireCharges > 0)
		{
			ball.Unfreeze();
			ball.Fire(transform.TransformDirection(fpCamera.Direction));
			fireCharges --;
		}
	}
}
