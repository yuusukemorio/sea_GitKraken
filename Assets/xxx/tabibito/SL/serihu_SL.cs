using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class serihu_SL : MonoBehaviour
{
    int communication = 0;
    float time = 0;

    public camera_hantei_script CHS;
    string camera_hantei;

    bool a = false;

    public GameObject score_object = null; // Textオブジェクト

    public test_sia tSIA;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {

        Text score_text = score_object.GetComponent<Text>();
        camera_hantei = CHS.camera_hantei;

        if (camera_hantei == "cinema_tabibito_SL")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                a = true;
            }
        }

        if (a == true)
        {
            time += Time.deltaTime;
            if (time > 4.5)
            {
                time = 0;
                communication += 1;
            }
        }

        switch (communication)
        {
            case 1:
                score_text.text = "初めまして、水平線急行列車です";
                break;
            case 2:
                score_text.text = "我々は水平線を目指して走っています";
                break;
            case 3:
                score_text.text = "お乗りになられますか？";
                break;
            case 4:
                score_text.text = "...";
                break;
            case 5:
                score_text.text = "そうですか、残念です";
                break;
            case 6:
                score_text.text = "...そうだ、世間話ですが";
                break;
            case 7:
                score_text.text = "昔、空は白かったらしいですね";
                break;
            case 8:
                score_text.text = "でも太陽が海に沈んで、それを知った月が";
                break;
            case 9:
                score_text.text = "黒い涙を流した。";
                break;
            case 10:
                score_text.text = "...";
                break;
            case 11:
                score_text.text = "少し話が長くなりましたね、では我々はこの辺で";
                break;
            case 12:
                score_text.text = "";
                tSIA.action = 501;
                animator.SetInteger("SLanima", 1);
                break;

        }
    }
}
