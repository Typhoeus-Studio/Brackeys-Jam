using System;
using System.Collections;
using System.Collections.Generic;
using HyperTemplate.HyperMono.HyperManager;
using UnityEngine;
using UnityEngine.UI;

public class DevDebug : MonoBehaviour
{
    [SerializeField] private Text fpsText;

    private void Start()
    {
        if (!GameManager.Instance.moduleCenter.isDevMode)
        {
            gameObject.SetActive(false);
        }
    }


    private void Update()
    {
        fpsText.text = (1f / Time.unscaledDeltaTime).ToString();
    }
}