using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oto : MonoBehaviour
{
    int communication = 0;
    float time = 0;

    public camera_hantei_script CHS;
    string camera_hantei;

    bool a = false;

    public test_sia tSIA;

    public GameObject score_object = null; // Textオブジェクト

    AudioSource audiosource;
    float Atime = 0.055f;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        camera_hantei = CHS.camera_hantei;

        if (camera_hantei == "cinema_tabibito_sinri")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                a = true;
            }
        }

        if(a == true)
        {
            Atime -= Time.deltaTime / 200;
            audiosource.volume = Atime;
        }
    }
}
