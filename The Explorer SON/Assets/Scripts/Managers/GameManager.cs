using Gamekit2D;

using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	[HideInInspector] public AudioManager audioManager;
	[HideInInspector] public FMODEvents fmodEvents;

#if UNITY_EDITOR
	[Header("Hack de progreso. Pausar el juego para cambiar las variables.")]
	[SerializeField] bool aplicarCambios = false;
	
	[Header("Visor de variables estáticas")]
	[SerializeField] bool puedoMoverme;
	[SerializeField] bool tengoPigmentoRojo;
	[SerializeField] bool tengoPigmentoNegro;
	[SerializeField] bool tengoGafas;
	[SerializeField] bool tengoPalos;
	[SerializeField] bool tengoTubo;
	[SerializeField] bool tengoResina;
	[SerializeField] bool tengoPicos;
	[SerializeField] bool usoPicos;
	[Space]
	[SerializeField] int cualDigo;
	[SerializeField] bool transitionPointActivo;
	[Space]
	[SerializeField] bool data1;
	[SerializeField] bool data2;
	[SerializeField] bool data3;
	[SerializeField] bool data4;
	[SerializeField] bool data5;
	[SerializeField] bool acerte;
	[Space]
	[SerializeField] bool dialogo0;
	[SerializeField] bool dialogo1;
	[SerializeField] bool dialogo2;
	[SerializeField] bool dialogo3;
	[SerializeField] bool dialogo4;
	[SerializeField] bool dialogo5;
	[SerializeField] bool dialogo6;
	[SerializeField] bool dialogo7;
	[SerializeField] bool dialogo8;
	[SerializeField] bool dialogo9;
	[SerializeField] bool dialogo10;
	[SerializeField] bool dialogo11;
	[SerializeField] bool dialogo12;
	[SerializeField] bool dialogo13;
	[SerializeField] bool dialogo14;
	[SerializeField] bool dialogo15;
	[SerializeField] bool dialogo16;
	[SerializeField] bool dialogo17;
	[Space]
	[SerializeField] bool picosB;
	[Space]
	[SerializeField] bool pregunta1;
	[SerializeField] bool pregunta2;
	[SerializeField] bool pregunta3;
	[SerializeField] bool pregunta4;
	[SerializeField] bool pregunta5;
	[SerializeField] bool pregunta6;
	[Space]
	[SerializeField] bool heConstruidoElTelescopio;
	[Space]
	[SerializeField] bool primeraVez;
	[SerializeField] bool vengoFoto1;
	[SerializeField] bool vengoFoto2;
	[Space]
	[SerializeField] int numberD;
	[SerializeField] int numeroFallos;
	[SerializeField] bool texto;
#endif

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
	}

	private void Start() {
		audioManager = GetComponentInChildren<AudioManager>();
		fmodEvents = GetComponentInChildren<FMODEvents>();
	}

