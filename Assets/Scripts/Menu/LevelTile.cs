using UnityEngine;
using System.Collections;

public class LevelTile : MonoBehaviour
{
	public int level;
	public TextMesh text;
	
	Vector3 originalPos;
	Vector3 hoverPos;
	Vector3 downPos;
	
	void Start()
	{
		text.text = level.ToString();
		
		originalPos = transform.position;
		hoverPos = transform.position - Vector3.forward;
		downPos = transform.position + Vector3.forward;
	}
	
	void OnMouseEnter()
	{
		transform.position = hoverPos;
	}
	
	void OnMouseExit()
	{
		transform.position = originalPos;
	}
	
	void OnMouseDown()
	{
		transform.position = downPos;
	}
	
	void OnMouseUp()
	{
		Application.LoadLevel(level);
	}
}
