using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float rotationAngle = 90.0f; 
    public float unrotationAngle = 0.0f;
    public bool isAtacking = false; 
    public float AttackTime = 0.4f; 
    public float MaxXscale = 150.0f;
    public float MaxZscale = 20.0f;  
    private int videsPlayer = 5; //TODO: canviar en funcio de les vides

    LifeSystem scriptReferencia;
    void Start()
    {
        scriptReferencia= GetComponentInParent<LifeSystem>();
    }

    void Update()
    {
        videsPlayer = LifeSystem.life + 1;
        if (Input.GetKeyDown(KeyCode.Space) && !isAtacking)
        {
            Quaternion rotation = Quaternion.AngleAxis(rotationAngle,Vector3.right); 
            transform.rotation = transform.rotation * rotation;
            Vector3 scale = transform.localScale; 
            
            scale.y = 15 + 7 * videsPlayer;
            scale.z = 11;
            scale.x = 44 + 3 * videsPlayer; 
            transform.localScale = scale; 

            isAtacking = true; 
            Invoke("UnAttack",AttackTime);
        }        
    }

    void UnAttack()
    {   
        Quaternion rotation = Quaternion.AngleAxis(-rotationAngle,Vector3.right); 
        transform.rotation = transform.rotation * rotation;
        Vector3 scale = transform.localScale; 
        scale.y = 15; 
        scale.x = 15; 
        scale.z = 15;
        transform.localScale = scale; 
        isAtacking = false; 
    }

    public bool getisAtacking()
    {
        return isAtacking;
    }

    public int getVidesPlayer()
    {
        return videsPlayer;
    }
}
