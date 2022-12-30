using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    private Color colorStart;
    private Color nextColor;
    private Color finalColor;
    public bool unBlocked = false;
    private int count = 0;

    private void Start()
    {
        colorStart = GetComponent<Renderer>().material.color;
        if (colorStart == Color.red){
            nextColor = Color.green;
            finalColor = Color.blue;
        }
        else if (colorStart == Color.green){
            nextColor = Color.red;
            finalColor = Color.blue;
            unBlocked = true;
        }
        else{
            nextColor = Color.red;
            finalColor = Color.green;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            switch(count) 
            {
            case 0:
                GetComponent<Renderer>().material.color = nextColor;
                break;
            case 1:
                GetComponent<Renderer>().material.color = finalColor;
                break;
            default:
                GetComponent<Renderer>().material.color = colorStart;
                count = -1;
                break;
            }
            if (Color.green == GetComponent<Renderer>().material.color){
                unBlocked = true;
            }
            else{
                unBlocked = false;
            }
            count ++;
        }
    }
}
