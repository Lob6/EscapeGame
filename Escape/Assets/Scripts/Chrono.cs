using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chrono : MonoBehaviour
{
    private static float chrono_s;
    public static float CHRONO => chrono_s;
    private bool isRunning;
    [SerializeField] TMP_Text textChrono;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("StartChrono", OnStart);
        EventManager.StartListening("StopChrono", OnStop);
        EventManager.StartListening("ResetChrono", OnReset);
    }

    void OnDestroy()
    {
        EventManager.StopListening("StartChrono", OnStart);
        EventManager.StopListening("StopChrono", OnStop);
        EventManager.StopListening("ResetChrono", OnReset);
    }

    // Update is called once per frame
    void Update()
    {   
        if(isRunning)
        {
            chrono_s += Time.deltaTime;
        }
        DisplayChrono();
    }

    private void OnStart(EventParam param)
    {
        isRunning = true;
    }

    private void OnStop(EventParam param)
    {
        isRunning = false;
    }

    private void OnReset(EventParam param)
    {
        chrono_s = 0;
    }

    private void DisplayChrono()
    {
        int ms = (int)(chrono_s*1000) % 1000;
        int seconds = (int)chrono_s % 60;
        int minutes = (int)chrono_s / 60;

        textChrono.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + ms.ToString("000");
    }
}
