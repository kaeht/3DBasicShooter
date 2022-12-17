using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject bullet;

    public float speedBullet = 1500f;
    public float shotRate = 0.5f;

    private float shotRateTime = 0;


    void Update()
    {
        Shooting();      
    }

    // Metodo que nos permite disparar
    public void Shooting()
    {
        // Boton que genera la accion
        if (Input.GetButtonDown("Fire1"))
        {
            // Control de cadencia de disparo
            if (Time.time > shotRateTime)
            {
                // Instanciamos la bala
                GameObject newBullet;

                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                // Otorgamos Trayectoria y velocidad al objeto
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * speedBullet);

                // Controlamos el tiempo de cadencia
                shotRateTime = Time.time + shotRate;

                // Destruimos la bala
                Destroy(newBullet, 3);
            }

        }
    }
}
