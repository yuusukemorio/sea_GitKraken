using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_kaiwa : MonoBehaviour
{
    public AudioClip sound;
    AudioSource audiosource;

    public GameObject kokoni_tabibitono_namae;

    public camera_hantei_script CHS;
    string camera_hantei;

    bool ikkaidake = false;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        camera_hantei = CHS.camera_hantei;

        if(camera_hantei == kokoni_tabibitono_namae.name && Input.GetKey(KeyCode.Space) && ikkaidake == false)
        {
            audiosource.PlayOneShot(sound);
            ikkaidake = true;
        }

    }
}
