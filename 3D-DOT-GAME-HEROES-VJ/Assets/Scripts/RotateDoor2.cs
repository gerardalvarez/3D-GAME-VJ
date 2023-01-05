using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor2 : MonoBehaviour
{
    public GameObject door;
    public GameObject Player;
    private int count = 0;
    private bool canRotate = false;
    private AudioSource audioSource;
    private bool unlocked = false;
    public GameObject aviso2;

    void Start()
    {
        audioSource = door.GetComponent<AudioSource>();
        aviso2.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F) && unlocked){
            canRotate = true;
        }
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.K))
        {   
            canRotate = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el trigger es la puerta, muestra el mensaje
        if (other.tag == "Player" && !unlocked)
        {
            aviso2.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el trigger es la puerta, muestra el mensaje
        if (other.tag == "Player")
        {
            aviso2.SetActive(false);
        }
    }


    void Update()
    {
        if (canRotate){
            if (count == 0){
                audioSource.Play();
            }
            if(count > -45){
                count -= 5;
                Quaternion targetRotation = Quaternion.Euler(0, count, 0);

                Vector3 doorPosition = door.transform.position;
                doorPosition.z -= 2;

                door.transform.SetPositionAndRotation(doorPosition, targetRotation);
            }
        }
    }

    public bool getunLocked(){
        return unlocked;
    }

    public void setunLocked(bool value){
        unlocked = value;
    }
}
