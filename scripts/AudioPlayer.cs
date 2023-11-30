using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource source;

    bool play;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        play = true;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Spider")
        {
            if (play)
            {
                Debug.Log("Playing");
                source.Play();
                play = false;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Spider" && !play)
        {
            source.Stop();
            play = true;
        }
    }
}
