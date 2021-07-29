﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class akusyon_hantei_script : MonoBehaviour
{
    private string groundTag = "Ground";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    public string toudai_itizurasi = "Down";


    //地面
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
            
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
        }
    }
}
