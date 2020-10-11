/*
* Aim of this script:
Keep track of score based on materials given by workers.
 
 
* Current functionality:
None.
 
 
* Current issues:
Non-functional.


 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AIMining.Structures
{
    [AddComponentMenu("Mining/Structures/Goal")]
    public class Goal : MonoBehaviour
    {
        public static int brassCount;
        void Start()
        {
            brassCount = 0;
        }

        void Update()
        {

        }
    }
}