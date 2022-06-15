using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera playersCamera;
    [SerializeField] Vector3 cameraOffsetOnLeft;
    [SerializeField] Vector3 cameraOffsetOnRight;
    [SerializeField] Vector3 cameraRotation;
    [SerializeField] float speedWalking = 2f;
    [SerializeField] float speedRuning = 6f;
    //[SerializeField] float speedRotating = 360f;
    [SerializeField] float speedRotating = 2;
    private float m_yaw = 0;
    private float m_pitch = 0;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;        
    }

    // Start is called before the first frame update
    void Start()
    {        
        //mainCamera.transform.position = gameObject.transform.forward
    }

    // Update is called once per frame
    void Update()
    {
        float actualSpeed = Input.GetKey(KeyCode.LeftShift) ? speedRuning : speedWalking;
        float hInput = actualSpeed * Input.GetAxis("Horizontal");
        float vInput = actualSpeed * Input.GetAxis("Vertical");
        //float mouseX = Input.GetAxis("Mouse X");
        m_yaw = speedRotating * Input.GetAxis("Mouse X");
        m_pitch = -speedRotating * Input.GetAxis("Mouse Y");

        transform.position += (transform.right * hInput * Time.deltaTime) + (transform.forward * vInput * Time.deltaTime);        
        transform.Rotate(transform.up, m_yaw);
        playersCamera.transform.Rotate(Vector3.right, m_pitch);
    }
}
