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

    void Start()
    {

    }


    void Update()
    {
        Debug.Log(tSIA.action);

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
                score_text.text = "遠くから光が見えたのでやってきました";
                break;
            case 3:
                score_text.text = "お乗りになられますか？";
                break;
            case 4:
                score_text.text = "";
                break;
            case 5:
                score_text.text = "...";
                break;
            case 6:
                score_text.text = "そうですか、残念です";
                break;
            case 7:
                score_text.text = "では、我々はこれで";
                break;
            case 8:
                score_text.text = "";
                tSIA.action = 501;
                break;

        }
    }
}
