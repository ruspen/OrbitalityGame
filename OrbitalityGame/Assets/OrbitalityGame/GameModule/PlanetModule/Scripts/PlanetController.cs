using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.GameModule.PlanetModule
{
    public class PlanetController : MonoBehaviour, IPlanetController
    {
        private event Action SimpleUpdate;

        private float maxDistanceToPoint = 0.1f;

        private Vector3[] wayPositions;
        private int startPositionAtWay = 0;
        private float moveSpeed;
        private int currentPointAtWay;
        

        public void Init()
        {
            
        }

        public void StartMove(Vector3[] way, int startPositionAtWay, float moveSpeed)
        {
            this.wayPositions = way;
            this.startPositionAtWay = startPositionAtWay;
            this.moveSpeed = moveSpeed;
            currentPointAtWay = AddPointAtWay(wayPositions, startPositionAtWay);
            transform.position = wayPositions[startPositionAtWay];
            Play();
        }

        public void Pause()
        {
            SimpleUpdate -= MovePlanet;
        }

        public void Play()
        {
            SimpleUpdate += MovePlanet;
        }

        private void Update()
        {
            SimpleUpdate?.Invoke();
        }


        private void MovePlanet()
        {
            if (Vector3.Distance(transform.position, wayPositions[currentPointAtWay]) < maxDistanceToPoint)
            {
                currentPointAtWay = currentPointAtWay = AddPointAtWay(wayPositions, currentPointAtWay);
            }
            transform.position = Vector3.MoveTowards(transform.position, wayPositions[currentPointAtWay], Time.deltaTime * moveSpeed);
        }

        private int AddPointAtWay(Vector3[] way, int currentPoint)
        {
            if (currentPoint + 1 == way.Length)
            {
                return 0;
            }
            else
            {
                return currentPoint + 1;
            }
        }

    }
}

