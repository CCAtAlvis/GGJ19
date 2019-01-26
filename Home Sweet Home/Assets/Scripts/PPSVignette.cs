using UnityEngine;
using UnityEngine.PostProcessing;
using System.Collections;

public class PPSVignette : MonoBehaviour
{
    public PostProcessingProfile profile;
    public Memories m;

    private VignetteModel.Settings vgs;

    void Start()
    {
        vgs = profile.vignette.settings;
        vgs.intensity = 0;
        profile.vignette.settings = vgs;
    }

    public void StartVignetteAnim()
    {
        //Debug.Log("anim");
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        //Debug.Log("fade in");
        float i = 0;
        while (i < .9999f)
        {
            float a = vgs.intensity;
            i = Mathf.Lerp(a, 1f, Time.deltaTime);
            //print(i);
            vgs.intensity = i;
            profile.vignette.settings = vgs;

            if (i>.9f)
            {
                StartCoroutine("FadeOut");
                m.FadeIn();
                yield break;
            }

            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        //Debug.Log("fade out");
        float i = 1f;
        while (i > .0001f)
        {
            float a = vgs.intensity;
            i = Mathf.Lerp(a, 0, Time.deltaTime);
            //print(i);
            vgs.intensity = i;
            profile.vignette.settings = vgs;

            if (i < .09f)
            {
                vgs.intensity = 0;
                profile.vignette.settings = vgs;
                yield break;
            }

            yield return null;
        }
    }
}
