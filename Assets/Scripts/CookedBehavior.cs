using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LeanTween;

public class CookedBehavior : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ScaleIncrease(1f, new Vector2(0f, 2.35f)));
    }

    IEnumerator ScaleIncrease(float time, Vector3 targetPosition)
    {
        Transform transform = gameObject.transform;

        Vector3 startPosition = transform.localPosition;

        LeanTween.move(gameObject, targetPosition, time);

        yield return new WaitForSeconds(time);

        StartCoroutine(ScaleDecrease(1f, new Vector3(0f, 1.9f)));
    }

    IEnumerator ScaleDecrease(float time, Vector3 targetPosition)
    {
        Transform transform = gameObject.transform;

        Vector3 startPosition = transform.localPosition;

        LeanTween.move(gameObject, targetPosition, time);

        yield return new WaitForSeconds(time);

        StartCoroutine(ScaleIncrease(1f, new Vector3(0f, 2.35f)));
    }
}
