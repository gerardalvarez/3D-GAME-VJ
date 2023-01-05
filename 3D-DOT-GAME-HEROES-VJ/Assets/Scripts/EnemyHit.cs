using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public GameObject Sword;
    private int vides;
    private AudioSource audioSource;
    public float blink;
    public bool inmune;
    public float inmuneTime;
    public float blinkTime;
    public float blinkDuration = 2;
    public float blinkIntensity = 10;
    public GameObject door;
    public GameObject apple;

    MeshRenderer meshRenderer;

    SkinnedMeshRenderer SkinnedMeshRenderer;

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
                SkinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
                break;
            case "Enemy2":
                vides = 3;
                SkinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
                break;
            case "Enemy3":
                vides = 5;
                meshRenderer = GetComponentInChildren<MeshRenderer>();
                break;
            case "Enemy4":
                vides = 4;
                SkinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
                break;
            case "Boss":
                vides = 60;
                SkinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
                break;
            default:
                vides = 3;
                break;
        }
        blinkDuration = 0.3f;
        blinkIntensity = 20;
        inmuneTime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (inmuneTime > 0)
        {
            blinkTime -= Time.deltaTime;
            inmuneTime -= Time.deltaTime;
            float lerp = Mathf.Clamp01(blinkTime / blinkDuration);
            float intensity = lerp * blinkIntensity + 1.0f;
            if (this.gameObject.tag == "Enemy3") meshRenderer.material.color = Color.white * intensity;
            else SkinnedMeshRenderer.material.color = Color.white * intensity;


        }
        else
        {
            inmune = false;
            inmuneTime = 2;
            //hit = false;
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sword")){
            
            bool atack = Sword.GetComponent<SwordAttack>().getisAtacking();
            if (atack){
                int videsPlayer = Sword.GetComponent<SwordAttack>().getVidesPlayer();
                hit(videsPlayer);
                blinkTime = blinkDuration;
                inmune = true;

            }
        }
        if(other.CompareTag("Boomerang")){
            hit(5);
            blinkTime = blinkDuration;
            inmune = true;

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
            Instantiate(apple, transform.position, transform.rotation);
            // if (apple != null)
            // {
            // }
            
        }
        if (this.gameObject.tag == "Boss" && vides <= 0)
        {
            if (door != null)
            {
                Debug.Log("abro");
                door.GetComponent<FinalDoor>().setunLocked(true);
            }
        }
    }
}
