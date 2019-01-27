using UnityEngine;
using UnityEngine.PostProcessing;

public class Region : MonoBehaviour
{
    public bool isGrayScale = true;
    public PostProcessingProfile profile;


    void OnTriggerEnter(Collider other)
    {
        ColorGradingModel.Settings cgs = profile.colorGrading.settings;
        cgs.basic.saturation = 1;

        if (isGrayScale)
            cgs.basic.saturation = 0;

        profile.colorGrading.settings = cgs;
    }

    //void OnTriggerStay(Collider other)
    //{
    //    if (isGrayScale)
    //        return;

    //    ColorGradingModel.Settings cgs = profile.colorGrading.settings;
    //    cgs.basic.saturation = 1;
    //    profile.colorGrading.settings = cgs;
    //}

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("exiting region");
        ColorGradingModel.Settings cgs = profile.colorGrading.settings;
        cgs.basic.saturation = 0;
        profile.colorGrading.settings = cgs;
        Debug.Log(cgs.basic.saturation);
        //Debug.Log("region exited");
    }

    public void Colorify()
    {
        ColorGradingModel.Settings cgs = profile.colorGrading.settings;
        cgs.basic.saturation = 1;
        profile.colorGrading.settings = cgs;
    }
}
