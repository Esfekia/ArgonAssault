using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;
    [SerializeField] float controlSpeed = 0.25f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    [SerializeField] float positionPitchFactor = 2.5f;
    [SerializeField] float positionYawFactor = -2.5f;

    [SerializeField] float controlRollFactor = -7.5f;
    [SerializeField] float controlPitchFactor = 7.5f;

    float horizontalThrow;
    float verticalThrow;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        movement.Enable();
        fire.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        fire.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();

    }

    void ProcessTranslation()
    {
        horizontalThrow = movement.ReadValue<Vector2>().x;
        verticalThrow = movement.ReadValue<Vector2>().y;

        float rawXPos = transform.localPosition.x + (horizontalThrow * controlSpeed);
        float rawYPos = transform.localPosition.y + (verticalThrow * controlSpeed);
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3
            (clampedXPos,
            clampedYPos,
            transform.localPosition.z);

        //Old Input System
        //float horizontalThrow = Input.GetAxis("Horizontal");
        //float verticalThrow = Input.GetAxis("Vertical");
        //Debug.Log("Horizontal: " + horizontalThrow + "Vertical: " + verticalThrow);
    }

    void ProcessRotation()
    {
        // pitch has both position and control variable
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = verticalThrow * controlPitchFactor;

        // yaw has only position variable
        float yawDueToPosition = transform.localPosition.x * positionYawFactor;

        // roll has only control variable
        float rollDueToControl = horizontalThrow * controlRollFactor;

        float pitch =  pitchDueToPosition + pitchDueToControlThrow;
        float yaw = yawDueToPosition;
        float roll = rollDueToControl;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring(){
        // Use new input system to print "firing" when space is pressed
        if (fire.ReadValue<float>() > 0.5f){
            Debug.Log("Firing");
        } 

    }
}