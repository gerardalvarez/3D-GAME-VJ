using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy1ia : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Target;
    public float speed = 20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(Target.gameObject.transform.position.x - this.transform.position.x) <120 && Math.Abs(Target.gameObject.transform.position.z - this.transform.position.z) < 120 )
        {
            transform.LookAt(Target.gameObject.transform.position);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
