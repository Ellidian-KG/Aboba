using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PistolFire : MonoBehaviour
{
    public AudioClip fireClip;
    public AudioSource audioSource;
    private Interactable interactable;
    public SteamVR_Action_Boolean fireAction;
    public Transform barel;
    public ParticleSystem muzzleFlash;
    public int damage = 10;
    public GameObject impactEffect;

    public Text textScores;
    public Camera mainCamera;
    private RaycastHit hit;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }
    private void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;
            if (fireAction[hand].stateDown)
            {
                Fire();
            }
        }
    }
    private void Fire()
    {
        muzzleFlash.Play();
        audioSource.PlayOneShot(fireClip);
        
        if(Physics.Raycast(barel.position, barel.forward, out hit, 300))
        {
            if (hit.transform.GetComponent<Enemy>())
            {
                hit.transform.GetComponent<Enemy>().TakeDamage(damage);
            textScores.text= Enemy.score.ToString();
            }
            
        }
        GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGo, 2f);
       
    }
}
