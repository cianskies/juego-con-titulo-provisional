using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextoItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _texto;

    public void EstablecerTexto(string texto, Color color)
    {
        _texto.text = texto;
        _texto.color = color;
    }
}
