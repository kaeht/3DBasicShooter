using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController pController;
    private Vector3 pVelocity;
    private bool isGrounded;
    private bool lerpCrouch;
    private bool crouching;
    private bool sprinting;

    private float crouchTimer;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpH = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        pController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = pController.isGrounded;
        //Realizamos la accion de agacharnos
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;

            if (crouching)
                pController.height = Mathf.Lerp(pController.height, 1, p);
            else
                pController.height = Mathf.Lerp(pController.height, 2, p);

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    //Recibimos los inputs desde nuestro script InputManager.cs y aplicamos los datos en nuestro controllador
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        pController.Move(speed * Time.deltaTime * transform.TransformDirection(moveDirection));

        //Establece la fuerza de gravedad y la presion que ejerce en el jugador
        pVelocity.y += gravity * Time.deltaTime;

        //Fijamos el valor al tocar el suelo para evitar el stack de fuerza gravitatoria frame a frame si ya estamos en el suelo
        if (isGrounded && pVelocity.y < 0)
            pVelocity.y = -2f;

        pController.Move(pVelocity * Time.deltaTime);
    }

    //Generamos la funcion de saltar
    public void Jump()
    {
        if (isGrounded)
        {
            pVelocity.y = Mathf.Sqrt(jumpH * -3.0f * gravity);
        }

    }

    //Generamos la funcion de agacharnos
    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    //Generamos la funcion de esprintar
    public void Sprint()
    {
        sprinting = !sprinting;

        if (sprinting)
            speed = 8;
        else
            speed = 5;
    }
}
