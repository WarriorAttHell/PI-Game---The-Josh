using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{

    [SerializeField]
    private InputField userfield = null;
    [SerializeField]
    private InputField passField = null;
    [SerializeField]
    private Text feedbackmsg = null;

    private string url = "http://localhost/login/login.php";


    public void FazerLogin()
    {

        if (userfield.text == "" || passField.text == "")
        {
            FeedBackError("Todos os campos devem ser preenchidos!");

        }
        else
        {
            string usuario = userfield.text;
            string senha = passField.text;


            WWW www = new WWW(url + "?login=" + usuario + "&senha=" + senha);
            StartCoroutine(ValidaLogin(www));
        }

    }

    IEnumerator ValidaLogin(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            if (www.text == "1")
            {
                FeedBackOk("Login realizado com sucesso\nO jogo está sendo carregado..");
                StartCoroutine(CarregaScene());

            }
            else
            {
                FeedBackError("Usuário ou senha inválidos!");
                passField.text = "";
            }

        }
        else
        {
            if (www.error == "couldn't connect to host") ;
            FeedBackError("Servidor indisponível");

        }


    }

    IEnumerator CarregaScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Menu");

    }

    void FeedBackOk(string mensagem)
    {
        feedbackmsg.CrossFadeAlpha(100f, 0f, false);
        feedbackmsg.color = Color.green;
        feedbackmsg.text = mensagem;

    }

    void FeedBackError(string mensagem)
    {
        feedbackmsg.CrossFadeAlpha(100f, 0f, false);
        feedbackmsg.color = Color.red;
        feedbackmsg.text = mensagem;
        feedbackmsg.CrossFadeAlpha(0f, 2f, false);

    }

}


