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
        private event Action onDestroy;
        private event Action update;

        //private Vector3[] wayPositions;
        //private int startPositionAtWay = 0;

        //private int currentPointAtWay;
        //private int previousPointAtWay;
        //private Ellipse ellipseHelper;

        public void Init(float acceleration, float weight, EllipseData planetEllipseData)
        {
            this.acceleration = acceleration;
            this.weight = weight;
            update += Move;
        }


        void Start()
        {

        }

        void Update()
        {
            update?.Invoke();
        }


        private void DestroyRocket()
        {
            onDestroy?.Invoke();
        }

        private void Move()
        {
            transform.Translate(transform.forward);
        }
    }
}

