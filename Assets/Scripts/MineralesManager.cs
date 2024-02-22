using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralesManager : MonoBehaviour
{

    [Header("Debug")]
    [SerializeField] private float _mineralesBase;


    private static MineralesManager _instancia;

    public static MineralesManager Instancia
    {
        get
        {
            if (_instancia == null)
            {
                _instancia = FindObjectOfType<MineralesManager>();
                if (_instancia == null)
                {
                    GameObject singletonObject = new GameObject("MineralesManager");
                    _instancia = singletonObject.AddComponent<MineralesManager>();
                    DontDestroyOnLoad(singletonObject); // Esto hace que el GameObject no se destruya al cargar una nueva escena
                }
            }
            return _instancia;
        }
    }
    private float _minerales;
    private const string MINERALES_KEY = "keyMinerales";
    public float Minerales { get { return _minerales; } }
    private void Start()
    {
        _minerales=PlayerPrefs.GetFloat(MINERALES_KEY,_mineralesBase);
    }
    public void SumarMinerales(float minerales)
    {
        _minerales+=(minerales);
        PlayerPrefs.SetFloat(MINERALES_KEY, _minerales);
        PlayerPrefs.Save();
    }
    public void RestarMinerales(float minerales)
    {
        if(_minerales>=minerales)
        {
            _minerales-=minerales;
            PlayerPrefs.SetFloat(MINERALES_KEY, _minerales);
            PlayerPrefs.Save();
        }
    }
}