#if UNITY_EDITOR
	private void Update() {
		if (aplicarCambios) {
			aplicarCambios = false;
			Debug.Log("Cambios Aplicados");

			PlayerCharacter.PuedoMoverme = puedoMoverme;
			PlayerCharacter.TengoPigmentoRojo = tengoPigmentoRojo;
			PlayerCharacter.TengoPigmentoNegro = tengoPigmentoNegro;
			PlayerCharacter.TengoGafas = tengoGafas;
			PlayerCharacter.TengoPalos = tengoPalos;
			PlayerCharacter.TengoTubo = tengoTubo;
			PlayerCharacter.TengoResina = tengoResina;
			PlayerCharacter.TengoPicos = tengoPicos;
			PlayerCharacter.UsoPicos = usoPicos;

			Puerta.CualDigo = cualDigo;
			Puerta.TransitionPointActivo = transitionPointActivo;

			ActivateData.Data1 = data1;
			ActivateData.Data2 = data2;
			ActivateData.Data3 = data3;
			ActivateData.Data4 = data4;
			ActivateData.Data5 = data5;

			Poste.Acerte = acerte;

			Dialogo.Dialogo0 = dialogo0;
			Dialogo.Dialogo1 = dialogo1;
			Dialogo.Dialogo2 = dialogo2;
			Dialogo.Dialogo3 = dialogo3;
			Dialogo.Dialogo4 = dialogo4;
			Dialogo.Dialogo5 = dialogo5;
			Dialogo.Dialogo6 = dialogo6;
			Dialogo.Dialogo7 = dialogo7;
			Dialogo.Dialogo8 = dialogo8;
			Dialogo.Dialogo9 = dialogo9;
			Dialogo.Dialogo10 = dialogo10;
			Dialogo.Dialogo11 = dialogo11;
			Dialogo.Dialogo12 = dialogo12;
			Dialogo.Dialogo13 = dialogo13;
			Dialogo.Dialogo14 = dialogo14;
			Dialogo.Dialogo15 = dialogo15;
			Dialogo.Dialogo16 = dialogo16;
			Dialogo.Dialogo17 = dialogo17;
			Dialogo.PicosB = picosB;
			Dialogo.Pregunta1 = pregunta1;
			Dialogo.Pregunta2 = pregunta2;
			Dialogo.Pregunta3 = pregunta3;
			Dialogo.Pregunta4 = pregunta4;
			Dialogo.Pregunta5 = pregunta5;
			Dialogo.Pregunta6 = pregunta6;
			Dialogo.HeConstruidoelTelescopio = heConstruidoElTelescopio;
			Dialogo.PrimeraVez = primeraVez;
			Dialogo.VengoFoto1 = vengoFoto1;
			Dialogo.VengoFoto2 = vengoFoto2;
			Dialogo.NumberD = numberD;

			Puntuacion.NumeroFallos = numeroFallos;
			SinPicos.texto = texto;
		}

		puedoMoverme = PlayerCharacter.PuedoMoverme;
		tengoPigmentoRojo = PlayerCharacter.TengoPigmentoRojo;
		tengoPigmentoNegro = PlayerCharacter.TengoPigmentoNegro;
		tengoGafas = PlayerCharacter.TengoGafas;
		tengoPalos = PlayerCharacter.TengoPalos;
		tengoTubo = PlayerCharacter.TengoTubo;
		tengoResina = PlayerCharacter.TengoResina;
		tengoPicos = PlayerCharacter.TengoPicos;
		usoPicos = PlayerCharacter.UsoPicos;
		cualDigo = Puerta.CualDigo;
		transitionPointActivo = Puerta.TransitionPointActivo;
		data1 = ActivateData.Data1;
		data2 = ActivateData.Data2;
		data3 = ActivateData.Data3;
		data4 = ActivateData.Data4;
		data5 = ActivateData.Data5;
		acerte = Poste.Acerte;
		dialogo0 = Dialogo.Dialogo0;
		dialogo1 = Dialogo.Dialogo1;
		dialogo2 = Dialogo.Dialogo2;
		dialogo3 = Dialogo.Dialogo3;
		dialogo4 = Dialogo.Dialogo4;
		dialogo5 = Dialogo.Dialogo5;
		dialogo6 = Dialogo.Dialogo6;
		dialogo7 = Dialogo.Dialogo7;
		dialogo8 = Dialogo.Dialogo8;
		dialogo9 = Dialogo.Dialogo9;
		dialogo10 = Dialogo.Dialogo10;
		dialogo11 = Dialogo.Dialogo11;
		dialogo12 = Dialogo.Dialogo12;
		dialogo13 = Dialogo.Dialogo13;
		dialogo14 = Dialogo.Dialogo14;
		dialogo15 = Dialogo.Dialogo15;
		dialogo16 = Dialogo.Dialogo16;
		dialogo17 = Dialogo.Dialogo17;
		picosB = Dialogo.PicosB;
		pregunta1 = Dialogo.Pregunta1;
		pregunta2 = Dialogo.Pregunta2;
		pregunta3 = Dialogo.Pregunta3;
		pregunta4 = Dialogo.Pregunta4;
		pregunta5 = Dialogo.Pregunta5;
		pregunta6 = Dialogo.Pregunta6;
		heConstruidoElTelescopio = Dialogo.HeConstruidoelTelescopio;
		primeraVez = Dialogo.PrimeraVez;
		vengoFoto1 = Dialogo.VengoFoto1;
		vengoFoto2 = Dialogo.VengoFoto2;
		numberD = Dialogo.NumberD;
		numeroFallos = Puntuacion.NumeroFallos;
		texto = SinPicos.texto;
	}
#endif
}
