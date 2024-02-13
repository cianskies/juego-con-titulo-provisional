using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsEnemigo : MonoBehaviour, IRecbirDanho
{
    [SerializeField] private float _salud;

    private SpriteRenderer _spriteRenderer;
    private Color _color;
    private Coroutine _corrutinaCambioColor;

    private float _saludActual;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        _color = _spriteRenderer.color;
        _saludActual = _salud;
    }

    private IEnumerator IERecibirDanho()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        _spriteRenderer.color = _color;
    }
    private void MostrarColorRecibirDanho()
    {
        if(_corrutinaCambioColor!=null) { StopCoroutine(_corrutinaCambioColor); }
        _corrutinaCambioColor=StartCoroutine(IERecibirDanho());
    }
    public void RecibirDanho(float danho)
    {
        _saludActual -= danho;
        MostrarColorRecibirDanho();
        if(_saludActual <= 0)
        {
            Destroy(gameObject);
        }
    }
}
