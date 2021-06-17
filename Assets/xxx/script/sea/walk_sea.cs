using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk_sea : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    [SerializeField] private float spd = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //this.transform.position += new Vector3(- spd, 0, 0);
            Vector3 force = new Vector3(-spd, 0.0f, 0.0f);
            rb.AddForce(force);
            animator.SetInteger("walk", 1);
        }
       　if (Input.GetKey(KeyCode.RightArrow))
        {
            //this.transform.position += new Vector3(spd, 0, 0);
            Vector3 force = new Vector3(spd, 0.0f, 0.0f);
            rb.AddForce(force);
            animator.SetInteger("walk", 1);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //this.transform.position += new Vector3(0, 0, spd);
            Vector3 force = new Vector3(0.0f, 0.0f, spd);
            rb.AddForce(force);
            animator.SetInteger("walk", 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //this.transform.position += new Vector3(0, 0, -spd);
            Vector3 force = new Vector3(0.0f, 0.0f, -spd);
            rb.AddForce(force);
            animator.SetInteger("walk", 1);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            //this.transform.position += new Vector3(0, 0, -spd);
            animator.SetInteger("walk", 2);
            Vector3 force = new Vector3(0.0f, spd, 0.0f);
            rb.AddForce(force);

        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 force = new Vector3(0.0f, -spd, 0.0f);
            rb.AddForce(force);
            animator.SetInteger("walk", 1);
        }

        if(Input.anyKey == false)
        {
            animator.SetInteger("walk", 0);
        }

    }
}
