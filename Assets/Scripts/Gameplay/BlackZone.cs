using UnityEngine;
using System.Collections;

public class BlackZone : MonoBehaviour
{
	public Renderer quadRenderer;
	public ParticleSystem particle;
	
	void Start()
	{
		quadRenderer.material.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.z) / 2f;
		particle.emissionRate = 10f * transform.localScale.x * transform.localScale.y;
	}
	
	void Update()
	{
	
	}
}
