using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public GameObject Sword;
    private int vides;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        //TODO: ASSIGNAR VIDA SEGONS EL TIPO
        string tag = this.gameObject.tag;
        
        switch (tag)
        {
            case "Enemy1":
                vides = 2;
                break;
            case "Enemy2":
                vides = 3;
                break;
            case "Enemy3":
                vides = 5;
                break;
            case "Enemy4":
                vides = 4;
                break;
            case "Boss":
                vides = 60;
                break;
            default:
                vides = 3;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sword")){
            
            bool atack = Sword.GetComponent<SwordAttack>().getisAtacking();
            if (atack){
                int videsPlayer = Sword.GetComponent<SwordAttack>().getVidesPlayer();
                hit(videsPlayer);
            }
        }
        if(other.CompareTag("Boomerang")){
            hit(5);
        }
    }

    private void hit(int videsPlayer)
    {
        audioSource.Play();
        string tag = this.gameObject.tag;
        Debug.Log("HIT "+ tag + " vides Player = " + videsPlayer + " Vides enemy= " + vides);
        vides -= videsPlayer;
        if(vides <= 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
