using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.GameModule.SunModule
{
    public class SunController : MonoBehaviour
    {
        public float scrollSpeed = 0.1f;


        private Renderer rend;

        void Start()
        {
            rend = GetComponent<Renderer>();
        }

        void Update()
        {
            float offset = Time.time * scrollSpeed;
            rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        }
    }
}

