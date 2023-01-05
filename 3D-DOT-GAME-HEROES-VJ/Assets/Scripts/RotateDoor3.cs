using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor3 : MonoBehaviour
{
    public GameObject door;
    public GameObject Player;
    private int count = 0;
    private bool canRotate = false;
    private AudioSource audioSource;
    private bool unlocked = false;
    public GameObject aviso3;

    void Start()
    {
        audioSource = door.GetComponent<AudioSource>();
        aviso3.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F) && unlocked){
            canRotate = true;
        }
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.B))
        {   
            canRotate = true;
            unlocked= true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el trigger es la puerta, muestra el mensaje
        if (other.tag == "Player" && !unlocked)
        {
            aviso3.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el trigger es la puerta, muestra el mensaje
        if (other.tag == "Player")
        {
            aviso3.SetActive(false);
        }
    }


    void Update()
    {
        if (canRotate){
            if (count == 0){
                audioSource.Play();
            }
            if(count < 90){
                count += 10;
                Quaternion targetRotation = Quaternion.Euler(0, count, 0);

                Vector3 doorPosition = door.transform.position;
                doorPosition.x -= 2;

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
