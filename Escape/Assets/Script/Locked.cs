using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locked : MonoBehaviour
{
    [SerializeField]private GameObject keyBoard;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keyBoard.SetActive(true);
        }
    }
}
