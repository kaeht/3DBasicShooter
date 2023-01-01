using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    // Referenciamos el objeto NavMeshAgent que contiene los parametros del objeto sobre la malla
    public NavMeshAgent navMA;

    // Referenciamos el objeto al que seguira el enemigo
    public GameObject destino;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // La posicion del navMA sera igual a la posicion del objeto destino a cada frame
        navMA.destination = destino.transform.position;
    }
}
