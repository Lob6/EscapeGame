using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class clébonne : MonoBehaviour
{
    public GameObject lettreE;
    public GameObject google;
    public GameObject lettreR;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ordi")
        {
            lettreE.SetActive(false);
            lettreR.SetActive(true);
            google.SetActive(false);
        }
    }
}
