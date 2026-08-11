using UnityEngine;
using UnityEditor;

public class LightmapUVFixer
{
    [MenuItem("Tools/Fix Lightmap UVs")]
    static void FixLightmapUVs()
    {
        if (Selection.activeGameObject == null) return;

        MeshFilter mf = Selection.activeGameObject.GetComponent<MeshFilter>();
        if (mf != null && mf.sharedMesh != null)
        {
            Undo.RecordObject(mf.sharedMesh, "Generate Lightmap UVs");
            Unwrapping.GenerateSecondaryUVSet(mf.sharedMesh);
            EditorUtility.SetDirty(mf.sharedMesh);
            Debug.Log("Lightmap UVs generated for " + mf.sharedMesh.name);
        }
    }
}