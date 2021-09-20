using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float m_walkingSpeed = 7.5f;
    public float m_runningSpeed = 11.5f;
    public float m_jumpSpeed = 8.0f;
    public float m_gravity = 20.0f;
    public Camera PlayerCamera { get; private set; }
    public float m_lookSpeed = 2.0f;
    public float m_lookXLimit = 45.0f;
    public CharacterController CharacterController { get; private set; }

    public ScrollShoot m_shoot;

    public int m_initialAmountOfBullet = 100;

    public Text m_totalAmmoText;
    
    Vector3 _speed = Vector3.zero;
    float _rotationX = 0;
    private bool CanMove { get; set; } = true;

    public PlayerInventory Inventory { get; private set; }

    private void Awake()
    {
        Inventory = new PlayerInventory(this);
        Inventory.TotalAmountOfBullet = m_initialAmountOfBullet;
    }

    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        m_shoot.Player = this;
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerCamera = Camera.main;
        
    }

    void Update()
    {
        // Player and Camera rotation
        if (CanMove)
        {
            UpdateMove();
        }
        UpdateGravity();

        if (m_totalAmmoText!=null)
        {
            m_totalAmmoText.text = ""+Inventory.TotalAmountOfBullet;
        }

        // Move the controller
        CharacterController.Move(_speed * Time.deltaTime);
    }

    public void UpdateMove()
    {
        _rotationX += -Input.GetAxis("Mouse Y") * m_lookSpeed;
        _rotationX = Mathf.Clamp(_rotationX, -m_lookXLimit, m_lookXLimit);
        PlayerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * m_lookSpeed, 0);
        
        
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = CanMove ? (isRunning ? m_runningSpeed : m_walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = CanMove ? (isRunning ? m_runningSpeed : m_walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = _speed.y;
        _speed = (forward * curSpeedX) + (right * curSpeedY);
        if (Input.GetButton("Jump") && CharacterController.isGrounded)
        {
            _speed.y = m_jumpSpeed;
        }
        else
        {
            _speed.y = movementDirectionY;
        }
    }

    public void UpdateGravity()
    {
        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!CharacterController.isGrounded)
        {
            _speed.y -= m_gravity * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (other.gameObject.GetComponent<IItem>().OnPickUp(Inventory))
            {
                Destroy(other.gameObject);
            }
        }
    }
    
    public class PlayerInventory
    {
        private PlayerControl _playerControl;
        public PlayerInventory(PlayerControl playerControl)
        {
            _playerControl = playerControl;
        }

        public int TotalAmountOfBullet;

        public bool ClearField = false;
    }
}
