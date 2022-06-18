using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Camera Adjustments")]    
    [SerializeField] Vector3 cameraOffsetOnLeft;
    [SerializeField] Vector3 gunOffsetOnLeft;
    [SerializeField] Vector3 cameraRotation;
    [SerializeField] float cameraTuningRotationLeft = 15f;
    enum Handed {dextrous, lefty};
    [SerializeField] Handed handPreference;
    [Space]
    [SerializeField] Texture aimTexture;
    [Space]
    [Header("Speed")]
    [SerializeField] float speedWalking = 2f;
    [SerializeField] float speedRuning = 6f;    
    [SerializeField] float speedRotating = 2;

    protected Camera playersCamera;
    protected Gun playersGun;
    protected GameObject cameraTuning;
    private float m_yaw = 0;
    private float m_pitch = 0;

    private void Awake()
    {
        playersCamera = gameObject.GetComponentInChildren<Camera>();
        //playersCamera = transform.Find("Camera3rd").gameObject.GetComponent<Camera>();
        playersGun = gameObject.GetComponentInChildren<Gun>();
        //playersGun = transform.Find("Gun").gameObject.GetComponent<Gun>();
        cameraTuning = transform.Find("CameraTuning").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        // ABSTRACTION
        SetHanded();        
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
        playersGun.transform.Rotate(Vector3.right, m_pitch);
    }

    // ABSTRACTION
    public void SetHanded()
    {
        switch (handPreference)
        {
            case Handed.dextrous:
                playersCamera.transform.position = transform.position + new Vector3(-cameraOffsetOnLeft.x, cameraOffsetOnLeft.y, cameraOffsetOnLeft.z);
                playersGun.transform.position = transform.position + new Vector3(-gunOffsetOnLeft.x, gunOffsetOnLeft.y, gunOffsetOnLeft.z);
                cameraTuning.transform.Rotate(new Vector3(0, cameraTuningRotationLeft, 0));
                break;
            default:                 
                playersCamera.transform.position = transform.position + cameraOffsetOnLeft;
                playersGun.transform.position = transform.position +  gunOffsetOnLeft;
                cameraTuning.transform.Rotate(new Vector3(0, -cameraTuningRotationLeft, 0));
                break;                
        }
    }
}
