using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class LeftHandManager : MonoBehaviour
{
    private InputDevice mainDevice;
    private bool isTriggered;
    [SerializeField]
    InputDeviceCharacteristics controllerCharacteristics;

	// Start is called before the first frame update
	void Start()
    {
        StartCoroutine(DetectDevice());
        isTriggered = false;
	}

    // Update is called once per frame
    void Update()
    {

        bool triggerValue;
        if (mainDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue && !isTriggered)
        {
            EventManager.TriggerEvent("manualScan");
        }
        if (mainDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && !triggerValue && isTriggered)
        {
            EventManager.TriggerEvent("manualScan");
        }

        Vector2 jsValue;
        if(mainDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out jsValue) && jsValue != Vector2.zero)
        {
            EventParamRobot paramRobot = new EventParamRobot();
            paramRobot.Value = jsValue;
            EventManager.TriggerEvent("RobotRotate", paramRobot);
        }
        isTriggered = triggerValue;
    }

    private IEnumerator DetectDevice()
    {
        List<InputDevice> devicesList = new List<InputDevice>();
        while (devicesList.Count == 0)
        {
            InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devicesList);
            if(devicesList.Count > 0)
            {
                mainDevice = devicesList[0];
            }
            yield return null;
        }
    }
}
