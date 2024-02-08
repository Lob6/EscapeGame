using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Digicode : MonoBehaviour
{
    public int nbEssai = 0;

    private string Serie = "";

    public TMP_Text visible;

    public GameObject panneauLettre;
    public GameObject panneauDigicode;

    private void UpdateText()
    {
        visible.text = Serie;
    }

    public void Verif()
    {
        if ((Serie == "0000") || (Serie == "1234"))
        {
            panneauLettre.SetActive(true);
            panneauDigicode.SetActive(false);
        }
        else
        {
            Serie = "";
        }
    }

    public void AjoutNombre(int nombre)
    {
        if (nombre > 9)
        {
            switch (nombre)
            {
                case 10 :
                    Verif();
                    break;
                case 11 :
                    EraseFunc();
                    break;
            }
        }
        else
        {
            Serie += nombre.ToString();
            if (Serie.Length > 3)
            {
                Verif();
            }
        }
        UpdateText();
    }
    public void EraseFunc()
    {
        Serie = "";
    }

}
