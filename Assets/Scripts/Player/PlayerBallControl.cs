using UnityEngine;
using System.Collections;

public class PlayerBallControl : MonoBehaviour
{
	public Transform attachmentPoint;
	
	public GameObject ballObject;
	BallMovement ball;
	
	public bool spawnWithBall;
	bool hasBall;
	
	public FirstPersonCamera fpCamera;
	
	int maxFireCharges = 2;
	int fireCharges;
	
	public AudioSource fireSound;
	public AudioSource catchSound;
	
	float catchForceDampening = 7.5f;
	
	void Start()
	{
		if (spawnWithBall)
			ball = ((GameObject)Instantiate(ballObject, attachmentPoint.position, attachmentPoint.rotation)).GetComponent<BallMovement>();
		hasBall = spawnWithBall;
		
		fireCharges = maxFireCharges;
	}
	
	void Update()
	{
		if (!hasBall)
			return;
		
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
	
	public void AttachEnter(GameObject ballObj)
	{
		if (!hasBall)
		{
			ball = ballObj.GetComponent<BallMovement>();
			hasBall = true;
		}
		
		rigidbody.AddForce(ball.rigidbody.velocity / catchForceDampening, ForceMode.VelocityChange);
		ball.SetPosition(attachmentPoint.position);
		ball.Freeze(attachmentPoint);
		fireCharges = maxFireCharges;
		catchSound.Play();
	}
	
	void FireBall()
	{
		if (Input.GetMouseButtonDown(0) && fireCharges > 0)
		{
			ball.Unfreeze();
			ball.Fire(transform.TransformDirection(fpCamera.Direction));
			fireCharges --;
			fireSound.Play();
		}
	}
}
