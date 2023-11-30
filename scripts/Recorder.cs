using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    // Declaración de una variable de tipo AudioSource para usar en el código
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            // Recuperar el componente AudioSource que se agrega a los altavoces, se asigna a la variable de este tipo declarada anteriormente
            audioSource = GetComponent<AudioSource>();

            // Verificar si se encontró el componente AudioSource
            if (audioSource == null)
            {
                throw new System.Exception("El componente AudioSource no se encontró en este objeto.");
            }

            // Iniciar la recogida de audio por el micrófono
            audioSource.clip = Microphone.Start(null, true, 5, 44100);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al iniciar el script Recorder: " + e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // En cada frame verificar si se ha pulsado la tecla para iniciar la recogida de audio desde el micrófono, por ejemplo, la tecla R
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reproduciendo audio...");
            // Reproducir el clip que se ha vinculado al AudioSource
            audioSource.Play();
        }

        // En cada frame verificar si el usuario ha decidido parar el micrófono, por ejemplo, la tecla P
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Parando la recogida desde el microfono...");
            // Parar la recogida de audio desde el micrófono
            Microphone.End(null);
        }
    }
}
