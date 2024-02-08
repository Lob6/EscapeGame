using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanScreen : MonoBehaviour
{
    [SerializeField] MeshRenderer screenRenderer;
    [SerializeField] Texture conform;
    [SerializeField] Texture error;
    [SerializeField] Texture noScan;
    [SerializeField] Texture waiting;
    void Start()
    {
        EventManager.StartListening("displayMessage", onDisplayMessage);
    }

    void OnDestroy()
    {
        EventManager.StopListening("displayMessage", onDisplayMessage);
    }

    void onDisplayMessage(EventParam param)
    {
        EventScanScreen trueParams = param as EventScanScreen;
        switch (trueParams.Value)
        {
            case 0:
                screenRenderer.sharedMaterial.mainTexture = conform;
                break;
            case 1:
                screenRenderer.sharedMaterial.mainTexture = error;
                break;
            case 2:
                screenRenderer.sharedMaterial.mainTexture = noScan;
                break;
            case 3:
                screenRenderer.sharedMaterial.mainTexture = waiting;
                break;
        }
    }
}
