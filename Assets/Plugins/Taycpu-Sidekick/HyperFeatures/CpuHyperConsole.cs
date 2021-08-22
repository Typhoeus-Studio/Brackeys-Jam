using System;
using System.Collections;
using System.Timers;
using CustomFeatures.Timer;
using HyperTemplate.HyperMono.HyperManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HyperFeatures
{
    public class CpuHyperConsole : MonoBehaviour
    {
        [SerializeField] private RectTransform console;
        [SerializeField] private RectTransform gameUI;

        [Header("Resolution")] [SerializeField]
        private InputField widthInput;

        [SerializeField] private InputField heightInput;
        [SerializeField] private Toggle fullscreenToggle;
        [SerializeField] private Button applyRes;


        [Header("Level")] [SerializeField] private InputField levelInput;

        [SerializeField] private Button applyLevel;


        [Header("Misc")] [SerializeField] private Toggle hideGameUIToggle;
        [SerializeField] private InputField bgColor;
        [SerializeField] private Button applyColor;


        private bool changingLevel;

        private void Awake()
        {
            applyRes.onClick.AddListener(ChangeResOnUI);
            applyLevel.onClick.AddListener(ChangeLevelOnUI);
            applyColor.onClick.AddListener(ChangeBGColorOnUI);
            hideGameUIToggle.onValueChanged.AddListener(HideGameUI);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F10))
            {
                console.gameObject.SetActive(!console.gameObject.activeInHierarchy);
            }
        }

        public void ChangeResOnUI()
        {
            int width = Int32.Parse(widthInput.text);
            int height = Int32.Parse(heightInput.text);
            bool fs = fullscreenToggle.isOn;
            ChangeResolution(width, height, fs);
        }

        public void ChangeLevelOnUI()
        {
            int index = Int32.Parse(levelInput.text);
            ChangeLevel(index);
        }

        public void ChangeBGColorOnUI()
        {
            Color newCol;
            if (ColorUtility.TryParseHtmlString(bgColor.text, out newCol))
                Camera.main.backgroundColor = newCol;
        }

        public void HideGameUI(bool isActive)
        {
            gameUI.gameObject.SetActive(isActive);
        }

        private void ChangeResolution(int width, int height, bool fullScreen)
        {
            Screen.SetResolution(width, height, fullScreen);
        }

        private void ChangeLevel(int i)
        {
            if (changingLevel) return;
            GameManager.Instance.levelController.debugLevelIndex = i-1;

            GameManager.Instance.levelData.samplePlayer.Die();
            //   StartCoroutine(ChangeLevel());
        }

        IEnumerator ChangeLevel()
        {
            changingLevel = true;
            yield return new WaitForEndOfFrame();
            GameManager.Instance.ChangeState(0);

            changingLevel = false;
        }
    }
}