using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFPS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
