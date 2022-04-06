using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chainsaw : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Animator CanvasAni;
    public int fuel;
    public Text fuelCounter;
    public string[] blood;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] chainsawSwings;

    void Start()
    {
        fuelCounter.text = fuel.ToString();
    }

    void Update()
    {
        fuelCounter.text = fuel.ToString();
        if (Input.GetKeyDown(KeyCode.Mouse0) && fuel > 0)
        {
            animator.SetTrigger("Attack");
            audioSource.PlayOneShot(chainsawSwings[Random.Range(0, chainsawSwings.Length - 1)]);
            fuel --;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            CanvasAni.SetTrigger(blood[Random.Range(0, blood.Length)]);
        }
    }
}
