using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject Player;
    private Rigidbody objectRigidbody;
    private bool isDraggingObject;
    private bool isTouching = false;
    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            isTouching = true;
        }
        if(other.CompareTag("tresor")){
            isDraggingObject = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
            isTouching = false;
        }
    }

    void Start()
    {
        isDraggingObject = false;
        audioSource = objectToDrag.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isDraggingObject = true;
                audioSource.Play();
            }
        }
        if(isDraggingObject){
            objectRigidbody = objectToDrag.GetComponent<Rigidbody>();

            Vector3 objectPosition = objectToDrag.transform.position;
            
            objectPosition.z += 4;
            
            objectRigidbody.MovePosition(objectPosition);
        }
    }
}
