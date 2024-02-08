using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCube : MonoBehaviour
{
    [SerializeField]
    GameObject cube;

    void Start()
    {
        EventManager.StartListening("showCube",onShowCube);
    }

    void OnDestroy()
    {
        EventManager.StopListening("showCube", onShowCube);
    }

    private void onShowCube(EventParam a)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
