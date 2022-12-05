using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    private PlayerMotor pMotor;
    private PlayerLook pLook;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        pMotor = GetComponent<PlayerMotor>();
        pLook = GetComponent<PlayerLook>();

        //Si se acciona el Salto, este llama al ctx(contexto) el cual nos trae la función de Jump del pMotor
        onFoot.Jump.performed += ctx => pMotor.Jump();

        onFoot.Crouch.performed += ctx => pMotor.Crouch();
        onFoot.Sprint.performed += ctx => pMotor.Sprint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Comunicar al PlayerMotor el valor del movimiento actual generado por el jugador
        pMotor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        pLook.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    //Activamos las acciones
    void OnEnable()
    {
        onFoot.Enable();
    }

    //Desactivamos las acciones
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
