using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaScript : MonoBehaviour
{
    [SerializeField] private Tienda _tienda;
    private GameObject[] _itemTienda;
    [SerializeField]private Vector3 _posicionItem;

    private void Start()
    {
        _itemTienda=new GameObject[_tienda.itemsTienda.Length];
        for (int i = 0; i < _tienda.itemsTienda.Length; i++)
        {
            _itemTienda[i] = Instantiate(_tienda.itemsTienda[i], _posicionItem,Quaternion.identity,transform.parent);
            _posicionItem += Vector3.right*2;
        }
    }
    
}
