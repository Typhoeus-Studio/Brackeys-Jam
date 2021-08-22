using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearFloatVars : MonoBehaviour
{
    [SerializeField] private List<FloatVariable> vars;
    [SerializeField] private LevelVariable levelVar;


    public void ClearAll()
    {
        for (int i = 0; i < vars.Count; i++)
        {
            vars[i].Clear();
        }

        levelVar.Clear();
    }
}