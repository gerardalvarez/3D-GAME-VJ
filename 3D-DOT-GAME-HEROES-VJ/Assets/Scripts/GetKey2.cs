using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey2 : MonoBehaviour
{
    public GameObject door;
    public GameObject key;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            if (door != null)
            {
                door.GetComponent<RotateDoor2>().setunLocked(true);
                key.SetActive(false);
            }
        }
    }
}
