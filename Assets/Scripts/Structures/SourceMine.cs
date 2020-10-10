/*
* Aim of this script:
Hold values specific to this mine that must be accessed by workers.
Contain global enum for material types.
 
 
 
* Current functionality:
Contains type of material that can be harvested at this gameObject.
 
 
* Current issues:
Is it an issue for global enums to be present multiple times in one scene?


 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AIMining.Structures
{
    [AddComponentMenu("Mining/Structures/Source Mine")]
    public class SourceMine : MonoBehaviour
    {
        #region Variables
        [Header("Mining stats")]
        [Tooltip("The material that can be harvested from this source.")]
        public MetalType oreType;

        
        #endregion
        #region Start
        void Start()
        {

        }
        #endregion
        void Update()
        {

        }
    }
}

public enum MetalType
{
    Copper,
    Zinc,
    Brass,
    Empty,
}