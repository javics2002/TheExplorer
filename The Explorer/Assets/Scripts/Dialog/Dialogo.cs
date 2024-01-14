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
        public static bool Dialogo0 = true;
        public static bool Dialogo1 = true;
        public static bool Dialogo2 = false;
        public static bool Dialogo3 = true;
        public static bool Dialogo4 = true;
        public static bool Dialogo5 = false;
        public static bool Dialogo6 = true;
        public static bool Dialogo7 = false;
        public static bool Dialogo8 = true;
        public static bool Dialogo9 = true;
        public static bool Dialogo10 = false;
        public static bool Dialogo11 = false;
        public static bool Dialogo12 = false;
        public static bool Dialogo13 = false;
        public static bool Dialogo14 = false;
        public static bool Dialogo15 = true;
        public static bool Dialogo16 = false;
        public static bool Dialogo17 = false;
        public static bool PicosB = false;
        public static bool Pregunta1 = true;
        public static bool Pregunta2 = true;
        public static bool Pregunta3 = true;
        public static bool Pregunta4 = true;
        public static bool Pregunta5 = true;
        public static bool Pregunta6 = true;
        public CircleCollider2D Circulo0;
        public CircleCollider2D Circulo1;
        public CircleCollider2D Circulo2;
        public Collider2D Circulo3;
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
        public static bool PrimeraVez = true;
        public static bool VengoFoto1 = true;
        public static bool VengoFoto2 = true;
        static bool E = false;
        public GameObject ImageE;
        public GameObject Flecha;
        public SinPicos SinPicos;

        void Start()
        {
			Picos.enabled = PicosB;

			Circulo0.enabled = Dialogo0;
			Circulo1.enabled = Dialogo1;
			Circulo2.enabled = Dialogo2;
			Circulo3.enabled = Dialogo3;
			Circulo4.enabled = Dialogo4;
			Circulo5.enabled = Dialogo5;
			Circulo6.enabled = Dialogo6;
			Circulo7.enabled = Dialogo7;
			Circulo8.enabled = Dialogo8;
			Circulo9.enabled = Dialogo9;
			Circulo10.enabled = Dialogo10;
			Circulo11.enabled = Dialogo11;
			Circulo12.enabled = Dialogo12;
			Circulo13.enabled = Dialogo13;
			Circulo14.enabled = Dialogo14;
			Circulo15.enabled = Dialogo15;
			Circulo16.enabled = Dialogo16;
			Circulo17.enabled = Dialogo17;

			P1.enabled = Pregunta1;
			P2.enabled = Pregunta2;
			P3.enabled = Pregunta3;
			P4.enabled = Pregunta4;
			P5.enabled = Pregunta5;
			P6.enabled = Pregunta6;


			if (HeConstruidoelTelescopio == true)
            {
                Telescopio.SetActive(true);
                TranstitionToStars.SetActive(true);
            }

            Picos.enabled = PicosB;
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
						GameManager.Instance.fmodEvents.StopDialogue();
						if (NumberD == 0)
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
            GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
        }

        public void D1()
        {
            NumberD = 1;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D2()
        {
            NumberD = 2;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D3() {
            NumberD = 3;
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D4()
        {
            NumberD = 4;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D5()
        {
            NumberD = 5;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D6()
        {
            NumberD = 6;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D7()
        {
            NumberD = 7;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D8()
        {
            NumberD = 8;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D9()
        {
            NumberD = 9;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D10()
        {
            NumberD = 10;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D11()
        {
            NumberD = 11;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D12()
        {
            NumberD = 12;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D13()
        {
            NumberD = 13;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D14()
        {
            NumberD = 14;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D15()
        {
            NumberD = 15;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D16()
        {
            NumberD = 16;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
		}

        public void D17()
        {
            NumberD = 17;
            ActivarE();
			GameManager.Instance.fmodEvents.PlayDialogue(NumberD.ToString());
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

            GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("CorrectAnswer"), transform.position);
		}

        public void CojoPicos()
        {
            PicosB = false;
        }

        public void AciertoPregunta2()
        {
            Pregunta2 = false;

			GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("CorrectAnswer"), transform.position);
		}

        public void AciertoPregunta3()
        {
            Pregunta3 = false;

			GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("CorrectAnswer"), transform.position);
		}

        public void AciertoPregunta4()
        {
            Pregunta4 = false;

			GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("CorrectAnswer"), transform.position);
		}

        public void AciertoPregunta5()
        {
            Pregunta5 = false;

			GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("CorrectAnswer"), transform.position);
		}

        public void AciertoPregunta6()
        {
            Pregunta6 = false;

			GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("CorrectAnswer"), transform.position);
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