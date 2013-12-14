using UnityEngine;
using UnityEditor;
using System.Collections;

public class ColliderFill : EditorWindow
{
	[MenuItem ("Window/Collider Fill")]
	static void Init()
	{
        EditorWindow.GetWindow(typeof(ColliderFill));
    }
	
	void OnGUI()
	{
		if (GUILayout.Button("Create Cube"))
		{
			CreateCube();
		}
		if (GUILayout.Button("Fill Collider"))
		{
			FillCollider();
		}
	}
	
	void CreateCube()
	{
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		Undo.RegisterCreatedObjectUndo(cube, "Create cube");
	}
	
	void FillCollider()
	{
		foreach (GameObject go in Selection.gameObjects)
		{
			BoxCollider collider = go.GetComponent<BoxCollider>();
			if (collider == null)
				continue;
			
			Vector3 size = Vector3.Scale(collider.size, go.transform.localScale);
			size.x = Mathf.Round(size.x * 2f) / 2f;
			size.y = Mathf.Round(size.y * 2f) / 2f;
			size.z = Mathf.Round(size.z * 2f) / 2f;
			
			Undo.RegisterUndo(go.transform, "Change object scale");
			go.transform.position += Vector3.Scale(collider.center, go.transform.localScale);
			go.transform.localScale = size;
			collider.size = Vector3.one;
			collider.center = Vector3.zero;
		}
	}
}
