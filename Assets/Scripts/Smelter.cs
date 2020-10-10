using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

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