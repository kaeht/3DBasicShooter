using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Mensaje que se le muestra al jugador para interactuar con el objeto.
    public string promptMessage;

    // Llamada a la base que trae las caracteristicas del componente que Interactua (boton, armas, quest, etc...)
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        // No hay que poner codigo aqui
        // Esta plantilla sera sobreescrita por sus subclases (contenidos de los objetos Inteactuables)
    }
}
