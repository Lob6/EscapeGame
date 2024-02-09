using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject closeBook;
    public GameObject openBook;
    public bool isOpen = false;
    
    public void Open()
    {
        closeBook.SetActive(false);
        openBook.SetActive(true);
        isOpen = true;
    }
    
    public void Close()
    {
        openBook.SetActive(false);
        closeBook.SetActive(true);
        isOpen = false;
    }
}
