using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
   public class VerCamControl : MonoBehaviour
    {
        public float rotateSpeed = -100f;
        public float angleLimit = 50f;
        public float currAngle = -45f;
        float fieldOfView = 60f;
        public float scrollSpeed = -1500f;
        public float scrollSpeed2 = -500f;
        float maxField = 60f;
        float minField = 20f;
        public static bool PuedoMoverme = true;

        void Update()
        {
            print(PuedoMoverme);
            transform.localEulerAngles = (new Vector3(currAngle, 0, 0));

            if(PuedoMoverme == true)
            {
                currAngle += Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
            }
            
            if(25f < fieldOfView && fieldOfView < 55f)
            {
                fieldOfView += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * scrollSpeed;
            }
            else
            {
                fieldOfView += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * scrollSpeed2;
            }
            Camera.main.fieldOfView = fieldOfView;

            if(currAngle >= angleLimit)
            {
                currAngle = angleLimit;
            }

            if (currAngle <= angleLimit * -1)
            {
                currAngle = -angleLimit;
            }

            if(fieldOfView >= maxField)
            {
                fieldOfView = 60f;
            }

            if(fieldOfView <= minField)
            {
                fieldOfView = 20f;
            }

            //transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed * Input.GetAxis("Mouse Y"));
        }
    } 
}

