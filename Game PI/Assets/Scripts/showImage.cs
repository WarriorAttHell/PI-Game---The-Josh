using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class showImage : MonoBehaviour
{
    private Collider[] Colisores;
    public float TempoDaImagem = 1;
    public Image _Imagem;
    void Start()
    {
        _Imagem.enabled = false;
        Colisores = transform.GetComponentsInChildren<Collider>();
    }

    void OnTriggerEnter()
    {
        StartCoroutine(EsperarTempo(TempoDaImagem));
    }

    IEnumerator EsperarTempo(float tempo)
    {
        _Imagem.enabled = true;
        foreach (Collider coll in Colisores)
        {
            coll.enabled = false;
        }
        yield return new WaitForSeconds(tempo);
        _Imagem.enabled = false;
        Destroy(gameObject);
    }
}







