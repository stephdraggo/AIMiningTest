/*
* Aim of this script:
Keep track of intake and output for this smelter.
Use intake to create output after a given interval.
Have a maximum capacity for each type of held material.
Generate demand tickets for workers.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIMining.Structures
{
    [AddComponentMenu("Mining/Structures/Smelter")]
    public class Smelter : MonoBehaviour
    {
        #region Variables
        [Header("Smelter stats")]

        [Tooltip("Available tasks for workers to collect from this structure.")]
        public List<DemandTicket> demandTickets;

        [Tooltip("Current materials being held here.")]
        public List<MetalType> brass;
        [SerializeField, Tooltip("Current materials being held here.")]
        private List<MetalType> copper, zinc;

        [SerializeField, Tooltip("Number of seconds it takes to complete one operation.")]
        private float productionTime;

        #endregion
        void Start()
        {
            demandTickets.Add(DemandTicket.MineCopper);
            demandTickets.Add(DemandTicket.MineZinc);
            StartCoroutine("CheckStock"); //starts the stock check loop
            StartCoroutine("Smelt"); //starts the smelting loop
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
        /// <summary>
        /// Waits until CanSmelt is true, then uses one of each ingredient to produce one product after a given interval.
        /// </summary>
        private IEnumerator Smelt()
        {
            while (gameObject)
            {
                yield return new WaitUntil(CanSmelt);

                copper.RemoveAt(0);
                zinc.RemoveAt(0);

                yield return new WaitForSeconds(productionTime);

                brass.Add(MetalType.Brass);
                demandTickets.Add(DemandTicket.CollectBrass);
            }

        }
        /// <summary>
        /// Checks if there is stock and generates demand tickets if there is not enough.
        /// </summary>
        private IEnumerator CheckStock()
        {
            while (gameObject)
            {
                if (demandTickets.Count <= 20)
                {
                    if (copper.Count < 5)
                    {
                        demandTickets.Add(DemandTicket.MineCopper);
                    }
                    if (zinc.Count < 5)
                    {
                        demandTickets.Add(DemandTicket.MineZinc);
                    }
                }

                yield return new WaitForSeconds(1);
            }
        }
        /// <summary>
        /// Returns true if there is enough stock to smelt, otherwise false.
        /// </summary>
        /// <returns>bool</returns>
        private bool CanSmelt()
        {
            if (copper.Count > 0 && zinc.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
#if UNITY_EDITOR
        private void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 100, 20), "+1 copper"))
            {
                copper.Add(MetalType.Copper);
            }
            if (GUI.Button(new Rect(10, 40, 100, 20), "+1 zinc"))
            {
                zinc.Add(MetalType.Zinc);
            }

            GUI.Box(new Rect(10, 70, 100, 20), (Goal.brassCount + " brass shipped"));
        }
#endif
    }
}

public enum DemandTicket
{
    MineCopper,
    MineZinc,
    DeliverOre,
    CollectBrass,
    DeliverBrass,
    None,
}