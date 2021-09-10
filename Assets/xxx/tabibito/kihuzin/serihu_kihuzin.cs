using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class serihu_kihuzin : MonoBehaviour
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

        if (camera_hantei == "cinema_tabibito_kihuzin")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                a = true;

            }
        }

        if (a == true)
        {
            time += Time.deltaTime;
            if (communication == 0)
            {
                if (time > 6)
                {
                    time = 0;
                    communication += 1;
                }
            }
            else
            {
                if (time > 5)
                {
                    time = 0;
                    communication += 1;
                }
            }

        }

        switch (communication)
        {
            case 1:
                score_text.text = "初めまして";
                break;
            case 2:
                score_text.text = "私は      　　　。";
                break;
            case 3:
                score_text.text = "この世界ってロマンチックよね";
                break;
            case 4:
                score_text.text = "海と空は互いのことを想っている";
                break;
            case 5:
                score_text.text = "でも水平線のせいで二人は交わることが出来ない";
                break;
            case 6:
                score_text.text = "だけど愛し合っている";
                break;
            case 7:
                score_text.text = "いつか一緒になれるキッカケを待っている";
                break;
            case 8:
                score_text.text = "海と空が一緒になったら。私たちは消えるのかしら";
                break;
            case 9:
                score_text.text = "どうなんでしょうねぇ、楽しみですね";
                break;
            case 10:
                score_text.text = "おしゃべりに付き合ってくれてありがとうね";
                break;

            case 11:
                score_text.text = "";
                tSIA.action = 601;
                break;
            case 12:
                score_text.text = "";
                tSIA.action = 602;
                break;

        }
    }
}
