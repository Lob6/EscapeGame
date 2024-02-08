using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireProperties : MonoBehaviour
{
    bool isCorrect;
    bool isReadable;
    public bool IsReadable {  get { return isReadable; } }
    public bool IsCorrect { get { return isCorrect; } }
    // Start is called before the first frame update
    void Start()
    {
        isCorrect = Random.Range(0, 2) == 1;
        isReadable = Random.Range(0, 2) == 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
