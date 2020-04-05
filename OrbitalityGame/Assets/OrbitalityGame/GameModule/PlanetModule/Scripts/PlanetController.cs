using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Orbitality.UtilitiesModule;

namespace Orbitality.GameModule.PlanetModule
{
    public class PlanetController : MonoBehaviour, IPlanetController
    {

        public event Action<float> OnHealthChanged;
        public event Action OnDied;

        [SerializeField]
        private float planetSpeed = 0.1f;

        private event Action SimpleUpdate;

        private float currentHealth;
        private float maxDistanceToPoint = 0.001f;
        private Vector3[] wayPositions;
        private int startPositionAtWay = 0;
        private RocketData rocketData = new RocketData();
        private int currentPointAtWay;
        private int previousPointAtWay;
        private Ellipse ellipseHelper;
        private RocketType rocketType;
        private RocketCharacteristics rocketCharacteristics;
        private List<RocketProjectile> rockets = new List<RocketProjectile>();

        public void Init(RocketType rocketType)
        {
            currentHealth = GameData.PLANET_MAX_HEALTH;
            this.rocketType = rocketType;
            rocketCharacteristics = rocketData.GetCharacteristics(rocketType);
            ellipseHelper = new Ellipse();
        }

        public void StartMove(EllipseData ellipseData)
        {
            this.wayPositions = ellipseHelper.GetEllipsePositions(ellipseData);
            this.startPositionAtWay = UnityEngine.Random.Range(0, wayPositions.Length);
            previousPointAtWay = startPositionAtWay;
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

        public void TakeDamage(float points)
        {
            if (currentHealth - points <= 0)
            {
                currentHealth = 0;
                OnDied?.Invoke();
            }
            else
            {
                currentHealth -= points;
            }
            OnHealthChanged?.Invoke(currentHealth);
            if (currentHealth == 0)
            {
                Destroy(this.gameObject);
            }
        }

        public float GetHeath()
        {
            return currentHealth;
        }

        public void Attack()
        {
            GameObject projectile = Instantiate(Resources.Load<GameObject>(GameData.ROCKET_PREFAB_PATH));
            projectile.transform.position = transform.position;
            projectile.transform.LookAt(wayPositions[currentPointAtWay]);
            RocketProjectile rocketProjectile = projectile.GetComponent<RocketProjectile>();

            rocketProjectile.Init(rocketCharacteristics.Acceleration, rocketCharacteristics.Weight, rocketCharacteristics.Damage, gameObject.GetComponentInChildren<Collider>()); ;
            //rockets.Add(rocketProjectile);
        }

        public RocketCharacteristics GetRocketCharacteristics()
        {
            return rocketCharacteristics;
        }


        private void Update()
        {
            SimpleUpdate?.Invoke();
        }


        private void MovePlanet()
        {
            transform.LookAt(wayPositions[currentPointAtWay]);
            if (Vector3.Distance(transform.position, wayPositions[currentPointAtWay]) < maxDistanceToPoint)
            {
                previousPointAtWay = currentPointAtWay;
                currentPointAtWay = currentPointAtWay = AddPointAtWay(wayPositions, currentPointAtWay);
            }
            float coefSpeedByPoints = Vector3.Distance(wayPositions[previousPointAtWay], wayPositions[currentPointAtWay]);
            transform.position = Vector3.MoveTowards(transform.position, wayPositions[currentPointAtWay], Time.deltaTime * planetSpeed  * coefSpeedByPoints);
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

