using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        PlayerInventory inventory = GetComponent<PlayerInventory>();
        if (other.tag == "Player")
        {
            Debug.Log("daño");

            Debug.Log("daño");
            inventory.perderVida();


        }
    }
}
