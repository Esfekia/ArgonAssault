using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    
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

        float newXPos = transform.localPosition.x + horizontalThrow;
        float newYPos = transform.localPosition.y + verticalThrow;

        transform.localPosition = new Vector3
            (newXPos,
            newYPos, 
            transform.localPosition.z);

        //Old Input System
        //float horizontalThrow = Input.GetAxis("Horizontal");
        //float verticalThrow = Input.GetAxis("Vertical");
        //Debug.Log("Horizontal: " + horizontalThrow + "Vertical: " + verticalThrow);





    }
}
