using UnityEngine;

public class EventController : MonoBehaviour
{
    public PPSGrayscaling gs;
    public PPSVignette vg;

    private bool isTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player"))
            return;
        if (isTriggered)
            return;

        //disable player movement
        other.gameObject.GetComponent<CharacterMovement>().disableMovement = true;

        //start Vignette animation
        vg.StartVignetteAnim();
        
        isTriggered = true;
    }
}
