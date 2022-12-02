using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Mensaje que se le muestra al jugador para interactuar con el objeto.
    public string promptMessage;

    // Funcion de llamada para el jugador
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        // No hay que poner codigo aqui
        // Esta plantilla sera sobreescrita por sus subclases
    }
}
