using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CadastroScript : MonoBehaviour
{

    [SerializeField]
    private InputField userfield = null;
    [SerializeField]
    private InputField passField = null;
    [SerializeField]
    private InputField confirmPass = null;
    [SerializeField]
    private Text feedbackmsg = null;

    private string urlCadastro = "http://localhost/login/registro.php";

    private string urlLogin = "http://localhost/login/validalogin.php";

    public void CadastroUser()
    {

        string usuario = userfield.text;
        string senha = passField.text;
        string confirmSenha = confirmPass.text;

        if (userfield.text == "" || passField.text == "" || confirmPass.text == "")
        {
            FeedBackError("Todos os campos devem ser preenchidos!");

        }
        else
        {
            WWW www = new WWW(urlLogin + "?login=" + usuario);
            StartCoroutine(ValidaLogin(www));

        }

    }

    IEnumerator ValidaLogin(WWW www)
    {
        string usuario = userfield.text;
        string senha = passField.text;
        string confirmSenha = confirmPass.text;

        yield return www;
        if (www.error == null)
        {
            if (www.text == "1")
            {
                FeedBackError("Usuário já existente\nDigite sua senha para iniciar o jogo.");
            }
            else
            {
                if (senha != confirmSenha)
                {
                    FeedBackError("As senhas devem ser iguais!");
                    passField.text = "";
                    confirmPass.text = "";
                }
                else
                {
                    WWW www2 = new WWW(urlCadastro + "?login=" + usuario + "&senha=" + senha);
                    StartCoroutine(ValidaCadastro(www2));
                }


            }

        }
        else
        {
            if (www.error == "couldn't connect to host") ;
            FeedBackError("Servidor indisponível");

        }


    }

    IEnumerator ValidaCadastro(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            if (www.text == "1")
            {
                FeedBackOk("Cadastro realizado com sucesso.");
                StartCoroutine(CarregaScene());

            }
            else
            {
                FeedBackError("Erro ao cadastrar usuário.");

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
        SceneManager.LoadScene("Login");

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
