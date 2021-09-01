using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endro_ru : MonoBehaviour
{
    float a = 0;
    public GameObject score_object = null; // Textオブジェクト
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text score_text = score_object.GetComponent<Text>();


        a += Time.deltaTime;
        if (a > 3.2)
        {
            score_text.text = "to be next";
        }
        else if (a > 3.1)
        {
            score_text.text = "to be";
        }
        else if (a > 3)
        {
            score_text.text = "to";
        }


        if (a > 8)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
        }

    }


}
