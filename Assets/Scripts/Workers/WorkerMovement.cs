/*
* Aim of this script:
Determine target location/object based on demand hierarchy.
Move towards target.
 
 
* Current functionality:
None.



* Current issues:



 */
using AIMining.Structures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIMining.Workers
{
    [AddComponentMenu("Mining/Workers/Movement")]
    public class WorkerMovement : MonoBehaviour
    {
        public DemandTicket ticket;
        public Vector3 targetLocation;
        public float speed;

        public GameObject copperMine, zincMine, smelterObject, goal;

        private Smelter smelter;
        private Rigidbody rigidBody;
        void Start()
        {
            rigidBody = gameObject.GetComponent<Rigidbody>();
            smelter = smelterObject.GetComponent<Smelter>();
        }

        private void Update()
        {
            Move();
            if (targetLocation == Vector3.zero)
            {
                ChooseTarget();
            }

        }
        private void FixedUpdate()
        {
            ChooseTarget();
        }

        private void Move()
        {
            rigidBody.velocity = (targetLocation - transform.position).normalized * speed;
        }


        public void ChooseTarget()
        {
            //assign target according to demand ticket
            switch (ticket)
            {
                case DemandTicket.MineCopper:
                    targetLocation = copperMine.transform.position;
                    break;
                case DemandTicket.MineZinc:
                    targetLocation = zincMine.transform.position;
                    break;
                case DemandTicket.DeliverOre:
                    targetLocation = smelterObject.transform.position;
                    break;
                case DemandTicket.CollectBrass:
                    targetLocation = smelterObject.transform.position;
                    break;
                case DemandTicket.DeliverBrass:
                    targetLocation = goal.transform.position;
                    break;
                case DemandTicket.None:
                    //if demand ticket is available
                    if (smelter.demandTickets.Count > 0)
                    {
                        //take a demand ticket
                        ticket = smelter.demandTickets[0];
                        //and remove ticket from smelter
                        smelter.demandTickets.RemoveAt(0);
                    }
                    else //if demand ticket is not available
                    {
                        //then move aside
                        targetLocation = new Vector3(20,.5f,0);
                    }
                    break;

                default:
                    break;
            }
        }

    }
}
