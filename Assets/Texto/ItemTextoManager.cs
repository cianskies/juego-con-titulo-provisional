using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTextoManager : MonoBehaviour
{
    private static ItemTextoManager _instancia;

    [SerializeField] private TextoItem _prefabTexto;

    public static ItemTextoManager Instancia { get { return _instancia; } }


    private void Awake()
    {
        _instancia = this;
    }
        
    public TextoItem MostrarMensaje(string mensaje,Vector3 posicionTexto, Color color)
    {
        TextoItem texto=Instantiate(_prefabTexto, transform);
        texto.transform.position = posicionTexto;
        texto.EstablecerTexto(mensaje, color);
        return texto;
       
    }
}
