using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class DesactivarObjetos : MonoBehaviour
    {
        public SpriteRenderer PigmentoRojo;
        public SpriteRenderer PigmentoNegro;
        public SpriteRenderer Gafas;
        public SpriteRenderer Palos;
        public SpriteRenderer Tubo;
        public SpriteRenderer Huevo;
        void Start()
        {
            if(PlayerCharacter.TengoPigmentoRojo == true)
            {
                PigmentoRojo.enabled = false;
            }
            if(PlayerCharacter.TengoPigmentoNegro == true)
            {
                PigmentoNegro.enabled = false;
            }
            if(PlayerCharacter.TengoGafas == true)
            {
                Gafas.enabled = false;
            }
            if(PlayerCharacter.TengoPalos == true)
            {
                Palos.enabled = false;
            }
            if(PlayerCharacter.TengoTubo == true)
            {
                Tubo.enabled = false;
            }
            if(PlayerCharacter.TengoResina == true)
            {
                Huevo.enabled = false;
            }
        }
    }
}

