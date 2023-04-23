using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private CinemachineInputProvider _cinemachineInputProvider;

    private CharacterInputSystem _input;

    private Coroutine _activateLookJob;

    private void Awake()
    {
        _input = new CharacterInputSystem();
    }

    void Start()
    {
        _cinemachineInputProvider.enabled = false;
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Camera.ActivateLook.performed += OnActivatedLook;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Camera.ActivateLook.performed -= OnActivatedLook;
    }

    private void OnActivatedLook(InputAction.CallbackContext callbackContext)
    {
        _activateLookJob = StartCoroutine(ActivateLook(callbackContext));
    }

    private IEnumerator ActivateLook(InputAction.CallbackContext callbackContext)
    {
        _cinemachineInputProvider.enabled = true;

        while (callbackContext.performed)
            yield return null;

        _cinemachineInputProvider.enabled = false;
        StopCoroutine(_activateLookJob);
    }
}