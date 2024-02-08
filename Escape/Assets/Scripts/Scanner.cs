using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField]
    GameObject scanZone;
    private bool isScanning = false;

    void Start()
    {
        EventManager.StartListening("manualScan", onShowZone);
    }

    void OnDestroy()
    {
        EventManager.StopListening("manualScan", onShowZone);
    }

    private void onShowZone(EventParam a)
    {
        scanZone.SetActive(!scanZone.activeSelf);
        if (!scanZone.activeSelf && isScanning)
        {
            EventScanScreen param = new EventScanScreen();
            param.Value = 3;
            EventManager.TriggerEvent("displayMessage", param);
            isScanning = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TireBarCode")
        {
            isScanning = true;
            TireProperties props = other.transform.parent.parent.GetComponent<TireProperties>();
            EventScanScreen param = new EventScanScreen();
            if (props.IsCorrect)
            {
                param.Value = 0;
            }
            else
            {
                param.Value = 1;
            }
            EventManager.TriggerEvent("displayMessage", param);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TireBarCode")
        {
            isScanning = false;
            EventScanScreen param = new EventScanScreen();
            param.Value = 3;
            EventManager.TriggerEvent("displayMessage", param);
        }
    }
}
