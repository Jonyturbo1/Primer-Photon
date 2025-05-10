using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CaminadoZombie : MonoBehaviour
{
    NavMeshAgent myNavMeshAgent;

    public float damage = 10f;
    public float damageSpeed = 10f;
    private float golpe = 0f;

    public AudioSource growl;
    public AudioSource attack;

    Animator m_Animator;

    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        m_Animator = gameObject.GetComponent<Animator>();
        golpe = damageSpeed;
    }

    void Update()
    {
        myNavMeshAgent.SetDestination(FPSControl.ubicacion);
        float dist = Vector3.Distance(FPSControl.ubicacion, transform.position);
        m_Animator.SetFloat("Dist", dist);

        
        if (dist <= 2f)
        {
            attack.Play(0);
            golpe -= Time.time;
        }
        else
        {
            growl.Play(0);
            golpe = damageSpeed;
        }

        if (golpe <= 0)
        {
            FPSControl.health -= damage;
            golpe = damageSpeed;
        }
    }
}
