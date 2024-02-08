using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DigitcodeButton : MonoBehaviour
{
    [SerializeField] private Digicode _digicode;
    [SerializeField] private int value;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _digicode.AjoutNombre(value);
        }
    }
}
