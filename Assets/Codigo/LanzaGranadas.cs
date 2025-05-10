using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaGranadas : MonoBehaviour
{
    public float throwForce = 40f;
    public float fireRate = 1000f;
    public GameObject grenadePrefab;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;

            ThrowGrenade();
        }
        
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
