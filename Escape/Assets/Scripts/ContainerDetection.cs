using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerDetection : MonoBehaviour
{
    [SerializeField] private bool targetOk;
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
        if (other.tag == "Tire")
        {
            TireProperties props = other.transform.parent.parent.GetComponent<TireProperties>();
            if(props.IsCorrect == targetOk)
            {
                EventManager.TriggerEvent("AddTire");
                Destroy(other.gameObject);
            }
            else
            {
                Debug.Log("Fais mieux ton travail");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tire")
        {
            TireProperties props = other.transform.parent.parent.GetComponent<TireProperties>();
            Debug.Log(props.IsCorrect);
            if (props.IsCorrect == targetOk)
            {
                EventManager.TriggerEvent("RemoveTire");
            }
            else
            {
                Debug.Log("Fais mieux ton travail");
            }
        }
    }
}
