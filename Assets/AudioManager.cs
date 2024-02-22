
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instancia;

    public static AudioManager Instancia {  get { return _instancia; } }    
    public Sonido[] sonidos;
    void Awake()
    {
        _instancia = this;
        foreach(Sonido s in sonidos)
        {
            s.audioSource=gameObject.AddComponent<AudioSource>();
            s.audioSource.clip=s.clip;

            s.audioSource.volume=s.volume;
            s.audioSource.pitch=s.pitch;
        }
    }
    public void Play(String nombre)
    {
        
        Sonido s=Array.Find(sonidos, sonidos => sonidos.Nombre == nombre);
        if (s==null)
        {
            Debug.Log("No se encontro Audio con el nombre " + nombre);
        }
        s.audioSource.Play();

        
    }

}
[Serializable]
public class Sonido
{
    public string Nombre;
    public AudioClip clip;

    [Range(0,100)]public float volume;

    [Range(0, 100)] public float pitch;

    [HideInInspector]
    public AudioSource audioSource;



}
