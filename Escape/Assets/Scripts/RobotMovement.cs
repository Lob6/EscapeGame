using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainTools;

public class RobotMovement : MonoBehaviour
{
    [SerializeField]
    GameObject bras;
    private static float SPEED = 5;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("RobotRotate", OnRobotRotate);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("RobotRotate", OnRobotRotate);
    }

    private void OnRobotRotate(EventParam param)
    {
        EventParamRobot parameters = param as EventParamRobot;

        transform.Rotate(Vector3.up, parameters.Value.x * SPEED);
        bras.transform.Rotate(Vector3.right, parameters.Value.y * SPEED);
    }

    public void startRobot()
    {
        Debug.Log("Robot has been started");
    }

    public void stopRobot()
    {
        Debug.Log("Robot has been stopped");
    }
}
