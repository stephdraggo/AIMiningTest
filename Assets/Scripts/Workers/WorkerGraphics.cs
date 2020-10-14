using UnityEngine;

namespace AIMining.Workers
{
    [AddComponentMenu("Mining/Workers/Graphics")]
    public class WorkerGraphics : MonoBehaviour
    {
        [Tooltip("0 = empty, 1 = copper, 2 = zinc, 3 = brass")]
        public Material[] materials;

        [Range(0,3)]private int matIndex;
        private MeshRenderer meshRenderer;
        private WorkerActions actionS;
        void Start()
        {
            meshRenderer = gameObject.GetComponent<MeshRenderer>();
            actionS = gameObject.GetComponent<WorkerActions>();

            meshRenderer.material = materials[0];
        }
        void Update()
        {
            if(actionS.Carrying== MetalType.Empty)
            {
                matIndex = 0;
            }
            else if (actionS.Carrying == MetalType.Copper)
            {
                matIndex = 1;
            }
            else if (actionS.Carrying == MetalType.Zinc)
            {
                matIndex = 2;
            }
            else if (actionS.Carrying == MetalType.Brass)
            {
                matIndex = 3;
            }

            meshRenderer.material = materials[matIndex];
        }
    }
}