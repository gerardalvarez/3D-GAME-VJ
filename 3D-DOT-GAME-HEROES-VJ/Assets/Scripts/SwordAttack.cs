using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    //
    public float rotationAngle = 90.0f; // Angle de rotacio de l'espassa
    public float unrotationAngle = 0.0f; // Angle de rotacio invers
    public bool isAtacking = false; 
    public float AttackTime = 0.5f; 
    public float MaxXscale = 150.0f;
    public float MaxZscale = 20.0f;  

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAtacking)
        {
            Quaternion rotation = Quaternion.AngleAxis(rotationAngle,Vector3.right); 
            transform.rotation = transform.rotation * rotation;
            Vector3 scale = transform.localScale; 
            scale.y = 50; 
            scale.z = 11;
            scale.x = 44; 
            transform.localScale = scale; 

            // Assignar la nova escala a l'objecte
            isAtacking = true; 
            Invoke("UnAttack",AttackTime);
        }        
    }

    void UnAttack()
    {   
        Debug.Log("Cridant unAttack");
        Quaternion rotation = Quaternion.AngleAxis(-rotationAngle,Vector3.right); 
        transform.rotation = transform.rotation * rotation;
        Vector3 scale = transform.localScale; 
        scale.y = 11; 
        scale.x = 11; 
        scale.z = 11;
        transform.localScale = scale; 
        isAtacking = false; 
    }
}
