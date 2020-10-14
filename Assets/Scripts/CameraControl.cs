using AIMining.Structures;
using UnityEngine;
using UnityEngine.UI;

namespace AIMining.Misc
{
    [AddComponentMenu("Mining/Misc/Camera Control")]
    public class CameraControl : MonoBehaviour
    {
        public Camera[] cameras;
        public Text scoreText;
        void Start()
        {
            //disable all but the first camera
            for (int i = 1; i < cameras.Length; i++)
            {
                cameras[i].enabled = false;
            }
        }
        void Update()
        {
            scoreText.text = Goal.brassCount.ToString() + "\nBrass Shipped.";
        }
        public void SwitchView(int index)
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].enabled = false;
            }
            cameras[index].enabled = true;
        }
        public void Quit()
        {
            Application.Quit();
        }
    }
}