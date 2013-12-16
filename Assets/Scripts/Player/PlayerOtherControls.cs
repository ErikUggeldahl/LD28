using UnityEngine;
using System.Collections;

public class PlayerOtherControls : MonoBehaviour
{

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
			Application.LoadLevel(Application.loadedLevel);
		
		if (Input.GetKeyDown(KeyCode.M))
			Application.LoadLevel(0);
		
		if (Input.GetKeyDown(KeyCode.LeftControl))
			Screen.lockCursor = true;
	}
}
