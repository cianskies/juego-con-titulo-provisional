using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Arena : MonoBehaviour
{
    [Header("Debug")]
    public bool _debug;

    [Header("Tileset")]
    [SerializeField] private Tilemap _props;

    private Dictionary<Vector3,bool> _listaDeTiles = new Dictionary<Vector3,bool>();


}
