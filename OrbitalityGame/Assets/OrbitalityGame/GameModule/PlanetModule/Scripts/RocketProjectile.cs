using Orbitality.UtilitiesModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.GameModule.PlanetModule
{
    public class RocketProjectile : MonoBehaviour
    {
        private float acceleration;
        private float weight;
        private float damage;
        private Collider creatorCollider;
        private event Action onDestroy;
        private event Action update;
        private float push = 0;
        private float stabilization = 2;




        public void Init(float acceleration, float weight, float damage, Collider creatorCollider)
        {
            this.damage = damage;
            this.acceleration = acceleration;
            this.weight = weight;
            this.creatorCollider = creatorCollider;
            update += Move;
        }


        void Update()
        {
            update?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other != creatorCollider)
            {
                if (other.GetComponentInParent<PlanetController>())
                {
                    IPlanetController planet = other.GetComponentInParent<PlanetController>();
                    planet.TakeDamage(damage);
                }
                Destroy(this.gameObject);
            }
        }


        private void DestroyRocket()
        {
            onDestroy?.Invoke();
        }

        private void Move()
        {
            float speed = acceleration;
            float gravity = weight;
            if (push <= stabilization)
            {
                push += Time.deltaTime;
                speed *= 2;
                gravity /= 3;
            }
            if (Vector3.Distance(transform.position, Vector3.zero) <= 2.5f)
            {
                gravity *= 2;
            }
            Vector3 targetDirection = Vector3.zero - transform.position;
            float singleStep = gravity * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            Debug.DrawRay(transform.position, newDirection, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);

            transform.Translate(Vector3.forward/150 * speed * Time.deltaTime * 100);
        }
    }
}

