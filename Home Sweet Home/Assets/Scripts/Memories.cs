using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Memories : MonoBehaviour
{
    public float fadeRate;
    public Image image;

    private float targetAlpha;

    public void FadeOut()
    {
        targetAlpha = 0.0f;
        StartCoroutine("Anim");
    }

    public void FadeIn()
    {
        //Debug.Log("image fade in");
        targetAlpha = 1.0f;
        StartCoroutine("Anim");
    }

    IEnumerator Anim()
    {
        Color currentColor = image.color;
        float alphaDiff = Mathf.Abs(currentColor.a - targetAlpha);

        while (alphaDiff > 0.001f)
        {
            currentColor.a = Mathf.Lerp(currentColor.a, targetAlpha, fadeRate * Time.deltaTime);
            image.color = currentColor;

            if (alphaDiff < 0.001f)
            {
                currentColor.a = 1f;
                image.color = currentColor;
                yield break;
            }

            yield return null;

            currentColor = image.color;
            alphaDiff = Mathf.Abs(currentColor.a - targetAlpha);
        }
    }
}
