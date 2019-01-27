using UnityEngine;
using UnityEngine.PostProcessing;

public class PPSGrayscaling : MonoBehaviour
{
    public PostProcessingProfile profile;

    void Update()
    {
        ColorGradingModel.Settings cgs = profile.colorGrading.settings;
        cgs.basic.saturation = Mathf.Abs(Mathf.Sin(Time.time));
        
        profile.colorGrading.settings = cgs;
    }
}
