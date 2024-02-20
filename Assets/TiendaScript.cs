using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaScript : MonoBehaviour
{
    [SerializeField] private Tienda _tienda;
    private GameObject[] _itemTienda;
    private Vector3 _posicionItem;

    private void Start()
    {
        _posicionItem=transform.position;
        _itemTienda=new GameObject[_tienda.itemsTienda.Length];
        for (int i = 0; i < _tienda.itemsTienda.Length; i++)
        {
            _itemTienda[i] = Instantiate(_tienda.itemsTienda[i], _posicionItem,Quaternion.identity);
            _posicionItem += Vector3.right*2;
        }
    }
    
}
