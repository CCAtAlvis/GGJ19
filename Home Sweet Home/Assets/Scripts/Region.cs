using UnityEngine;
using UnityEngine.PostProcessing;

public class Region : MonoBehaviour
{
    public bool isGrayScale = true;
    public PostProcessingProfile profile;


    void OnTriggerEnter(Collider other)
    {
        if (isGrayScale)
            return;

        ColorGradingModel.Settings cgs = profile.colorGrading.settings;
        cgs.basic.saturation = 1;
        profile.colorGrading.settings = cgs;
    }

    void OnTriggerStay(Collider other)
    {
        if (isGrayScale)
            return;

        ColorGradingModel.Settings cgs = profile.colorGrading.settings;
        cgs.basic.saturation = 1;
        profile.colorGrading.settings = cgs;
    }

    void OnTriggerExit(Collider other)
    {
        ColorGradingModel.Settings cgs = profile.colorGrading.settings;
        cgs.basic.saturation = 0;
        profile.colorGrading.settings = cgs;
    }
}
