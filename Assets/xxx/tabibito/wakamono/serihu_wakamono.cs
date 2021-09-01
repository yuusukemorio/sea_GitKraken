using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class serihu_wakamono : MonoBehaviour
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

        if (camera_hantei == "cinema_tabibito_wakamono")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                a = true;

            }
        }

        if (a == true)
        {
            time += Time.deltaTime;
            if(communication == 0)
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
                score_text.text = "やぁ、多分初めましてだね";
                break;
            case 2:
                score_text.text = "僕は水平線へ向かってたんだが途中で迷ってしまってね";
                break;
            case 3:
                score_text.text = "そしたら上の方に光が見えたから近づいてみたんだ";
                break;
            case 4:
                score_text.text = "そしたら君がいたというわけだ";
                break;
            case 5:
                score_text.text = "助かったよ";
                break;
            case 6:
                score_text.text = "おかげで水平線へ行くことができる";
                break;
            case 7:
                score_text.text = "…";
                break;
            case 8:
                score_text.text = "では、またいつか会おう";
                break;
            case 9:
                score_text.text = "";
                tSIA.action = 601;
                break;
            case 10:
                score_text.text = "";
                tSIA.action = 602;
                break;

        }
    }
}
