using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
	
	enum State
	{
		Idle,
		Seeking,
		Hit
	}
	State state;
	
	Transform player;
	
	float activationRadius = 16f;
	float recoveryTime = 1f;
	float speed = 20f;
	
	public Animation monsterAnimation;
	
	public AudioSource alertSound;
	public AudioSource attackedSound;
	
	void Start()
	{
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}
	
	void Update()
	{
		if (state == State.Idle)
			Watch();
		else if (state == State.Seeking)
			Seek();
	}
	
	void Watch()
	{
		if (Vector3.Distance(player.position, transform.position) < activationRadius)
		{
			SetState(State.Seeking);
		}
	}
	
	void Seek()
	{
		transform.LookAt(player.position);
		Vector3 target = Vector3.Scale(player.position, new Vector3(1f, 0f, 1f));
		Vector3 direction = (target - transform.position).normalized;
		rigidbody.AddForce(direction * speed, ForceMode.Acceleration);
	}
	
	void OnCollisionEnter(Collision collision)
	{
		
		if (collision.gameObject.tag != "Ball")
			return;

		if (state == State.Seeking)
			StartCoroutine(HitRecover());
		if (state == State.Idle)
			SetState(State.Seeking);
	}
	
	IEnumerator HitRecover()
	{
		SetState(State.Hit);
		attackedSound.Play();
		yield return new WaitForSeconds(recoveryTime);
		SetState(State.Idle);
	}
	
	void SetState(State state)
	{
		this.state = state;
		if (state == State.Idle)
		{
			monsterAnimation.Play("Idle");
		}
		else if (state == State.Hit)
		{
			monsterAnimation.Play("Idle");
		}
		else if (state == State.Seeking)
		{
			monsterAnimation.Play("Stand");
			monsterAnimation.PlayQueued("Run");
			alertSound.Play();
		}
	}
}
