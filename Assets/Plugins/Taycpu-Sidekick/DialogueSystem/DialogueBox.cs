using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueBox : MonoBehaviour
    {
        public Text text;
        public Image background;
        public Transform model;


        private bool isOn;

        public bool IsOn => isOn;

        public void GetTextBox(string str,Action whenTextFinish)
        {
            if (isOn) return;

            model.DOScale(Vector3.one, 0.2f)
                .OnComplete(() => { StartCoroutine(TextAnimation(text, str, WhenTextPrinted)); });


            void WhenTextPrinted()
            {
                isOn = false;
                whenTextFinish?.Invoke();
            }
        }


        IEnumerator TextAnimation(Text text, string str, Action finishEvent)
        {
            for (int i = 0; i < str.Length; i++)
            {
                text.text = str.Substring(0, i);
                yield return null;
            }

            finishEvent?.Invoke();
        }
    }
}