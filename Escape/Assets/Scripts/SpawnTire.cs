using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTire : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject spawnTirePrefab;
    [SerializeField] private Transform tiresContainer;
    [SerializeField] private Transform spawnPoint;
    private Coroutine spawner;

    public void SpawnTires()
    {
        spawner = StartCoroutine(GenerateTires());
    }

    private IEnumerator GenerateTires()
    {
        for(int i = 0; i <10 ; i++) { 
            GameObject go = Instantiate(spawnTirePrefab, tiresContainer);
            go.transform.position = spawnPoint.position;
            yield return new WaitForSeconds(0.5f);
        }       
    }

    public IEnumerator DestroyTires()
    {
        if(spawner != null)
        {
            StopCoroutine(spawner);
        }
        while(tiresContainer.childCount > 0)
        {
            Destroy(tiresContainer.GetChild(0).gameObject);
            yield return null;
        }
    }
}
