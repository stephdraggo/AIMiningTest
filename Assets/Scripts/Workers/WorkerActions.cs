/*
* Aim of this script:
Keep track of held material.
Take or give material to relevent object on collision.
 
 
* Current functionality:
Keeps track of held material.
Takes and gives material to relevent object on collision.
 
 
* Current issues:
Needs comments.


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
        [SerializeField, Tooltip("Current material being carried.")]
        private MetalType carrying;

        private WorkerMovement moveS;



        public MetalType Carrying
        {
            get => carrying;
        }
        #endregion
        void Start()
        {
            moveS = gameObject.GetComponent<WorkerMovement>();
            carrying = MetalType.Empty;
        }

        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out SourceMine mine))
            {
                MineCollide(mine);
            }
            else if (collision.gameObject.TryGetComponent(out Smelter smelter))
            {
                SmelterCollide(smelter);
            }
            else if (collision.gameObject.TryGetComponent(out Goal goal))
            {
                GoalCollide();
            }

            //recalculate target location here
            moveS.ChooseTarget();
        }
        private void OnCollisionStay(Collision collision)
        {
             if (collision.gameObject.TryGetComponent(out Smelter smelter))
            {
                SmelterCollide(smelter);
            }
        }
        #region Functions
        /// <summary>
        /// Takes ore of the type associated with this mine and gives it to the worker.
        /// </summary>
        /// <param name="mine">source mine being collided with</param>
        private void MineCollide(SourceMine mine)
        {
            if (carrying == MetalType.Empty)
            {
                carrying = mine.oreType;
                moveS.ticket = DemandTicket.DeliverOre;
            }
        }
        /// <summary>
        /// Switch statement based on what the worker is carrying: delivers copper and zinc, takes brass, or does nothing.
        /// </summary>
        /// <param name="smelter">smelter being collided with</param>
        private void SmelterCollide(Smelter smelter)
        {
            switch (carrying)
            {
                case MetalType.Copper:
                    smelter.AddMaterial(carrying);
                    carrying = MetalType.Empty;
                    moveS.ticket = DemandTicket.None;
                    break;

                case MetalType.Zinc:
                    smelter.AddMaterial(carrying);
                    carrying = MetalType.Empty;
                    moveS.ticket = DemandTicket.None;
                    break;

                case MetalType.Brass:
                    moveS.ticket = DemandTicket.DeliverBrass;
                    break;

                case MetalType.Empty:
                    if (moveS.ticket == DemandTicket.CollectBrass)
                    {
                        carrying = MetalType.Brass;
                        smelter.RemoveMaterial();
                        moveS.ticket = DemandTicket.DeliverBrass;
                    }
                    break;

                default:
                    break;
            }
        }
        /// <summary>
        /// If the worker is carrying brass, adds to goal count and removes the brass.
        /// </summary>
        private void GoalCollide()
        {
            if (carrying == MetalType.Brass)
            {
                Goal.brassCount++;
                carrying = MetalType.Empty;
                moveS.ticket = DemandTicket.None;
            }
        }
        #endregion
    }
}