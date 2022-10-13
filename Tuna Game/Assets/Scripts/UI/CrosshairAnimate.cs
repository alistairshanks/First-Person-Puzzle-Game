using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairAnimate : MonoBehaviour
{
    //this script changes size of object over time

    // the scale we want to go to
    public float targetScale;

    //how long to get there
    public float timeToLerp = 0.5f;

    //a variable to multiply the starting scale by
    float scaleModifier = 1;



    void PlayerLooksAtInteractable()
    {
        targetScale = 5;
        StartCoroutine(LerpFunction(targetScale, timeToLerp));
    }

    void PlayerLooksAwayFromInteractable()
    {
        targetScale = 1;
        StartCoroutine(LerpFunction(targetScale, timeToLerp));
    }

    IEnumerator LerpFunction(float endValue, float duration)
    {
        // set time to 0 for start of animation/lerp cycle
        float time = 0;
        float startValue = scaleModifier;
        Vector3 startScale = transform.localScale;
        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = startScale * endValue;
        scaleModifier = endValue;
    }
}
