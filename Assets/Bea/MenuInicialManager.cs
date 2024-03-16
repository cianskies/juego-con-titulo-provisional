using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInicialManager : MonoBehaviour
{

    [Header("Titulo")]
    [SerializeField]private GameObject _panelTitulo;
    [SerializeField] private GameObject _botonJugar;

    [Header("player")]
    [SerializeField] private GameObject _prefabPersonaje;

    private static MenuInicialManager _instancia;
    public static MenuInicialManager Insatancia { get { return _instancia; } set { _instancia = value; } }

    private void Awake()
    {
        _instancia = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickBotonJugar()
    {
        Instantiate(_prefabPersonaje, Vector3.zero, Quaternion.identity);
        _panelTitulo.SetActive(false);
        _botonJugar.SetActive(false);
    }
}
