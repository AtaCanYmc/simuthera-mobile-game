﻿using UnityEngine;

namespace Obstacles_And_Backgrounds
{
    public class ParallaxEffect : MonoBehaviour
    {
        private float length, startpos;
        public GameObject cam;
        public float parallaxEffect;
    
        void Start()
        {
            startpos = transform.position.x;
            length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        void FixedUpdate()
        {
            float temp = (cam.transform.position.x) * (1 - parallaxEffect);
            float dist = (cam.transform.position.x * parallaxEffect);
        
            transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

            if (temp > startpos + length)    
                startpos += length;
        }
    }
}
