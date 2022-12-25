using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyia3 : MonoBehaviour
{

    public GameObject Target;
    public float speed = 20;
    public bool attacked=false;
    public Rigidbody projectile;
    // Start is called before the first frame update
    public float bolaspreed = 100;
    private float Resetattack=3 ;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Math.Abs(Target.gameObject.transform.position.x - this.transform.position.x) >= 50 && Math.Abs(Target.gameObject.transform.position.z - this.transform.position.z) >= 50)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

        }else { AttackPlayer(); }
        transform.LookAt(Target.gameObject.transform.position);
        

    }

    private void AttackPlayer()
    {
       
        if (!attacked)
        {
            var bola = Instantiate(projectile, transform.position,transform.rotation);
            // rb.AddForce(transform.forward*32f,ForceMode.Impulse);
            //  rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            bola.velocity = transform.forward * bolaspreed;
            
        }
        
        attacked = true;
        Resetattack-=Time.deltaTime;
        if (Resetattack<=0)
        {
            attacked= false;
            Resetattack=3;
        }
    }

    
}
