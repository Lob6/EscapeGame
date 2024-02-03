using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenDoor : MonoBehaviour
{

    [Header("Les 5 zones de texte")] 
    public TMP_InputField lettre1;
    public TMP_InputField lettre2;
    public TMP_InputField lettre3;
    public TMP_InputField lettre4;
    public TMP_InputField lettre5;

    private bool isDoorOpen = false;

    public GameObject panneauFin;
    public GameObject panneauInput;
   
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Verification()
    {
        if ((lettre1.text == "C") && (lettre2.text == "Y") && (lettre3.text == "B") && (lettre4.text == "E") &&
            (lettre5.text == "R"))
        {
            isDoorOpen = true;
            panneauFin.SetActive(true);
            panneauInput.SetActive(false);
            
        }
    }
}
