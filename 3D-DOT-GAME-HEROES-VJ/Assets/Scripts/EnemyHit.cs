using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public GameObject Sword;
    public GameObject Boomerang;
    private int vides = 3;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        //TODO: ASSIGNAR VIDA SEGONS EL TIPO
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
        vides -= videsPlayer;
        if(vides <= 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
