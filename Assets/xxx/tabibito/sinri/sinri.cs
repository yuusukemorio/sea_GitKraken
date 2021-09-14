using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sinri : MonoBehaviour
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

        if (camera_hantei == "cinema_tabibito_sinri")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                a = true;
            }
        }

        if (a == true)
        {
            time += Time.deltaTime;
            if (time > 5.5)
            {
                time = 0;
                communication += 1;
            }
        }

        switch (communication)
        {
            case 1:
                score_text.text = "やぁ、お嬢さん";
                break;
            case 2:
                score_text.text = "我々は海と空の物語の一部に過ぎない";
                break;
            case 3:
                score_text.text = "なぁに、とても単純なことだ";
                break;
            case 4:
                score_text.text = "水平線で分断された海と空は、まだ愛し合っている";
                break;
            case 5:
                score_text.text = "その証拠に、お嬢さん、あなたがいる";
                break;
            case 6:
                score_text.text = "さぁ、そろそろ物語を進めないといけない";
                break;
            case 7:
                score_text.text = "君はどうしたい？";
                break;
            case 8:
                SceneManager.LoadScene("Sea_kuzira_henka");
                break;

        }
    }
}
