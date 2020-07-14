using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float x;
    void Update()
    {

        //x += Time.deltaTime * 20;
        transform.rotation = Quaternion.Euler(0, 0, x);

    }
}
