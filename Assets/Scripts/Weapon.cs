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
    [SerializeField] float shootDelay = 1f;
    [SerializeField] AmmoType ammoType;
    bool canShoot = true;

    Ammo ammoSlot;

    void Awake()
    {
        ammoSlot = GetComponentInParent<Ammo>();
    }

    void OnEnable() 
    {
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }

        yield return new WaitForSeconds(shootDelay);

        canShoot = true;
    }

    public void StopCoolDown()
    {
        StopAllCoroutines();
        canShoot = true;
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
        GameObject instance = Instantiate(hitBulletEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(instance, hitBulletDuration);
    }
}
