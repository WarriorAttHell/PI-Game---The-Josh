using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnVoltar : MonoBehaviour
{

    public void switchscene()
    {

        StartCoroutine(CarregaScene());
    }

    IEnumerator CarregaScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Login");

    }


}
