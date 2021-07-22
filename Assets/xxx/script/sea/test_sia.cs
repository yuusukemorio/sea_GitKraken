using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_sia : MonoBehaviour
{
    //スクリプトを動かすかどうか(移動)
    string stop = "GO";

    public float run_speed;
    Animator animator;
    Rigidbody rb;
    CapsuleCollider CC;

    //アクション情報を取得するための変数
    public camera_hantei_script CHS;
    string camera_hantei;

    void Start()
    {
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
        CC = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        //アクションの情報の取得
        camera_hantei = CHS.camera_hantei;
        //入力の取得
        Vector3 target_dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //旅人と話をするときのスクリプト
        if (Input.GetKey(KeyCode.G) && camera_hantei == "cinema_tabibito_hinkon")
        {
            animator.SetInteger("walk", 9);
            CC.enabled = false;
            rb.useGravity = false;
            stop = "STOP";
        }

        //移動のスクリプト
        if (stop == "GO")
        {
            //Run
            if (target_dir.magnitude > 0.1)
            {
                //体の向きを変更
                transform.rotation = Quaternion.LookRotation(target_dir);
                //アニメーション
                animator.SetInteger("walk", 1);
                //前方へ移動
                transform.Translate(Vector3.forward * Time.deltaTime * run_speed);
            }
            else
            {
                animator.SetInteger("walk", 0);
            }
        }
    }
}
