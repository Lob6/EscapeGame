using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Digicode : MonoBehaviour
{
    [Header("Boutons du digicode")] 
    public Button bout1;
    public Button bout2;
    public Button bout3;
    public Button bout4;
    public Button bout5;
    public Button bout6;
    public Button bout7;
    public Button bout8;
    public Button bout9;
    public Button bout0;

    public Button Erase;

    public int nbEssai = 0;

    private string Serie = "";

    public TMP_Text visible;

    public GameObject panneauLettre;
    public GameObject panneauDigicode;

    private void Update()
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

    public void Ajout1()
    {
        Serie += "1";
    }
    public void Ajout2()
    {
        Serie += "2";
    }public void Ajout3()
    {
        Serie += "3";
    }public void Ajout4()
    {
        Serie += "4";
    }public void Ajout6()
    {
        Serie += "6";
    }public void Ajout7()
    {
        Serie += "7";
    }public void Ajout8()
    {
        Serie += "8";
    }public void Ajout9()
    {
        Serie += "9";
    }public void Ajout0()
    {
        Serie += "0";
    }public void Ajout5()
    {
        Serie += "5";
    }


    public void EraseFunc()
    {
        Serie = "";
    }
}
