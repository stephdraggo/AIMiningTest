/*
* Aim of this script:
Keep track of score based on materials given by workers.
 */
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
    }
}