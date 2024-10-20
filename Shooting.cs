using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float bulletSpeed = 100;
    public GameObject bulletPrefab;
    public Transform nozzle;
    public ParticleSystem smokeEffect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, nozzle.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(nozzle.forward * bulletSpeed, ForceMode.Impulse);
        Instantiate(smokeEffect, nozzle.position, Quaternion.identity);
    }
}
