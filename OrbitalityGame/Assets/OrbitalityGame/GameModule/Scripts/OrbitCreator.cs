using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Orbitality.UtilitiesModule;
using System;

namespace Orbitality.GameModule
{
    public class OrbitCreator
    {
        public List<EllipseData> OrbitsData { get; private set; } = new List<EllipseData>();

        private float orbitMagnificationFactor = 1.5f;
        private EllipseData orbitDefault = new EllipseData
        {
            Segments = 36,
            XAxis = 5f,
            YAxis = 3f
        };


        public EllipseData GetFreeOrbit()
        {
            EllipseData orbit;
            orbit = orbitDefault;
            if(OrbitsData.Count != 0)
            {
                orbit.XAxis = orbitDefault.XAxis * (float)Math.Pow(orbitMagnificationFactor, OrbitsData.Count);
                orbit.YAxis = orbitDefault.YAxis * (float)Math.Pow(orbitMagnificationFactor, OrbitsData.Count);
            }
            OrbitsData.Add(orbit);
            return orbit;
        }
    }
}

