using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using UnityEngine;
using TMPro;

public class OpenDoor : MonoBehaviour
{

    [Header("Les 5 zones de texte")] 
    public List<TMP_Text> lettres;

    private int currentLetter = 0;

    private bool isDoorOpen = false;

    public GameObject panneauFin;
    public GameObject panneauInput;

    public NonNativeKeyboard keyBoard;
   
    
    void Start()
    {
        keyBoard.OnTextUpdated += AddLetters;
    }

    private void AddLetters(string obj)
    {
        if (obj == string.Empty)
        {
            return;
        }
        lettres[currentLetter].text = obj.ToUpper();
        keyBoard.Clear();
        currentLetter++;
        if (currentLetter == 5)
        {
            Verification();
        }
    }
    void OnDestroy()
    {
        keyBoard.OnTextUpdated -= AddLetters;
    }

    public void Verification()
    {
        if ((lettres[0].text == "C") && (lettres[1].text == "Y") && (lettres[2].text == "B") && (lettres[3].text == "E") &&
            (lettres[4].text == "R"))
        {
            isDoorOpen = true;
            panneauFin.SetActive(true);
            panneauInput.SetActive(false);
            
        }
        else
        {
            StartCoroutine(Wrong());
        }
    }

    private IEnumerator Wrong()
    {
        yield return new WaitForSeconds(1);
        foreach (var l in lettres)
        {
            l.text = string.Empty;
        }

        currentLetter = 0;
    }
}
