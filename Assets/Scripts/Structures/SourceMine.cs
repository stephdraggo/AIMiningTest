/*
* Aim of this script:
Hold values specific to this mine that must be accessed by workers.
Contain global enum for material types.
*/
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
    }
}

public enum MetalType
{
    Copper,
    Zinc,
    Brass,
    Empty,
}