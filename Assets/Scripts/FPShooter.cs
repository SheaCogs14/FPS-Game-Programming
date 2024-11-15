using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPShooter : MonoBehaviour
{

    private CharacterController _controller;
    private float _xRotation;

    [Header("Movement Settings")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _mouseSenseitivity = 200f;
    private Vector3 _moveVector;

    [Header("Camera Settings")]
    [SerializeField] private float xCameraBounds = 60f;
    private Camera _camera;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _camera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    #region Smothing Code
    private Vector2 _currentMouseDelta;
    private Vector2 _currentMouseVelocity;
    [SerializeField] private float _smoothTime = .1f;
    #endregion 



    void Update()
    {
        Movement();
        CameraMovement();
    }


    private void Movement()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        _moveVector = transform.forward * moveY + transform.right * moveX;
        _moveVector.Normalize();
        _moveVector *= _speed;

        _controller.SimpleMove(_moveVector);
    }

    private void CameraMovement()
    {

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _mouseSenseitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _mouseSenseitivity;

        Vector2 targetDeleta = new Vector2(mouseX, mouseY);

        _currentMouseDelta = Vector2.SmoothDamp(_currentMouseDelta, targetDeleta, ref _currentMouseVelocity, _smoothTime);
        _xRotation = _currentMouseDelta.y;
        _xRotation = Mathf.Clamp(_xRotation, -xCameraBounds, xCameraBounds);
        transform.Rotate(Vector3.up * _currentMouseDelta);
        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);


    }


}
