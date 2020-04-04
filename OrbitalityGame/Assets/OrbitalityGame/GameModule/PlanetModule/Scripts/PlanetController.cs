using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Orbitality.UtilitiesModule;

namespace Orbitality.GameModule.PlanetModule
{
    public class PlanetController : MonoBehaviour, IPlanetController
    {
        [SerializeField]
        private float planetSpeed = 1f;

        private event Action SimpleUpdate;

        private float maxDistanceToPoint = 0.01f;

        private Vector3[] wayPositions;
        private int startPositionAtWay = 0;

        private int currentPointAtWay;
        private Ellipse ellipseHelper;
        

        public void Init()
        {
            ellipseHelper = new Ellipse();
        }

        public void StartMove(EllipseData ellipseData)
        {
            this.wayPositions = ellipseHelper.GetEllipsePositions(ellipseData);
            this.startPositionAtWay = UnityEngine.Random.Range(0, wayPositions.Length);
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
            transform.position = Vector3.MoveTowards(transform.position, wayPositions[currentPointAtWay], Time.deltaTime * planetSpeed);
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

