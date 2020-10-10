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