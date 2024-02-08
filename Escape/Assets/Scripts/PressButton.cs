using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    [SerializeField]
    private Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator.Play("Rotation");
        m_Animator.StartPlayback();
    }

    public void onStart()
    {
        m_Animator.StopPlayback();
    }

    public void onStop()
    {
        m_Animator.StartPlayback();
    }
}
