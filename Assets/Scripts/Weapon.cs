using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitBulletEffect;
    [SerializeField] float hitBulletDuration = 0.1f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        PlayMuzzleFash();
        ProcessRaycast();
    }

    void PlayMuzzleFash()
    {
        muzzleFlash.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);

        if (hasHit)
        {
            CreateHitEffect(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null) { return; }

            target.TakeDamage(damage);
        }
    }

    void CreateHitEffect(RaycastHit hit)
    {
        GameObject instance =  Instantiate(hitBulletEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(instance, hitBulletDuration);
    }
}
