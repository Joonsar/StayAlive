using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFLash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        DisplayAmmo();

        if (Input.GetMouseButton(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;

    }

    private void PlayMuzzleFlash()
    {
        muzzleFLash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit this thing: " + hit.transform.name);
            // TODO: add some hit effect for visual players
            CreateHitImpact(hit);
            // Call a method on EnemyHealth that decreases the enemy's health
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}
