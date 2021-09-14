using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anten : MonoBehaviour
{
    string[] ScenesName = { "Sea_Wakamono", "Sea_Game", "Sea_usagi", "sea_SL", "Sea_kihuzin", "Sea_sinri"};
    public static int SceneCount = 0;
    float ScenesTime = 0;

    void Start()
    {
    }


    void Update()
    {
        ScenesTime += Time.deltaTime;
        if (ScenesTime > 2)
        {
            SceneCount = SceneCount + 1;
            ScenesTime = 0;
            SceneManager.LoadScene(ScenesName[SceneCount]);
        }
    }
}
