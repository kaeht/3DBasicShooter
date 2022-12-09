using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Habilita o deshabilita un componente InteractionEvent para este gameObjetc.
    public bool useEvents;

    [SerializeField]
    // Mensaje que se le muestra al jugador para interactuar con el objeto.
    public string promptMessage;

    public virtual string OnLook()
    {
        return promptMessage;
    }

    // Llamada a la base que trae las caracteristicas del componente que Interactua (boton, armas, quest, etc...)
    public void BaseInteract()
    {
        if (useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }

    protected virtual void Interact()
    {
        // No hay que poner codigo aqui
        // Esta plantilla sera sobreescrita por sus subclases (contenidos de los objetos Inteactuables)
    }
}
