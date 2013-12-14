using UnityEngine;
using UnityEditor;
using System.Collections;

public class ModelImporterSettings : AssetPostprocessor
{
	
	void OnPreprocessModel()
	{
		ModelImporter mi = (ModelImporter)assetImporter;
		mi.importMaterials = false;
		mi.animationType = ModelImporterAnimationType.None;
	}
}
