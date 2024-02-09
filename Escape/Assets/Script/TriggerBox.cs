using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public Transform chaise;
    public Transform ordi;
    public GameObject perso;
    public GameObject livreOuvert;
    public Transform livreFerme;
    public Transform PanneauCles;
    public GameObject TexteLivre;
    
    
    
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
        switch (col.tag)
        {
            case "chaise":
                perso.transform.position = col.transform.position + 5 * Vector3.up;
                perso.transform.LookAt(ordi);
                break;
            case "box":
                perso.transform.position = new Vector3(-5, 12.5f, -33);
                perso.transform.rotation = Quaternion.Euler(new Vector3(33.5f,-86,-7));
                break;
            case "livre":
                livreOuvert.SetActive(true);
                livreFerme.gameObject.SetActive(false);
                TexteLivre.SetActive(false);
                break;
            case "clé":
                col.transform.position = new Vector3(-18.1f, 10.15f, -30);
                break;
            case "cléMort":
                col.transform.position = new Vector3(-18.8f, 10.15f, -30);
                break;
            case "cléDroite":
                col.transform.position = new Vector3(-16.6f, 10.15f, -30);
                break;
            case "cléGauche":
                col.transform.position = new Vector3(-17.3f, 10.15f, -30);
                break;
            
            default:
                break;
                
        }

    }
}
