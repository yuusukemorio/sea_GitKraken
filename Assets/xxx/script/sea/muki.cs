using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muki : MonoBehaviour
{
    private Vector3 latestPos;  //前回のPosition
    private float latestPos2;
    private float latestPos3;

    private void Update()
    {
        Vector3 diff = new Vector3(transform.position.x - latestPos2, 0, transform.position.z - latestPos3);   //前回からどこに進んだかをベクトルで取得
        latestPos = transform.position;  //前回のPositionの更新
        latestPos2 = transform.position.x;
        latestPos3 = transform.position.z;

        //ベクトルの大きさが0.01以上の時に向きを変える処理をする
        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
        }
    }
}