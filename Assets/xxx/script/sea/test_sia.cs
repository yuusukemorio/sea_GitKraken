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


    //SLのアクションを二回起こさないための変数
    bool SLanime = false;
    bool Wakamonoanima = false;
    //SLの向き
    private Vector3 latestPos;

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
        if (Input.GetKey(KeyCode.Space) && target_dir.magnitude < 0.1 && action < 99)
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
            if (akusyon_hantei == "cinema_tabibito_SL" && SLanime == false)
            {
                action = 5;
            }
            if (akusyon_hantei == "cinema_tabibito_wakamono" && Wakamonoanima == false)
            {
                action = 6;
            }
            if (akusyon_hantei == "cinema_tabibito_usagi" && Wakamonoanima == false)
            {
                action = 7;
            }
            if (akusyon_hantei == "cinema_tabibito_kihuzin" && Wakamonoanima == false)
            {
                action = 8;
            }

        }
        //灯台の上のためだけのスクリプト
        if ((Input.GetKey(KeyCode.LeftShift) && target_dir.magnitude > 0.1 && action < 99) || (Input.GetKey(KeyCode.Space) && target_dir.magnitude > 0.1 && action < 99))
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
                Debug.Log("1番");
                break;

            case 2:
                transform.position = new Vector3(26f, transform.position.y, 21.73f);
                transform.rotation = Quaternion.identity;

                animator.SetInteger("walk", 9);
                CC.enabled = false;
                rb.useGravity = false;
                stop = "STOP";
                action = 200;//spaceを押すたびに位置が変更されないように特定の数字を入れる
                Debug.Log("2番");
                break;

            case 3:
                transform.position = new Vector3(-0.7f, 4.2f, 22.8f);
                transform.eulerAngles = new Vector3(0f, -38.71f, 0f);

                CC.enabled = false;
                rb.useGravity = false;
                stop = "STOP";
                action = 300;//spaceを押すたびに位置が変更されないように特定の数字を入れる
                Debug.Log("3番");
                break;

            case 4:
                transform.position = new Vector3(0.45f, 52.9f, 21f);
                transform.eulerAngles = new Vector3(0f, -38.71f, 0f);

                CC.enabled = false;
                rb.useGravity = false;
                stop = "STOP";
                action = 400;//spaceを押すたびに位置が変更されないように特定の数字を入れる
                Debug.Log("4番");
                break;

            case 5:
                //transform.position = new Vector3(26.21f, 3.43742f, 18.93f);
                //transform.eulerAngles = new Vector3(0f, 21.676f, 0f);

                CC.enabled = false;
                rb.useGravity = false;
                SLanime = true;
                animator.applyRootMotion = false;
                transform.position = new Vector3(transform.position.x, 3.437f, transform.position.z);

                stop = "STOP";
                animator.SetInteger("walk", 1);

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(26.2f, 3.437f, 18.9f), Time.deltaTime * 2);
                if (transform.position.x < 26.3 && transform.position.x > 26.1)
                {
                    action = 500;//spaceを押すたびに位置が変更されないように特定の数字を入れる
                }
                Vector3 diff = transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
                latestPos = transform.position;  //前回のPositionの更新
                //ベクトルの大きさが0.01以上の時に向きを変える処理をする
                if (diff.magnitude > 0.01f)
                {
                    transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
                    Debug.Log("5番");
                }

                break;
            case 6:
                transform.position = new Vector3(26f, transform.position.y, 21.73f);
                transform.rotation = Quaternion.identity;
                Wakamonoanima = true;
                //animator.applyRootMotion = false;
                animator.SetInteger("walk", 9);
                rb.useGravity = false;
                CC.enabled = false;

                stop = "STOP";
                action = 600;//spaceを押すたびに位置が変更されないように特定の数字を入れる
                Debug.Log("6番");
                break;

            case 7:
                transform.position = new Vector3(26f, transform.position.y, 21.73f);
                transform.rotation = Quaternion.identity;
                Wakamonoanima = true;
                //animator.applyRootMotion = false;
                animator.SetInteger("walk", 9);
                rb.useGravity = false;
                CC.enabled = false;

                stop = "STOP";
                action = 700;//spaceを押すたびに位置が変更されないように特定の数字を入れる
                Debug.Log("7番");
                break;
            case 8:
                transform.position = new Vector3(26f, transform.position.y, 21.73f);
                transform.rotation = Quaternion.identity;
                Wakamonoanima = true;
                //animator.applyRootMotion = false;
                animator.SetInteger("walk", 9);
                rb.useGravity = false;
                CC.enabled = false;

                stop = "STOP";
                action = 800;//spaceを押すたびに位置が変更されないように特定の数字を入れる
                Debug.Log("8番");
                break;
        }
        //=========================================================================================
        //旅人とのやり取りをキャンセルするプログラムor方向の確定
        //=========================================================================================
        if (action == 501)//SL
        {
            CC.enabled = true;
            rb.useGravity = true;
            stop = "GO";
            action = 0;
        }
        if (action == 500)//SL
        {
            animator.applyRootMotion = true;
            animator.SetInteger("walk", 0);
            transform.eulerAngles = new Vector3(0f, 21.676f, 0f);
        }

        if (action == 600 || action == 700)//若者
        {
            transform.position = new Vector3(26f, 3.44f, 21.73f);
        }
        if (action == 601 || action == 701)//若者
        {
            transform.position = new Vector3(26f, 3.44f, 21.73f);
            animator.SetInteger("walk", 8);
        }
        if (action == 602 || action == 702)
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
                Debug.Log("Up動いてるよ");
            }
            else if (Ttoudai_itizurasi == "Down")
            {
                //transform.position = new Vector3(-0.7f, transform.position.y, 22.8f);
                transform.position = Vector3.Slerp(new Vector3(-0.7f, transform.position.y, 22.8f), new Vector3(0.45f, transform.position.y, 21f), Time.deltaTime / 8);
                Debug.Log("Down動いてるよ");
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
                Debug.Log("Up動いてるよ2");
            }
            else if (Ttoudai_itizurasi == "Down")
            {
                //transform.position = new Vector3(-0.7f, transform.position.y, 22.8f);
                transform.position = Vector3.Slerp(new Vector3(-0.7f, transform.position.y, 22.8f), new Vector3(0.45f, transform.position.y, 21f), Time.deltaTime / 8);
                Debug.Log("Down動いてるよ2");
            }
        }

    }
}
