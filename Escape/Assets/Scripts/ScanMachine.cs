using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanMachine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tire") {
            TireProperties props = other.transform.parent.parent.GetComponent<TireProperties>();
            EventScanScreen param = new EventScanScreen();
            if (props.IsReadable)
            {
                if(props.IsCorrect)
                {
                    param.Value = 0;
                }
                else
                {
                    param.Value = 1;
                }
            }
            else
            {
                param.Value = 2;
            }
            EventManager.TriggerEvent("displayMessage", param);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tire")
        {
            EventScanScreen param = new EventScanScreen();
            param.Value = 3;
            EventManager.TriggerEvent("displayMessage", param);
        }
    }
}
