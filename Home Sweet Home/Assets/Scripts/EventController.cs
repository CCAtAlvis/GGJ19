using UnityEngine;

public class EventController : MonoBehaviour
{
    public int eventNo;
    public float eventLength;

    public PPSGrayscaling gs;
    public PPSVignette vg;

    private bool isTriggered = false;

    //void Start()
    //{

    //}

    //void Update()
    //{

    //}

    void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player"))
            return;
        if (isTriggered)
            return;

        vg.StartVignetteAnim();
        isTriggered = true;
    }
}
