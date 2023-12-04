using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LeanTween;

public class LetterScale : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ScaleIncrease(.5f, new Vector3(1.65f, 1.65f, 1f)));
    }

    IEnumerator ScaleIncrease(float time, Vector3 targetScale)
    {
        Transform transform = gameObject.transform;

        Vector3 startScale = transform.localScale;

        LeanTween.scale(gameObject, targetScale, time);

        yield return new WaitForSeconds(time);

        StartCoroutine(ScaleDecrease(.5f, new Vector3(1.4f, 1.4f, 1f)));
    }

    IEnumerator ScaleDecrease(float time, Vector3 targetScale)
    {
        Transform transform = gameObject.transform;

        Vector3 startScale = transform.localScale;

        LeanTween.scale(gameObject, targetScale, time);

        yield return new WaitForSeconds(time);

        StartCoroutine(ScaleIncrease(.5f, new Vector3(1.65f, 1.65f, 1f)));
    }
}
