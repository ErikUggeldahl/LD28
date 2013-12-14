using UnityEngine;
using System.Collections;

public class PlayerBarrier : MonoBehaviour
{

	void Start()
	{
		renderer.material.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.y) / 4f;
		//renderer.material.SetTextureScale("_MainTex", new Vector2(10f, 1f));
	}
}
