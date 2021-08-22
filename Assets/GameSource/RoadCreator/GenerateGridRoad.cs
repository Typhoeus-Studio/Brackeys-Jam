using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenerateGridRoad : MonoBehaviour
{
    [SerializeField] private float width, height;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform parentObj;
    [SerializeField] private Vector3 scale;
    

    [ContextMenu("Generate")]
    private void Generate()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Vector3 pos = new Vector3(j * offset.x, offset.y, i * offset.z);
                var obj = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                obj.transform.position = pos;
                obj.transform.parent = parentObj;
                obj.transform.localScale = scale;
            }
        }
    }

    [ContextMenu("Clear")]
    private void ClearAllChilds()
    {
        for (int i = 0; i < parentObj.childCount; i++)
        {
            DestroyImmediate(parentObj.GetChild(i).gameObject);
        }
    }
}