using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class camera_priority : MonoBehaviour
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
        Debug.Log(OBJ.name);

        if (OBJ.name == camera_hantei)
        {
            CVcamera.Priority = 100;
            Debug.Log(OBJ.name);
        }
    }
}
