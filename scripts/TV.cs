using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    // Declaracion de variables: Material, WebCamTexture y String para almacenar el path del directorio donde almacenar las imágenes
    private Material tvMaterial;
    private WebCamTexture webcamTexture;
    private string imagePath = "Assets/Images/";

    int captureCounter = 1;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            // Inicializar el material al que posteriormente se asignará cada imagen-frame de la cámara
            // Es necesario obtener el Renderer del objeto sobre el que se pinta y acceder a su material
            Renderer renderer = GetComponent<Renderer>();
            if (renderer == null)
            {
                throw new System.Exception("El objeto no tiene un componente Renderer.");
            }

            tvMaterial = renderer.material;

            // Usar el constructor de WebCamTexture para inicializar una variable de ese tipo
            webcamTexture = new WebCamTexture();

            // Se debe mostrar el nombre de la cámara en consola
            Debug.Log("Nombre de la cámara: " + webcamTexture.deviceName);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al iniciar el script TV: " + e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s"))
        {
            Debug.Log("Iniciando captura de video...");
            // Asignar a la mainTexture del material lo que capta la cámara
            tvMaterial.mainTexture = webcamTexture;

            // La captura se inicia con webcamTexture.Start()
            webcamTexture.Play();
        }
        if (Input.GetKey("p"))
        {
            Debug.Log("Parando captura de video...");
            // Parar la captura de video
            webcamTexture.Stop();
        }
        if (Input.GetKey("x"))
        {
            Debug.Log("Capturando fotograma...");
            // Tomar fotogramas
            Texture2D snapshot = new Texture2D(webcamTexture.width, webcamTexture.height);
            snapshot.SetPixels(webcamTexture.GetPixels());
            snapshot.Apply();
            System.IO.File.WriteAllBytes(imagePath + captureCounter.ToString() + ".png", snapshot.EncodeToPNG());
            captureCounter++;
        }
    }
}
