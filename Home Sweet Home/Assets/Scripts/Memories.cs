using UnityEngine;
using UnityEngine.UI;

public class Memories : MonoBehaviour
{
    public float fadeRate;
    public Image image;

    private float targetAlpha;
    private bool fadeTransition = false;

    void Update()
    {
        if (!fadeTransition)
            return;

        Color currentColor = image.color;
        float alphaDiff = Mathf.Abs(currentColor.a - targetAlpha);

        if (alphaDiff > 0.0001f)
        {
            currentColor.a = Mathf.Lerp(currentColor.a, targetAlpha, fadeRate * Time.deltaTime);
            image.color = currentColor;
        }
        else
        {
            fadeTransition = false;
        }
    }

    public void FadeOut()
    {
        targetAlpha = 0.0f;
        fadeTransition = true;
    }

    public void FadeIn()
    {
        targetAlpha = 1.0f;
        fadeTransition = true;
    }

    //private void OnTriggerEnter(Collider col)
    //{
    //    player.GetComponent<CharacterMovement>().disableMovement = true;
    //    obj.SetActive(true);
    //    targetAlpha = image.color.a;
    //    FadeIn();
    //}
}
