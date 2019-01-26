using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Memories : MonoBehaviour
{
    public float memoryTimer;
    public float fadeRate;
    public Image image;
    public PPSVignette vg;
    public Region region;

    private float targetAlpha;

    public void FadeOut()
    {
        //Debug.Log("image fade out");
        targetAlpha = 0.0f;
        StartCoroutine(Anim(1));
    }

    public void FadeIn()
    {
        //Debug.Log("image fade in");
        targetAlpha = 1.0f;
        StartCoroutine(Anim());
    }

    IEnumerator Anim(int a = 0)
    {
        Color currentColor = image.color;
        float alphaDiff = Mathf.Abs(currentColor.a - targetAlpha);

        while (alphaDiff > 0.01f)
        {
            currentColor.a = Mathf.Lerp(currentColor.a, targetAlpha, fadeRate * Time.deltaTime);
            image.color = currentColor;

            currentColor = image.color;
            alphaDiff = Mathf.Abs(currentColor.a - targetAlpha);

            if (alphaDiff < 0.01f)
            {
                if (a==0)
                {
                    PlayMemory();
                    currentColor.a = 1f;
                }
                else
                {
                    currentColor.a = 0;
                    image.enabled = false;
                }

                image.color = currentColor;
                yield break;
            }

            yield return null;
        }
    }

    private void PlayMemory()
    {
        Debug.Log("playing memory");
        Invoke("Exit", 2f);
    }

    private void Exit()
    {
        Debug.Log("exiting memory");
        FadeOut();
        region.isGrayScale = false;
    }
}
