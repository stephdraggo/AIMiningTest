/*
* Aim of this script:
Keep track of intake and output for this smelter.
Use intake to create output after a given interval.
Have a maximum capacity for each type of held material.
Generate demand tickets for workers.

 
* Current functionality:
Lists of materials separated by type and dynamically updated.
Uses intake to create output after a given interval.
 
 
* Current issues:
Does not have maximum capacity yet.


 */
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace AIMining.Structures
{
    [AddComponentMenu("Mining/Structures/Smelter")]
    public class Smelter : MonoBehaviour
    {
        #region Variables
        [Header("Smelter stats")]
        public List<MetalType> brass;
        public List<MetalType> copper, zinc;


        [SerializeField, Tooltip("")]
        private float productionTime;

        private bool busy;
        #endregion
        void Start()
        {
            busy = false;
        }

        void Update()
        {
            //if copper or zinc are not at capacity, generate demand ticket
            if (!busy && copper.Count > 0 && zinc.Count > 0)
            {
                StartCoroutine("Alchemise");
            }
        }

        #region Functions
        public void AddMaterial(MetalType mat)
        {
            if (mat == MetalType.Copper)
            {
                copper.Add(mat);
            }
            else if (mat == MetalType.Zinc)
            {
                zinc.Add(mat);
            }
        }
        public void RemoveMaterial()
        {
            brass.RemoveAt(0);
        }
        private IEnumerator Alchemise()
        {
            busy = true;
            copper.RemoveAt(0);
            zinc.RemoveAt(0);

            yield return new WaitForSeconds(productionTime);

            brass.Add(MetalType.Brass);
            busy = false;

            //generate demand ticket
        }
        #endregion

        private void OnGUI()
        {
            if(GUI.Button(new Rect(10,10,100,20),"+1 copper"))
            {
                copper.Add(MetalType.Copper);
            }
            if (GUI.Button(new Rect(10, 40, 100, 20), "+1 zinc"))
            {
                zinc.Add(MetalType.Zinc);
            }
        }
    }
}

public enum DemandTicket
{

}