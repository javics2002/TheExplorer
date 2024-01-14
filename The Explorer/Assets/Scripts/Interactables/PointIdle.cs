using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointIdle : MonoBehaviour
{
    private StudioEventEmitter emitterInner;
    private StudioEventEmitter emitterOuter;

    void Start()
    {
        emitterInner = GameManager.Instance.audioManager.InitializeEventEmitter(GameManager.Instance.fmodEvents.GetEvent("360Inner"), gameObject);
        emitterOuter = GameManager.Instance.audioManager.InitializeEventEmitter(GameManager.Instance.fmodEvents.GetEvent("360Outer"), gameObject);

        emitterInner.Play();
        emitterOuter.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
