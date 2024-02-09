using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;

public class HandController : MonoBehaviour {

    private Animator animator;
    private InputDevice mainDevice;
    [SerializeField] private InputDeviceCharacteristics _characteristics;

	void Start ()
	{
        animator = GetComponent<Animator>();
        StartCoroutine(CheckForController());
	}
	
	void Update ()
	{
		bool isTrigger;
		if (mainDevice.TryGetFeatureValue(CommonUsages.triggerButton, out isTrigger))
		{
			animator.SetBool("isGrabbing", isTrigger);
		}
	}

	private IEnumerator CheckForController()
	{
		
		List<InputDevice> devicesList = new List<InputDevice>();

		while (devicesList.Count < 1)
		{
			InputDevices.GetDevicesWithCharacteristics(_characteristics, devicesList);
			yield return null;
		}
		mainDevice = devicesList[0];
	}
}
