using FMOD.Studio;
using Gamekit2D;
using UnityEngine;

public class FMODPlayerAudio : MonoBehaviour
{
    [Header("Player")]
    private CharacterController2D _playerController;
    private PlayerCharacter _playerCharacter;

    [SerializeField]
    private bool _isRunning;

    [Header("FMOD Settings")]
    [SerializeField] private string _materialParameterName;
    [SerializeField] private string _speedParameterName;
    [SerializeField] private string _jumpOrLandParameterName;

    [Header("Playback Settings")]
    [SerializeField] private float _stepDistance = 2.0f;
    [SerializeField] private float _rayDistance = 1.2f;
    [SerializeField] private float _startRunningTime = 0.3f;
    public string[] m_materialTypes;

    private float _stepRandom;
    private Vector3 _prevPos;
    private float _distanceTravelled;

    private RaycastHit _hit;
    private int _fMaterialValue;

    private bool _previosulyTouchingGround;

    private float _timeTakenSinceStep;
    private int _fPlayerRunning;

    void Start()
    {
        _stepRandom = Random.Range(0f, 0.5f);
        _prevPos = transform.position;

        _playerController = GetComponent<CharacterController2D>();
        _playerCharacter = GetComponent<PlayerCharacter>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _playerCharacter.maxSpeed = 10;
            _isRunning = true;
        }
        else
        {
            _playerCharacter.maxSpeed = 7;
            _isRunning = false;
        }

        Debug.DrawRay(transform.position, Vector3.down * _rayDistance, Color.blue);
        
        if (_playerController.IsGrounded && _playerCharacter.CheckForJumpInput())
        {
            MaterialCheck(); 
            PlayJumpOrLand(true);
        }
        if (!_previosulyTouchingGround && _playerController.IsGrounded)
        {
            MaterialCheck(); 
            PlayJumpOrLand(false);
        }
        _previosulyTouchingGround = _playerController.IsGrounded;

        _timeTakenSinceStep += Time.deltaTime;
        _distanceTravelled += (transform.position - _prevPos).magnitude;

        if (_distanceTravelled >= _stepDistance + _stepRandom)
        {
            MaterialCheck(); 
            SpeedCheck();

            if (_playerController.IsGrounded)
            {
                EventInstance footstep = GameManager.Instance.audioManager.CreateInstance(GameManager.Instance.fmodEvents.GetEvent("Footstep"));
                FMODUnity.RuntimeManager.AttachInstanceToGameObject(footstep, transform, GetComponent<Rigidbody2D>());
                footstep.setParameterByName(_materialParameterName, _fMaterialValue);
                footstep.setParameterByName(_speedParameterName, _fPlayerRunning);
                footstep.start();
            }

            _stepRandom = Random.Range(0f, 0.5f); 
            _distanceTravelled = 0f;
        }
        _prevPos = transform.position;
    }


    void MaterialCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out _hit, _rayDistance))
        {
            if (_hit.collider.gameObject.GetComponent<FMODMaterialSetter>())
            {
                _fMaterialValue = _hit.collider.gameObject.GetComponent<FMODMaterialSetter>().MaterialValue;
            }
            else
            {
                _fMaterialValue = 0;
            }
        }
        else
        {
            _fMaterialValue = 0;
        }
    }

    void SpeedCheck()
    {
        _fPlayerRunning = _isRunning ? 1 : 0;

        //if (_timeTakenSinceStep < _startRunningTime)
        //{
        //    _fPlayerRunning = 1;
        //}
        //else {
        //    _fPlayerRunning = 0;
        //    _timeTakenSinceStep = 0f;
        //}
    }

    void PlayJumpOrLand(bool F_JumpLandCalc)
    {
        EventInstance jumpOrLand = GameManager.Instance.audioManager.CreateInstance(GameManager.Instance.fmodEvents.GetEvent("JumpLand"));
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(jumpOrLand, transform, GetComponent<Rigidbody2D>()); 
        jumpOrLand.setParameterByName(_materialParameterName, _fMaterialValue);
        jumpOrLand.setParameterByName(_jumpOrLandParameterName, F_JumpLandCalc ? 0f : 1f);
        jumpOrLand.start();
        //jumpOrLand.release();
    }
}

