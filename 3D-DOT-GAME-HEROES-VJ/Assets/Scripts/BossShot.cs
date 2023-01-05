using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
{

    public GameObject Target;
    public float speed = 30;
    public bool attacked = false;
    public Rigidbody projectile1;
    // Start is called before the first frame update
    public float bolaspreed = 500;
    private float Resetattack = 2;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(Target.gameObject.transform.position.x - this.transform.position.x) < 200 && Math.Abs(Target.gameObject.transform.position.z - this.transform.position.z) < 200)
        {
            AttackPlayer();

        }



    }

    private void AttackPlayer()
    {


        if (!attacked)
        {
            Debug.Log("DISPARO");
            Vector3 posicio = new Vector3(transform.position.x, 15f, transform.position.z);
            Quaternion rotacio = transform.rotation;
            var bola = Instantiate(projectile1, posicio, rotacio);
            bola.velocity = transform.forward * bolaspreed;





        }

        attacked = true;
        Resetattack -= Time.deltaTime;
        if (Resetattack <= 0)
        {
            attacked = false;
            Resetattack = 2;
        }
    }


}