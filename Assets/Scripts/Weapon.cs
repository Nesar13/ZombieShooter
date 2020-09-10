﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPcamera;
    //range for the weapon
    [SerializeField] float range = 100f;

    // this is the damage indicator by the weapon 
    [SerializeField] float damage = 20f;

    // this is for the particle system for the weapon wehn shooting
    [SerializeField] ParticleSystem muzzleFlash; 

    //instantiate a gameObject and destroy it 
    [SerializeField] GameObject hitEffect;

   

    // Update is called once per frame
    void Update()
    {
        // left click to shoot 
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(); 
        }

        
        
    }
    private void Shoot()
    {
        PlayMuzzleFlash(); 
        ProcessRaycast();

    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play(); 
    }

    private void ProcessRaycast()
    {
        // structure used to get information back from a raycast
        RaycastHit hit;

        if (Physics.Raycast(FPcamera.transform.position, FPcamera.transform.forward, out hit, range))
        {

            Debug.Log("I hit this thing: " + hit.transform.name);

            // we want to show the hit impact of the bullets
            CreateHitImpact(hit); 
            // TODO: add some hit effect for visual players
            // Get the component of the object that is hit by weapon --the health
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            // TODO: handle null with not hitting an object
            if (target == null) return;

            // damge the enemy that is hit
            target.TakeDamage(damage);

        }

        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        // hitEffect (the hit  Effect VFX) is the gameObject that was serialized, the LookRotation indicates 
        // how you will view the hit effect 
        GameObject impact=Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));

        // destroys the gameObject after 0.1s 
        Destroy(impact, 0.1f); 
    }
}
