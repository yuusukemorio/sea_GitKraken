using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_hantei_script : MonoBehaviour
{
    public string camera_hantei = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        camera_hantei = other.gameObject.name;
    }
}
