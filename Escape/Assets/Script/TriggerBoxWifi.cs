using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxWifi : MonoBehaviour
{

    [SerializeField] private GameObject cable;   
    [SerializeField] private GameObject ecranAllume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "cable")
        {
            cable.transform.position = new Vector3(-8, 10.17f, 38);
            cable.transform.rotation = Quaternion.Euler(90,0,19);
            ecranAllume.GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
    }
}
