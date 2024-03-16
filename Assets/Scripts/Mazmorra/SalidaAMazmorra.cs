using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalidaAMazmorra : MonoBehaviour
{
    [SerializeField] private GameObject _efectoFade;

    private IEnumerator IEEntrarAMazmorra()
    {
        _efectoFade.SetActive(true);
        SceneManager.LoadScene("EnPartidaEscena");
        yield return new WaitForSeconds(2f);
        _efectoFade.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(IEEntrarAMazmorra());
        }
    }
}
