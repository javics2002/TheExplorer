using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gamekit2D
{
    public class SinPicos : MonoBehaviour
    {
        public Animator animator;
        public SpriteRenderer SpriteEllen;
        public SpriteRenderer SpriteExplorer;
        public Transform PositionEllen;
        public Transform PositionExplorer;
        bool derecha = true;
        public static bool texto = false;
        public AudioSource AudioSource;
        public AudioSource Salto;
        //public GameObject PosteUI;

        void Start()
        {
            if(PlayerCharacter.UsoPicos == true)
            {
                SpriteExplorer.enabled = false;
                SpriteEllen.enabled = true;
            }
            else
            {
                SpriteExplorer.enabled = true;
                SpriteEllen.enabled = false;
            }
        }

        void Update()
        {
            PositionExplorer.position = PositionEllen.position;
/*
            if(PosteUI.activeSelf == true)
            {
                SpriteEllen.enabled = false;
                SpriteExplorer.enabled = true;
                PlayerCharacter.PuedoMoverme = false;
                texto = true;
                AudioSource.enabled = false;
            }
            else
            {
                PlayerCharacter.PuedoMoverme = true;
            }
*/
            print(texto);

            if(PlayerCharacter.UsoPicos == true)
            {
                SpriteExplorer.enabled = false;
                SpriteEllen.enabled = true;
            }
            else
            {
                SpriteExplorer.enabled = true;
                SpriteEllen.enabled = false;
            }

            animator.SetFloat("VerticalSpeed", PlayerCharacter.m_MoveVector.y);
            animator.SetFloat("HorizontalSpeed", Mathf.Abs(PlayerCharacter.m_MoveVector.x));
            animator.SetBool("Grounded", PlayerCharacter.m_CharacterController2D.IsGrounded);
            animator.SetBool("Texto", texto);

            if(Input.GetKey(KeyCode.D) && texto == false)
            {
                SpriteExplorer.flipX = false;
            }
            else if (Input.GetKey(KeyCode.A) && texto == false)
            {
                SpriteExplorer.flipX = true;
            }

            if(Input.GetKey(KeyCode.Space) && PlayerCharacter.m_CharacterController2D.IsGrounded == true && texto == false)
            {
                Salto.Play();
            }
        }

        public void EntroACueva()
        {
            SpriteExplorer.color = Color.grey;
        }

        public void SalgoDeCueva()
        {
            SpriteExplorer.color = Color.white;
        }

        public void Texto()
        {
            SpriteEllen.enabled = false;
            SpriteExplorer.enabled = true;
            PlayerCharacter.PuedoMoverme = false;
            texto = true;
            AudioSource.enabled = false;
            PlayerCharacter.UsoPicos = false;
            //Debug.Log("TextoOK");
        }

        public void CierroTexto()
        {
            if(PlayerCharacter.UsoPicos == true)
            {
                SpriteEllen.enabled = true;
                SpriteExplorer.enabled = false;
            }
            PlayerCharacter.PuedoMoverme = true;
            texto = false;
            AudioSource.enabled = true;
        }
    }
}