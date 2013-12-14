using UnityEngine;
using System.Collections;

public class AttachmentTrigger : MonoBehaviour
{
	public PlayerBallControl toNotify;
	
	void OnTriggerEnter(Collider other)
	{
		toNotify.AttachEnter();
	}
}
