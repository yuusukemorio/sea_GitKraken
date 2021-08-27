using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toudai_hikari1 : MonoBehaviour
{
    float timeee = 0;

    public GameObject slight;
    float LIntensity;

    public camera_hantei_script CHS;
    string camera_hantei;

    bool a = false;

    void Start()
    {
        LIntensity = slight.GetComponent<Light>().intensity;
    }


    void Update()
    {
        camera_hantei = CHS.camera_hantei;
        Debug.Log(camera_hantei);
        Debug.Log(a);

        if (camera_hantei == "akusyon_hikari")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                a = true;
            }
        }

        if (a == true)
        {
            if (timeee < 46.7)
            {
                timeee += Time.deltaTime *14;
                LIntensity = timeee;
                slight.GetComponent<Light>().intensity = LIntensity;
            }
            else
            {
                SceneManager.LoadScene("end");
                Debug.Log("end");
            }
        }
    }

}