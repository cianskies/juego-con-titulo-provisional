using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Valores")]
    [SerializeField] private float _velocidadAmmo;
    private Vector3 _direccionDisparo;
    private float _atk;

    public Vector3 DireccionDisparo { get { return _direccionDisparo;} set { _direccionDisparo = value; } } 
    public float Atk { get { return _atk;} set { _atk = value; } }
    public void Update()
    {
        transform.Translate(_direccionDisparo * (_velocidadAmmo * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
