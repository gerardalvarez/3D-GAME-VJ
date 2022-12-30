using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    private Color colorStart = Color.red;
    private Color nextColor = Color.green;
    public bool unBlocked = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boomerang")){
            GetComponent<Renderer>().material.color = nextColor;
            if (Color.green == GetComponent<Renderer>().material.color){
                unBlocked = true;
            }
            else{
                unBlocked = false;
            }
        }
    }
}
