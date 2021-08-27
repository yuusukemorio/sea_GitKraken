using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_sia : MonoBehaviour
{
    //スクリプトを動かすかどうか(移動)
    string stop = "GO";

    public float run_speed;
    public float hasigo_speed;
    Animator animator;
    Rigidbody rb;
    CapsuleCollider CC;

    //アクション情報を取得するための変数
    public camera_hantei_script CHS;
    string akusyon_hantei;

    //アクション発火判定
    public int action;

    //地面の判定
    public akusyon_hantei_script ground;
    private bool isGround = false;
    //灯台の位置ずらし
    private string Ttoudai_itizurasi = "Down";
    float toudai_time = 0;

    void Start()
    {
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
        CC = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        //アクションの情報の取得
        akusyon_hantei = CHS.camera_hantei;
        //入力の取得
        Vector3 target_dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //着地判定の取得
        isGround = ground.IsGround();
        //灯台の位置ずらし
        Ttoudai_itizurasi = CHS.camera_hantei;



        //=========================================================================================
        //旅人とやり取りするスクリプトたち---------------------------------------------------------
        //=========================================================================================

        //旅人と話をしたか判定
        if (Input.GetKey(KeyCode.Space) && target_dir.magnitude < 0.1 && action > 99 == false)
        {
            if (akusyon_hantei == "a")
            {
                action = 1;
            }
            if (akusyon_hantei == "cinema_tabibito_hinkon")
            {
                action = 2;
            }
            if (akusyon_hantei == "akusyon_hasigo")
            {
                action = 3;
            }
            if (akusyon_hantei == "cinema_tabibito_SL")
            {
                action = 5;
            }
        }
        //灯台の上のためだけのスクリプト
        if (Input.GetKey(KeyCode.LeftShift) && target_dir.magnitude > 0.1 && action > 99 == false || Input.GetKey(KeyCode.Space) && target_dir.magnitude > 0.1 && action > 99 == false)
        {
            if (akusyon_hantei == "akusyon_hasigo_up")
            {
                action = 4;
            }
        }
        //各旅人用のアクション発火
        switch (action)
        {
            case 1:

                break;

            case 2:
                transform.position = new Vector3(26f, transform.position.y, 21.73f);
                transform.rotation = Quaternion.identity;

                animator.SetInteger("walk", 9);
                CC.enabled = false;
                rb.useGravity = false;
                stop = "STOP";
                action = 200;//spaceを押すたびに位置が変更されないように特定の数字を入れる
                break;

            case 3:
                transform.position = new Vector3(-0.7f, 4.2f, 22.8f);
                transform.eulerAngles = new Vector3(0f, -38.71f, 0f);

                CC.enabled = false;
                rb.useGravity = false;
                stop = "STOP";
                action = 300;//spaceを押すたびに位置が変更されないように特定の数字を入れる
                break;

            case 4:
                transform.position = new Vector3(0.45f, 52.9f, 21f);
                transform.eulerAngles = new Vector3(0f, -38.71f, 0f);

                CC.enabled = false;
                rb.useGravity = false;
                stop = "STOP";
                action = 400;//spaceを押すたびに位置が変更されないように特定の数字を入れる
                break;

            case 5:
                transform.position = new Vector3(26.21f, 3.43742f, 18.93f);
                transform.eulerAngles = new Vector3(0f, 21.676f, 0f);

                CC.enabled = false;
                rb.useGravity = false;
                stop = "STOP";
                animator.SetInteger("walk", 0);
                action = 500;//spaceを押すたびに位置が変更されないように特定の数字を入れる
                break;
        }
        //=========================================================================================
        //旅人とのやり取りをキャンセルするプログラム-----------------------------------------------
        //=========================================================================================
        if(action == 501)
        {
            CC.enabled = true;
            rb.useGravity = true;
            stop = "GO";
            action = 0;
        }



        //=========================================================================================
        //動きのスクリプトたち---------------------------------------------------------------------
        //=========================================================================================

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
        //はしごの処理書いてるとこ
        if (action == 300)
        {
            if (isGround == true)
            {

                action = 0;
                stop = "GO";
                rb.useGravity = true;
                CC.enabled = true;
            }
            else if(isGround == true)
            {
                action = 0;
                stop = "GO";
                rb.useGravity = true;
                CC.enabled = true;
            }
            //はしごを上るスクリプト
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetInteger("walk", 2);//アニメーション
                transform.Translate(0f, hasigo_speed, 0f * Time.deltaTime * 1);//前方へ移動
                animator.SetFloat("MovingSpeed", 2.0f);//アニメーションを再開
            }
            else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                animator.SetInteger("walk", 2);
                transform.Translate(0f, -hasigo_speed, 0f * Time.deltaTime * 1);//前方へ移動
                animator.SetFloat("MovingSpeed", -2.0f);//アニメーションを再開
            }
            else
            {
                animator.SetInteger("walk", 2);
                animator.SetFloat("MovingSpeed", 0.0f);//アニメーションの時間を一時停止
            }

            //位置ずらし
            if (Ttoudai_itizurasi == "Up")
            {
                //transform.position = new Vector3(0.45f, transform.position.y, 21f);
                transform.position = Vector3.Slerp(new Vector3(0.45f, transform.position.y, 21f), new Vector3(-0.7f, transform.position.y, 22.8f), Time.deltaTime / 8);
            }
            else if (Ttoudai_itizurasi == "Down")
            {
                //transform.position = new Vector3(-0.7f, transform.position.y, 22.8f);
                transform.position = Vector3.Slerp(new Vector3(-0.7f, transform.position.y, 22.8f), new Vector3(0.45f, transform.position.y, 21f), Time.deltaTime / 8);
            }
        }

        //灯台の上
        if (action == 400)
        {
            toudai_time += Time.deltaTime;
            if (toudai_time > 0.5)
            {
                if (isGround == true)
                {

                    //transform.position = new Vector3(0.45f, 54.1199f, 21f);
                    //transform.eulerAngles = new Vector3(0f, 0f, 0f);

                    action = 0;
                    stop = "GO";
                    rb.useGravity = true;
                    CC.enabled = true;
                    toudai_time = 0;
                }
            }
            //はしごを上るスクリプト
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetInteger("walk", 2);//アニメーション
                transform.Translate(0f, hasigo_speed, 0f * Time.deltaTime * 1);//前方へ移動
                animator.SetFloat("MovingSpeed", 2.0f);//アニメーションを再開
            }
            else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                animator.SetInteger("walk", 2);
                transform.Translate(0f, -hasigo_speed, 0f * Time.deltaTime * 1);//前方へ移動
                animator.SetFloat("MovingSpeed", -2.0f);//アニメーションを再開
            }
            else
            {
                animator.SetInteger("walk", 2);
                animator.SetFloat("MovingSpeed", 0.0f);//アニメーションの時間を一時停止
            }

            //位置ずらし
            if (Ttoudai_itizurasi == "Up")
            {
                //transform.position = new Vector3(0.45f, transform.position.y, 21f);
                transform.position = Vector3.Slerp(new Vector3(0.45f, transform.position.y, 21f), new Vector3(-0.7f, transform.position.y, 22.8f), Time.deltaTime / 8);
            }
            else if (Ttoudai_itizurasi == "Down")
            {
                //transform.position = new Vector3(-0.7f, transform.position.y, 22.8f);
                transform.position = Vector3.Slerp(new Vector3(-0.7f, transform.position.y, 22.8f), new Vector3(0.45f, transform.position.y, 21f), Time.deltaTime / 8);
            }
        }

    }
}
