using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_hasigo : MonoBehaviour
{
    public AudioClip sound;
    AudioSource audiosource;

    public camera_hantei_script CHS;
    public test_sia SIA;
    int sia;
    string camera_hantei;

    bool ikkaidake = false;

    int kaisuu = 0;

    float Atime = 0;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        camera_hantei = CHS.camera_hantei;
        sia = SIA.action;
        Debug.Log(sia);

        if (sia == 300 && kaisuu == 0)
        {
            audiosource.PlayOneShot(sound);
            ikkaidake = true;
            kaisuu = 1;
        }


        if (sia == 300)
        {
            if (Atime < 0.36)
            {
                Atime += Time.deltaTime / 60;
                audiosource.volume = Atime;
            }
        }
        else if (sia != 300)
        {
            kaisuu = 0;
            audiosource.Stop();
            Atime = 0;
            audiosource.volume = 0;
        }
    }
}
