using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float bulletSpeed = 100;
    public GameObject bulletPrefab;
    public Transform nozzle;
    public ParticleSystem muzzleFlash;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    async void Shoot()
    {
        //create a bullet
        GameObject bullet = Instantiate(bulletPrefab, nozzle.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(nozzle.forward * bulletSpeed, ForceMode.Impulse);

        //play the animation
        if (muzzleFlash != null && !muzzleFlash.isPlaying)
        {
            muzzleFlash.Play();
        }
        StartCoroutine(StopMuzzleFlash() );
    }
    IEnumerator StopMuzzleFlash()
    {
         yield return new WaitForSeconds(0.2f);
         muzzleFlash.Stop();
    }
}
