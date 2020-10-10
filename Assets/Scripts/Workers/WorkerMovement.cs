/*
* Aim of this script:
Determine target location/object based on demand hierarchy.
Move towards target.
 
 
* Current functionality:
None.



* Current issues:



 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIMining.Workers
{
    [AddComponentMenu("Mining/Workers/Movement")]
    public class WorkerMovement : MonoBehaviour
    {
        public Work task;
        public Vector3 targetLocation;
        void Start()
        {
            task = Work.MoveAside;
        }

        private void Update()
        {
            //if task is null

                //if demand ticket is null

                    //if demand ticket is not available

                        //then MoveAside();

                    //else if demand ticket is available

                        //then take demand ticket

                //else if demand ticket is not null
                    
                    //then task is next step of demand ticket

            //else continue task
        }

        private Vector3 MoveAside()
        {
            targetLocation = Vector3.zero;
            return targetLocation;
        }
    }
}
public enum Work
{
    TakeCopper,
    TakeZinc,
    GiveSmelter,
    TakeSmelter,
    GiveBrass,
    MoveAside,
}