using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class serihu_usagi : MonoBehaviour
{
    int communication = 0;
    float time = 0;

    public camera_hantei_script CHS;
    string camera_hantei;

    bool a = false;

    public test_sia tSIA;

    public GameObject score_object = null; // Textオブジェクト

    void Start()
    {

    }


    void Update()
    {
        Text score_text = score_object.GetComponent<Text>();
        camera_hantei = CHS.camera_hantei;

        if (camera_hantei == "cinema_tabibito_usagi")
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
                score_text.text = "水平線ってね、";
                break;
            case 2:
                score_text.text = "無限の空間なんだよ";
                break;
            case 3:
                score_text.text = "僕は太陽を探してるんだ。白い空が好きだったから。";
                break;
            case 4:
                score_text.text = "たぶん太陽は水平線に行ったんだ";
                break;
            case 5:
                score_text.text = "だから僕も水平線を目指す";
                break;
            case 6:
                score_text.text = "ずっと";
                break;
            case 7:
                score_text.text = "ずっと...";
                break;
            case 8:
                score_text.text = "";
                tSIA.action = 701;
                break;
            case 9:
                score_text.text = "";
                tSIA.action = 702;
                break;
        }
    }
}