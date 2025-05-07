using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODLight : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Flashlight/FlashlightClik");
        }
    }
}
