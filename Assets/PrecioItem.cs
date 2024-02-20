using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PrecioItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textoPrecio;
    private ItemData _item;
    private ItemBonificador _itemBonificador;
    private void Awake()
    {
        
    }
    private void Start()
    {
        _item = GetComponentInParent<ComprableTienda>().Item;
        _itemBonificador = _item.GetComponent<ItemBonificador>();a
        _textoPrecio.text = $"{_itemBonificador.Valor}";
    }
}
