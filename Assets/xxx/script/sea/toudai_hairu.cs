using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toudai_hairu : MonoBehaviour
{
    public camera_hantei_script CHS;
    string camera_hantei;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera_hantei = CHS.camera_hantei;

        if(camera_hantei == "toudai_deru")
        {
            transform.position = new Vector3(transform.position.x, 3.437769f, transform.position.z);
        }
        //if (camera_hantei == "toudai_hairu")
        //{
        //    transform.position = new Vector3(transform.position.x, 3.934518f, transform.position.z);
        //}
    }
}
