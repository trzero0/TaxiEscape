using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show : MonoBehaviour
{


    public GameObject pl;
    public bool isdead = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pl == null)
        {
            isdead = true;
        }

    }
}
