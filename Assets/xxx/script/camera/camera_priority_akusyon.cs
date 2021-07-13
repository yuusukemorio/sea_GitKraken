using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class camera_priority_akusyon : MonoBehaviour
{
    public camera_hantei_script CHS;
    string camera_hantei;

    public GameObject OBJ;

    CinemachineVirtualCamera CVcamera;

    // Start is called before the first frame update
    void Start()
    {
        CVcamera = this.gameObject.GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        camera_hantei = CHS.camera_hantei;

        if (OBJ.name == camera_hantei)
        {
            CVcamera.Priority = 200;
        }
        else
        {
            CVcamera.Priority = 1;
        }
    }
}
