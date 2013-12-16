using UnityEngine;
using System.Collections;

public class BlackCube : MonoBehaviour
{
	public Renderer cubeRenderer;
	
	void Start()
	{
		cubeRenderer.material.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.z) / 2f;
	}
}
