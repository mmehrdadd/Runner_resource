using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponHandler : MonoBehaviour
{
    [HideInInspector]
    public PlayerAnimation playerAnim;
    
    
    [SerializeField]
    public GameObject ak_47,
                      rifle;
    public ParticleSystem lightingtrail;
    private void Start()
    {
        playerAnim = GetComponent<PlayerAnimation>();
    }
    private void Update()
    {
        ActiveGun();
    }

    private void ActiveGun()
    {
        //Debug.Log("is working");
        if (playerAnim.isArmed)
        {
            if (playerAnim.isAk_47)
            {
                ak_47.gameObject.SetActive(true);
                lightingtrail.Play();
            }
                
            if (playerAnim.isRifle)
            {
                rifle.gameObject.SetActive(true);
                lightingtrail.Play();

                
                
            }
                
            
        }
    }
}
