using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    public float damage = 50f;
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public AudioSource boom;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    void Start () {
        countdown = delay;
    }

    void Update () {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode () 
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        boom.Play(0);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if( rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

            Target target =  nearbyObject.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }

}
