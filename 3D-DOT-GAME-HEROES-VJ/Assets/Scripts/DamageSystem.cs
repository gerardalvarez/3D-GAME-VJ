using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    bool daño = false;
    Vector3 reverseDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (daño)
        {
            transform.Translate(new Vector3(reverseDirection.x,0,reverseDirection.z) * 200, Space.World);
            daño = false;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        
        PlayerInventory inventory = GetComponent<PlayerInventory>();
        if (other.tag == "Enemy1")
        {
            Debug.Log("daño");

            Debug.Log("daño");
            inventory.perderVida();

            reverseDirection = -other.transform.forward;
            daño= true;
        }
    }
}
