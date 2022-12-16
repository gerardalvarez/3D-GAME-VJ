using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    bool da�o = false;
    Vector3 reverseDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (da�o)
        {
            transform.Translate(new Vector3(reverseDirection.x,0,reverseDirection.z) * 200, Space.World);
            da�o = false;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        
        PlayerInventory inventory = GetComponent<PlayerInventory>();
        if (other.tag == "Enemy1")
        {
            Debug.Log("da�o");

            Debug.Log("da�o");
            inventory.perderVida();

            reverseDirection = -other.transform.forward;
            da�o= true;
        }
    }
}
