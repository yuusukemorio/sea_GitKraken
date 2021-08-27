using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class serihu : MonoBehaviour
{
    int communication = 0;
    float time = 0 ;

    public camera_hantei_script CHS;
    string camera_hantei;

    bool a = false;

    public GameObject score_object = null; // Textオブジェクト

    void Start()
    {

    }


    void Update()
    {
        Text score_text = score_object.GetComponent<Text>();
        camera_hantei = CHS.camera_hantei;

        if (camera_hantei == "cinema_tabibito_hinkon")
        {
            if (Input.GetKey(KeyCode.Space)) {
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
                score_text.text = "...あぁ";
                break;
            case 2:
                score_text.text = "誰だ";
                break;
            case 3:
                score_text.text = "...";
                break;
            case 4:
                score_text.text = "嬢ちゃん、知ってっか";
                break;
            case 5:
                score_text.text = "海と空ってのは元々一つだったんだぞ";
                break;
            case 6:
                score_text.text = "でもよぉ、太陽が生まれて二つに分断されたんだ";
                break;
            case 7:
                score_text.text = "腹を立てて空は太陽を飲み込んだんだ";
                break;
            case 8:
                score_text.text = "それ知ってよ、月がギャンギャン泣きやがった";
                break;
            case 9:
                score_text.text = "うぇ...";
                break;
            case 10:
                score_text.text = "はぁ";
                break;
            case 11:
                score_text.text = "月の涙は黒いだろ？";
                break;
            case 12:
                score_text.text = "だからここはずっと暗れぇんだよ";
                break;
            case 13:
                score_text.text = "...";
                break;
            case 14:
                score_text.text = "まぁいずれ分かる";
                break;
            case 15:
                score_text.text = "じゃぁな";
                break;
            case 16:
                score_text.text = "";
                break;

        }
    }
}
