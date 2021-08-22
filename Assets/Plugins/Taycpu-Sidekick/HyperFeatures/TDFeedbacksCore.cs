using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDFeedbacksCore<T> : MonoBehaviour where T : TDFeedback
{
    public List<T> customEvents;

    private bool onPlay;


    IEnumerator FeedbacksCoroutine(object[] parameter)
    {
        onPlay = true;
        for (int i = 0; i < customEvents.Count; i++)
        {
            if (customEvents[i].haveDelay)
                yield return new WaitForSeconds(customEvents[i].delay);
            if (parameter != null)
                customEvents[i].Play(parameter);
            else
            {
                customEvents[i].Play();
            }
        }

        onPlay = false;
        yield break;
    }


    public void PlayFeedbacks(object[] parameters = null)
    {
       // if (parameters == null)
     //       parameters = new object[0];
        if (!onPlay)
            StartCoroutine(FeedbacksCoroutine(parameters));
    }
}