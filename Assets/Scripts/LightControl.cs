using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIMining.Misc
{
    [AddComponentMenu("Mining/Misc/Light Control")]
    public class LightControl : MonoBehaviour
    {
        public Light sunLight;

        public float speed;

        [Range(-180, 180)] private float lightY;
        [Range(0, 180)] private float lightX;
        void Start()
        {
            lightY = sunLight.transform.rotation.y;
        }

        void Update()
        {
            lightY += (Time.deltaTime * speed);
            lightX += (Time.deltaTime * speed);
            if (lightY >= 180)
            {
                lightY = -180;
            }
            if (lightX >= 180)
            {
                lightX = 0;
            }
            sunLight.transform.rotation = Quaternion.Euler(lightX, lightY, 0);
        }
    }
}