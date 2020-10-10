﻿/*
* Aim of this script:
Keep track of held material.
Take or give material to relevent object on collision.
 
 
* Current functionality:
 
 
 
* Current issues:
Cannot test functionality until movement script is made.


 */
using AIMining.Structures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AIMining.Workers
{
    [AddComponentMenu("Mining/Workers/Actions")]
    public class WorkerActions : MonoBehaviour
    {
        #region Variables
        private MetalType carrying;
        #endregion
        void Start()
        {
            carrying = MetalType.Empty;
        }

        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent<SourceMine>(out SourceMine mine))
            {
                TakeMaterial(mine.oreType);
            }
            else if(collision.gameObject.TryGetComponent<Smelter>(out Smelter smelter))
            {
                switch (carrying)
                {
                    case MetalType.Copper:
                        smelter.AddMaterial(carrying);
                        break;
                    case MetalType.Zinc:
                        smelter.AddMaterial(carrying);
                        break;
                    case MetalType.Brass:
                        break;
                    case MetalType.Empty:
                        if (smelter.brass.Count > 0)
                        {
                            carrying = MetalType.Brass;
                            smelter.RemoveMaterial();
                        }
                        break;
                    default:
                        break;
                }
                carrying = MetalType.Empty;
            }
            else if(collision.gameObject.TryGetComponent<Goal>(out Goal goal))
            {

            }

        }

        #region Functions
        public void TakeMaterial(MetalType mat)
        {
            carrying = mat;
        }
        
        #endregion
    }
}