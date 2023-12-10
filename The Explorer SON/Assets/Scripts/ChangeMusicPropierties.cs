using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicPropierties : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject musicAmbienceGO;
    private PlayAmbience musicAmbienceSC;
    public  bool inCave = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!enabled)
            return;

        Debug.Log("Rayito frikispike");
        inCave = !inCave;
        musicAmbienceSC = musicAmbienceGO.GetComponent<PlayAmbience>();
        musicAmbienceSC.adjustEQINCave(inCave);
        
    }
}
