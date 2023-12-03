using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	[HideInInspector] public AudioManager audioManager;
	[HideInInspector] public FMODEvents fmodEvents;

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
}
