using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gamekit2D
{
    public class FPPlayer : MonoBehaviour
    {
        CharacterController player;
        public float rotateSpeedX = 5f;
        public static bool PuedoMoverme = true;

        void Start()
        {
            player = GetComponent <CharacterController> ();
        }

        void Update()
        {
            print(PuedoMoverme);
            if (PuedoMoverme == true)
            {
                transform.Rotate (Vector3.up * rotateSpeedX * Time.deltaTime * Input.GetAxis("Mouse X"));
            }
            /* 
            if (Input.GetButtonDown("Cancel"))
            {
                SceneManager.LoadScene("Calar");
            }
            */
        }
    }  
}

