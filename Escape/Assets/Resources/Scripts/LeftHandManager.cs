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
    [SerializeField]
    InputDeviceCharacteristics controllerCharacteristics;

    public Book book;

	// Start is called before the first frame update
	void Start()
    {
        StartCoroutine(DetectDevice());
	}

    // Update is called once per frame

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
  
    
    public void OnGrab()
    {
        if (book.transform.parent == null)
        {
            book.Open();
        }
    }
    public void OnUnGrabe()
    {
        if (book.isOpen)
        {
            book.Close();
        }
    }
}
