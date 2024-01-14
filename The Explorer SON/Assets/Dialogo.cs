using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Gamekit2D
{
    public class Dialogo : MonoBehaviour
    {
        public DialogueCanvasController DialogueCanvasController;
        public float DelayTime = 0f;
        static bool Dialogo0 = true;
        static bool Dialogo1 = true;
        static bool Dialogo2 = false;
        static bool Dialogo3 = true;
        static bool Dialogo4 = true;
        static bool Dialogo5 = false;
        static bool Dialogo6 = true;
        static bool Dialogo7 = false;
        static bool Dialogo8 = true;
        static bool Dialogo9 = true;
        static bool Dialogo10 = false;
        static bool Dialogo11 = false;
        static bool Dialogo12 = false;
        static bool Dialogo13 = false;
        static bool Dialogo14 = false;
        static bool Dialogo15 = true;
        static bool Dialogo16 = false;
        static bool Dialogo17 = false;
        static bool PicosB = false;
        static bool Pregunta1 = true;
        static bool Pregunta2 = true;
        static bool Pregunta3 = true;
        static bool Pregunta4 = true;
        static bool Pregunta5 = true;
        static bool Pregunta6 = true;
        public CircleCollider2D Circulo0;
        public CircleCollider2D Circulo1;
        public CircleCollider2D Circulo2;
        public CircleCollider2D Circulo3;
        public BoxCollider2D Circulo4;
        public CircleCollider2D Circulo5;
        public BoxCollider2D Circulo6;
        public CircleCollider2D Circulo7;
        public CircleCollider2D Circulo8;
        public CircleCollider2D Circulo9;
        public CircleCollider2D Circulo10;
        public CircleCollider2D Circulo11;
        public CircleCollider2D Circulo12;
        public CircleCollider2D Circulo13;
        public CircleCollider2D Circulo14;
        public CircleCollider2D Circulo15;
        public BoxCollider2D Circulo16;
        public CircleCollider2D Circulo17;
        public CircleCollider2D P1;
        public CircleCollider2D P2;
        public CircleCollider2D P3;
        public CircleCollider2D P4;
        public CircleCollider2D P5;
        public CircleCollider2D P6;
        public CircleCollider2D Picos;
        public static int NumberD;
        public GameObject Telescopio;
        public GameObject TranstitionToStars;
        public static bool HeConstruidoelTelescopio = false;
        static bool PrimeraVez = true;
        public static bool VengoFoto1 = true;
        public static bool VengoFoto2 = true;
        static bool E = false;
        public GameObject ImageE;
        public GameObject Flecha;
        public SinPicos SinPicos;
        public AudioSource AudioHuevo;

        void Start()
        {
            if(PicosB == true)
            {
                Picos.enabled = true;
            }

            if(Dialogo0 == false)
            {
                Circulo0.enabled = false;
            }

            if(Dialogo1 == false)
            {
                Circulo1.enabled = false;
            }

            if(Dialogo2 == false)
            {
                Circulo2.enabled = false;
            }
            else
            {
                Circulo2.enabled = true;
            }

            if(Dialogo3 == false)
            {
                Circulo3.enabled = false;
            }

            if(Dialogo4 == false)
            {
                Circulo4.enabled = false;
            }

            if(Dialogo5 == false)
            {
                Circulo5.enabled = false;
            }
            else
            {
                Circulo5.enabled = true;
            }

            if(Dialogo6 == false)
            {
                Circulo6.enabled = false;
            }

            if(Dialogo7 == false)
            {
                Circulo7.enabled = false;
            }
            else
            {
                Circulo7.enabled = true;
            }

            if(Dialogo8 == false)
            {
                Circulo8.enabled = false;
            }

            if(Dialogo9 == false)
            {
                Circulo9.enabled = false;
            }

            if(Dialogo10 == false)
            {
                Circulo10.enabled = false;
            }
            else
            {
                Circulo10.enabled = false;
            }

            if(Dialogo11 == false)
            {
                Circulo11.enabled = false;
            }

            if(Dialogo12 == false)
            {
                Circulo12.enabled = false;
            }

            if(Dialogo13 == true)
            {
                Circulo13.enabled = true;
            }

            if(Dialogo14 == true)
            {
                Circulo14.enabled = true;
            }

            if(Dialogo15 == false)
            {
                Circulo15.enabled = false;
            }

            if(Dialogo16 == true)
            {
                Circulo16.enabled = true;
            }

            if(Dialogo17 == true)
            {
                Circulo17.enabled = true;
            }

            if(Pregunta1 == false)
            {
                P1.enabled = false;
            }

            if(Pregunta2 == false)
            {
                P2.enabled = false;
            }

            if(Pregunta3 == false)
            {
                P3.enabled = false;
            }

            if(Pregunta4 == false)
            {
                P4.enabled = false;
            }

            if(Pregunta5 == false)
            {
                P5.enabled = false;
            }

            if(Pregunta6 == false)
            {
                P6.enabled = false;
            }

            if(HeConstruidoelTelescopio == true)
            {
                Telescopio.SetActive(true);
                TranstitionToStars.SetActive(true);
            }

            if(PicosB == true)
            {
                Picos.enabled = true;
            }
            else
            {
                Picos.enabled = false;
            }
        }

        void Update()
        {
            if(E == true)
            {
                ImageE.SetActive(true);
                Flecha.SetActive(true);
            }
            else
            {
                ImageE.SetActive(false);
                Flecha.SetActive(false);
            }

            print(HeConstruidoelTelescopio);

            if(PlayerCharacter.TengoPalos == true && PlayerCharacter.TengoTubo == true && PlayerCharacter.TengoGafas == true && PrimeraVez == true && PlayerCharacter.PuedoMoverme == true)
            {
                Circulo13.enabled = true;
                Dialogo13 = true;
                Circulo16.enabled = true;
                PrimeraVez = false;
            }

            if(PlayerCharacter.TengoPicos == true)
            {
                Circulo3.enabled = false;
                Dialogo3 = false;
            }

            if(PlayerCharacter.PuedoMoverme == false)
            {
                if(Input.GetButtonDown("Interact"))
                {
                    if(NumberD == 100)
                    {

                    }
                    else
                    {
                        PlayerCharacter.PuedoMoverme = true;
                        DialogueCanvasController.DeactivateCanvasWithDelay(DelayTime);
                        DesactivarE();
                        if(NumberD == 0)
                        {
                            Circulo0.enabled = false;
                            Dialogo0 = false;
                        }
                        else if(NumberD == 1)
                        {
                            Circulo1.enabled = false;
                            Dialogo1 = false;
                        }
                        else if(NumberD == 2)
                        {
                            Circulo2.enabled = false;
                            Dialogo2 = false;
                        }
                        else if(NumberD == 3)
                        {
                            Circulo3.enabled = false;
                            Dialogo3 = false;
                        }
                        else if(NumberD == 4)
                        {
                            Circulo4.enabled = false;
                            Dialogo4 = false;
                        }
                        else if(NumberD == 5)
                        {
                            Circulo5.enabled = false;
                            Dialogo5 = false;
                        }
                        else if(NumberD == 6)
                        {
                            Circulo6.enabled = false;
                            Dialogo6 = false;
                        }
                        else if(NumberD == 7)
                        {
                            Circulo7.enabled = false;
                            Dialogo7 = false;
                        }
                        else if(NumberD == 8)
                        {
                            Circulo8.enabled = false;
                            Dialogo8 = false;
                        }
                        else if(NumberD == 9)
                        {
                            Circulo9.enabled = false;
                            Dialogo9 = false;
                        }
                        else if(NumberD == 10)
                        {
                            Circulo10.enabled = false;
                            Dialogo10 = false;
                        }
                        else if(NumberD == 11)
                        {
                            Circulo11.enabled = false;
                            Dialogo11 = false;
                        }
                        else if(NumberD == 12)
                        {
                            Circulo12.enabled = false;
                            Dialogo12 = false;
                        }
                        else if(NumberD == 13)
                        {
                            Circulo13.enabled = false;
                            Dialogo13 = false;
                            PlayerCharacter.TengoGafas = false;
                            PlayerCharacter.TengoPalos = false;
                            PlayerCharacter.TengoTubo = false;
                            Telescopio.SetActive(true);
                            TranstitionToStars.SetActive(true);
                            HeConstruidoelTelescopio = true;
                        }
                        else if(NumberD == 14)
                        {
                            Circulo14.enabled = false;
                            Dialogo14 = false;
                        }
                        else if(NumberD == 15)
                        {
                            Circulo15.enabled = false;
                            Dialogo15 = false;
                            SinPicos.CierroTexto();
                            AudioHuevo.Stop();
                        }
                        else if(NumberD == 16)
                        {
                            Circulo16.enabled = false;
                            Dialogo16 = false;
                        }
                        else if(NumberD == 17)
                        {
                            Circulo17.enabled = false;
                            Dialogo17 = false;
                        }
                    }
                }
            }
        }

        public void D0()
        {
            NumberD = 0;
            ActivarE();
        }

        public void D1()
        {
            NumberD = 1;
            ActivarE();
        }

        public void D2()
        {
            NumberD = 2;
            ActivarE();
        }
/*
        public void D3()
        {
            NumberD = 3;
        }
*/
        public void D4()
        {
            NumberD = 4;
            ActivarE();
        }

        public void D5()
        {
            NumberD = 5;
            ActivarE();
        }

        public void D6()
        {
            NumberD = 6;
            ActivarE();
        }

        public void D7()
        {
            NumberD = 7;
            ActivarE();
        }

        public void D8()
        {
            NumberD = 8;
            ActivarE();
        }

        public void D9()
        {
            NumberD = 9;
            ActivarE();
        }

        public void D10()
        {
            NumberD = 10;
            ActivarE();
        }

        public void D11()
        {
            NumberD = 11;
            ActivarE();
        }

        public void D12()
        {
            NumberD = 12;
            ActivarE();
        }

        public void D13()
        {
            NumberD = 13;
            ActivarE();
        }

        public void D14()
        {
            NumberD = 14;
            ActivarE();
        }

        public void D15()
        {
            NumberD = 15;
            ActivarE();
        }

        public void D16()
        {
            NumberD = 16;
            ActivarE();
        }

        public void D17()
        {
            NumberD = 17;
            ActivarE();
        }

        public void D100()
        {
            NumberD = 100;
        }

        public void Vengo1()
        {
            if(VengoFoto1 == true)
            {
                Dialogo14 = true;
                Circulo14.enabled = true;
                VengoFoto1 = false;
            }
        }

        public void Vengo2()
        {
            if(VengoFoto2 == true)
            {
                Dialogo17 = true;
                Circulo17.enabled = true;
                VengoFoto2 = false;
            }
        }

        public void AciertoPregunta()
        {
            Picos.enabled = true;
            Circulo5.enabled = true;
            PicosB = true;
            Pregunta1 = false;
        }

        public void CojoPicos()
        {
            PicosB = false;
        }

        public void AciertoPregunta2()
        {
            Pregunta2 = false;
        }

        public void AciertoPregunta3()
        {
            Pregunta3 = false;
        }

        public void AciertoPregunta4()
        {
            Pregunta4 = false;
        }

        public void AciertoPregunta5()
        {
            Pregunta5 = false;
        }

        public void AciertoPregunta6()
        {
            Pregunta6 = false;
        }

        public void ActivarE()
        {
            E = true;
        }

        public void DesactivarE()
        {
            E = false;
        }
    }
}