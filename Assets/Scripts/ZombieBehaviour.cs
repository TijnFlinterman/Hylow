using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Collider Box;
    [SerializeField] Collider capsul;
    [SerializeField] AudioClip[] Screams;
    [SerializeField] AudioClip[] Moans;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource ZombieMoan;
           int random;
    [SerializeField] string[] AnimationWalk;
       int randomScream;
    GameObject Player;
    float distance;
    bool canWalk;
    bool canAttack;
    bool canScream;
    bool isPlayerAudio = false;
    void Start()
    {
        RandomSounds();
        Player = GameObject.FindGameObjectWithTag("Player");
        //animator = GetComponent<Animator>();
        random = Random.Range(0, 100);
        randomScream = Random.Range(0, 100);
        if (random > 50)
        { 
        
          animator.SetBool(AnimationWalk[Random.Range(0, AnimationWalk.Length)], true);
            
            canWalk = true;
        }
        if (random > 80 || random < 20)
        {
            canAttack = true;
        
        }
        if (randomScream > 80 && canAttack == false)
        {
            canScream = true;
        
        }
    }

    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, Player.transform.position);
        if (distance < 6 && canAttack)
        {
            animator.SetBool("Attack", true);
            transform.LookAt(Player.transform.position);
        }
        if (distance < 18)
        {
            if (!ZombieMoan.isPlaying)
            {
                ZombieMoan.PlayDelayed(Random.Range(0, 3));
            }
        }
        if (distance < 15 && canScream)
        {
            animator.SetBool("Scream", true);
            if (!isPlayerAudio)
            { 
            audioSource.Play();
            isPlayerAudio = true;
            
            }
            transform.LookAt(Player.transform.position);
        }
    }
    private void FixedUpdate()
    {

        if (canWalk)
        {

            transform.Translate(new Vector3(0,0,0.5f) * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Chainsaw"))
        {
            animator.SetBool("dead", true);
            Box.enabled = false;
            capsul.enabled = false;
        }
            print("Hing Hing");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chainsaw"))
        {
            animator.SetBool("dead", true);
            Box.enabled = false;
            capsul.enabled = false;
        }
            print("Hing Hing");
    }
    void RandomSounds()
    {
        ZombieMoan.clip = Moans[Random.Range(0, Moans.Length - 1)];
        audioSource.clip = Screams[Random.Range(0, Screams.Length - 1)];


    }
}
