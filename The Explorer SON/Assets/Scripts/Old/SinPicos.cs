using UnityEngine;

namespace Gamekit2D {
	public class SinPicos : MonoBehaviour {
		public Animator animator;
		public SpriteRenderer SpriteEllen;
		public SpriteRenderer SpriteExplorer;
		public Transform PositionEllen;
		public Transform PositionExplorer;
		bool derecha = true;
		public static bool texto = false;

		void Start() {
			if (PlayerCharacter.UsoPicos == true) {
				SpriteExplorer.enabled = false;
				SpriteEllen.enabled = true;
			}
			else {
				SpriteExplorer.enabled = true;
				SpriteEllen.enabled = false;
			}
		}

		void Update() {
			PositionExplorer.position = PositionEllen.position;

			if (PlayerCharacter.UsoPicos == true) {
				SpriteExplorer.enabled = false;
				SpriteEllen.enabled = true;
			}
			else {
				SpriteExplorer.enabled = true;
				SpriteEllen.enabled = false;
			}

			animator.SetFloat("VerticalSpeed", PlayerCharacter.m_MoveVector.y);
			animator.SetFloat("HorizontalSpeed", Mathf.Abs(PlayerCharacter.m_MoveVector.x));
			animator.SetBool("Grounded", PlayerCharacter.m_CharacterController2D.IsGrounded);
			animator.SetBool("Texto", texto);

			if (Input.GetKey(KeyCode.D) && texto == false) {
				SpriteExplorer.flipX = false;
			}
			else if (Input.GetKey(KeyCode.A) && texto == false) {
				SpriteExplorer.flipX = true;
			}

			if (Input.GetKey(KeyCode.Space) && PlayerCharacter.m_CharacterController2D.IsGrounded == true && texto == false) {
				GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("Jump"), transform.position);
			}
		}

		public void EntroACueva() {
			SpriteExplorer.color = Color.grey;
		}

		public void SalgoDeCueva() {
			SpriteExplorer.color = Color.white;
		}

		public void Texto() {
			SpriteEllen.enabled = false;
			SpriteExplorer.enabled = true;
			PlayerCharacter.PuedoMoverme = false;
			texto = true;
			PlayerCharacter.UsoPicos = false;
		}

		public void CierroTexto() {
			if (PlayerCharacter.UsoPicos == true) {
				SpriteEllen.enabled = true;
				SpriteExplorer.enabled = false;
			}
			PlayerCharacter.PuedoMoverme = true;
			texto = false;
		}
	}
}