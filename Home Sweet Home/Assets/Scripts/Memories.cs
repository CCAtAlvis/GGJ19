using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Memories : MonoBehaviour {
    public GameObject obj,player;
    public float FadeRate;
    public Image image;
    private float targetAlpha;

    void Update()
    {
        Color curColor = image.color;
        float alphaDiff = Mathf.Abs(curColor.a - targetAlpha);
        if (alphaDiff > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
            image.color = curColor;
        }
    }

    public void FadeOut()
    {
        targetAlpha = 0.0f;
    }

    public void FadeIn()
    {
        targetAlpha = 1.0f;
    }

    private void OnTriggerEnter(Collider col)
	{
        player.GetComponent<CharacterMovement>().disableMovement = true;
        obj.SetActive(true);
        targetAlpha = image.color.a;
        FadeIn();
    }
}
