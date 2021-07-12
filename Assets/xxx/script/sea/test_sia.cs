using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_sia : MonoBehaviour
{
    public float run_speed;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 target_dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Run
        if (target_dir.magnitude > 0.1)
        {
            //体の向きを変更
            transform.rotation = Quaternion.LookRotation(target_dir);
            //Quaternion rotation = Quaternion.LookRotation(target_dir);
            //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * smooth);

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
