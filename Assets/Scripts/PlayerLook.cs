using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensibility = 30f;
    public float ySensibility = 30f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        //Calculamos la rotación de la camara arriba y abajo

        xRotation -= (mouseY * Time.deltaTime) * ySensibility;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        //Aplicamos este proceso a nuestro Camara Transform
        cam.transform.localRotation= Quaternion.Euler(xRotation,0,0);

        //Calculamos la rotación de la camara izquierda derecha

        transform.Rotate((mouseX * Time.deltaTime) * xSensibility * Vector3.up);
    }
}
