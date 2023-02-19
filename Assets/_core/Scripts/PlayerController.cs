using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 0.5f;
    [SerializeField] float xRange = 6f;
    [SerializeField] float yRange = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = movement.ReadValue<Vector2>().x;
        float verticalThrow = movement.ReadValue<Vector2>().y;

        float rawXPos = transform.localPosition.x + (horizontalThrow * controlSpeed);
        float rawYPos = transform.localPosition.y + (verticalThrow * controlSpeed);
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange,yRange);

        transform.localPosition = new Vector3
            (clampedXPos,
            clampedYPos, 
            transform.localPosition.z);

        //Old Input System
        //float horizontalThrow = Input.GetAxis("Horizontal");
        //float verticalThrow = Input.GetAxis("Vertical");
        //Debug.Log("Horizontal: " + horizontalThrow + "Vertical: " + verticalThrow);





    }
}
