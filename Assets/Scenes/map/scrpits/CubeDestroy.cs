using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestroy : MonoBehaviour
{

    public GameObject cube;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }
    }
}
