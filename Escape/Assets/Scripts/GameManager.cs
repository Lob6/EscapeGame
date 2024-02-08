using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SpawnTire Spawner;
    private bool inGame;
    private int countTire = 0;
    private TouchScreenKeyboard overlayKeyboard;
    private Dictionary<string,float> highScores = new Dictionary<string,float>();

    // Start is called before the first frame update
    void Start()
    {
        inGame = false;

        EventManager.StartListening("AddTire", AddTire);
        EventManager.StartListening("RemoveTire", RemoveTire);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("AddTire", AddTire);
        EventManager.StopListening("RemoveTire", RemoveTire);
    }

    public void OnStartPressed()
    {
        if(!inGame)
        {
            inGame=true;
            countTire = 0;
            Spawner.SpawnTires();
            EventManager.TriggerEvent("StartChrono");
        }
    }

    public void OnStopPressed()
    {
        inGame=false;
        StartCoroutine(Spawner.DestroyTires());
        EventManager.TriggerEvent("StopChrono");
        EventManager.TriggerEvent("ResetChrono");
    }

    private void AddTire(EventParam param)
    {
        countTire++;
        Debug.Log("oui");
        if(countTire == 1 )
        {   
            EventParamScores paramScores = new EventParamScores();
            EventManager.TriggerEvent("StopChrono");
            highScores.Add(highScores.Count.ToString(),Chrono.CHRONO);
            highScores = highScores.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            paramScores.Value = highScores;
            EventManager.TriggerEvent("DisplayScores",paramScores);
            overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);

        }
    }

    private void RemoveTire(EventParam param)
    {
        countTire--;
    }
}
