using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{

    void OnTriggerEnter(Collider Other)
    {
        if (this.CompareTag("destino"))
        {
            Invoke("NextLevel", 1.85f);
        }
    }
    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Application.Quit();

    }
}
