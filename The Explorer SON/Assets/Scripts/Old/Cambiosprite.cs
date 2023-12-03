using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gamekit2D
{
    public class Cambiosprite : MonoBehaviour
    {
        public Animator animator;
        public SpriteRenderer SpriteEllen;
        public SpriteRenderer SpriteExplorer;
        public Transform PositionEllen;
        public Transform PositionExplorer;
        bool Escalo = false;
        float Speed;

        void Start()
        {
            SpriteExplorer.enabled = false;
            Escalo = false;
            if(PlayerCharacter.UsoPicos == false)
            {
                SpriteEllen.enabled = false;
            }
        }

        void Update()
        {
            PositionExplorer.position = PositionEllen.position;

            animator.SetFloat("VerticalSpeed", Speed);

            if(PlayerCharacter.UsoPicos == true)
            {
                if(Escalo == false)
                {
                    SpriteEllen.enabled = true;
                }
                else
                {
                    SpriteEllen.enabled = false;
                }
            }
            else
            {
                SpriteEllen.enabled = false;
            }

            if (PlayerCharacter.Climbing.y >= 0.1f)
            {
                Speed = 1f;
            }
            else if (PlayerCharacter.Climbing.y <= -0.1f)
            {
                Speed = -1f;
            }
            else
            {
                Speed = 0f;
            }

            if(Escalo == false)
            {
                if(Input.GetKey(KeyCode.D))
                {
                    SpriteExplorer.flipX = false;
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    SpriteExplorer.flipX = true;
                }
            }
        }

        public void AnimacionEscalar()
        {
            if(PlayerCharacter.UsoPicos == true)
            {
                Escalo = true;
                SpriteEllen.enabled = false;
                SpriteExplorer.enabled = true;
            }
        }

        public void AnimacionNoEscalar()
        {
            if(PlayerCharacter.UsoPicos == true)
            {
                Escalo = false;
                SpriteEllen.enabled = true;
                SpriteExplorer.enabled = false;
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

        public void PlayClimb()
        {
            if(SpriteExplorer.enabled == true)
            {
                //Climb.Play(); Para rayito
            }
        }

        public void StopClimb()
        {
            //Climb.Stop(); rayito te quiero
        }
    }
}
