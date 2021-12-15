using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GanhouResgate1 : MonoBehaviour
{

    public GameObject urso;
    public GameObject ursa;
    public GameObject ursaTriste;
    public GameObject grade;
    public GameObject paredeE;
    public GameObject paredeD;
    public bool acabou = false;
    public bool dispensar;
    private float tempo = 0;
    public float velocidadeUrso = 6;
    public float velocidadeParede = 10;
    // Start is called before the first frame update
    void Start()
    {
    }

    void gravarDados()
    {
        for (int i = 0; i < 3; i++) // For para gravar dados
        {
            if (PlayerPrefs.HasKey("Exp" + i) == false) // Caso haja algum slot vazio, grava.
            {
                Debug.Log("Exp" + i + "esta vazio");
                PlayerPrefs.SetString("Exp" + i, ParametrosStatic.nomeExp);
                PlayerPrefs.SetString("Suj" + i, ParametrosStatic.nomeSuj);
                PlayerPrefs.SetInt("Idade" + i, ParametrosStatic.idade);
                PlayerPrefs.SetInt("Chances" + i, ParametrosStatic.chances);
                PlayerPrefs.SetInt("Acertos" + i, ParametrosStatic.acertos);
                PlayerPrefs.SetInt("Erros" + i, ParametrosStatic.erros);
                PlayerPrefs.SetString("Hora" + i, System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

                SceneManager.LoadScene("Configuracoes");

                dispensar = true; // Controle para sair do for e ir pra cena seguinte
                break;
                //i = 3;
            }
        }
        if (dispensar == false) // Caso todos os slots estejam cheios, entra a substituição
        {
            for (int i = 0; i < 2; i++) // Nesse for, todos os slots serão repassados para o índice, fazendo com o índice 2 fique vazio.
            {
                Debug.Log("entrando na substituição " + i);
                PlayerPrefs.SetString("Exp" + i, PlayerPrefs.GetString("Exp" + (i + 1)));
                PlayerPrefs.SetString("Suj" + i, PlayerPrefs.GetString("Suj" + (i + 1)));
                PlayerPrefs.SetInt("Idade" + i, PlayerPrefs.GetInt("Idade" + (i + 1)));
                PlayerPrefs.SetInt("Chances" + i, PlayerPrefs.GetInt("Chances" + (i + 1)));
                PlayerPrefs.SetInt("Acertos" + i, PlayerPrefs.GetInt("Acertos" + (i + 1)));
                PlayerPrefs.SetString("Sexo" + i, PlayerPrefs.GetString("Sexo" + (i + 1)));
                PlayerPrefs.SetInt("Erros" + i, PlayerPrefs.GetInt("Erros" + (i + 1)));
                PlayerPrefs.SetString("Hora" + i, PlayerPrefs.GetString("Hora" + (i + 1)));
            }
            PlayerPrefs.SetString("Exp2", ParametrosStatic.nomeExp); // Gravando os dados no índice 2.
            PlayerPrefs.SetString("Suj2", ParametrosStatic.nomeSuj);
            PlayerPrefs.SetInt("Idade2", ParametrosStatic.idade);
            PlayerPrefs.SetInt("Chances2", ParametrosStatic.chances);
            PlayerPrefs.SetInt("Acertos2", ParametrosStatic.acertos);
            PlayerPrefs.SetString("Sexo2", ParametrosStatic.sexo);
            PlayerPrefs.SetInt("Erros2", ParametrosStatic.erros);
            PlayerPrefs.SetString("Hora2", System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }

        SceneManager.LoadScene("Configuracoes");
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;

        if (Bola.salvou) // Animações referentes a sucesso e fracasso da jogada.
        {
            if (grade.gameObject.transform.position.y < 2.5) grade.gameObject.transform.Translate(Vector3.up * Time.deltaTime);
            if (urso.gameObject.transform.position.x < 6) urso.gameObject.transform.Translate(Vector3.right * Time.deltaTime * velocidadeUrso);
            if (ursa.gameObject.transform.position.x > 8) ursa.gameObject.transform.Translate(Vector3.left * Time.deltaTime * velocidadeUrso);
        }
        else
        {
            if (ursaTriste.gameObject.transform.position.x > 8) ursaTriste.gameObject.transform.Translate(Vector3.left * Time.deltaTime * velocidadeUrso);

        }
        if(tempo > 3) // Fecha as paredes após 3 segundos.
        {
            if (paredeD.transform.position.x >= 8.1) paredeD.transform.Translate(Vector3.left * Time.deltaTime * velocidadeParede);
            if (paredeE.transform.position.x < -18.64) paredeE.transform.Translate(Vector3.right * Time.deltaTime * velocidadeParede);

        }

        if (paredeD.transform.position.x < 8.2) // Verificação para execução da próxima cena após uma tentativa.
        {
            if (ParametrosStatic.nroTentativas > 0) // Enquanto o nroTentativas for maior que 0, recarrega a mesma cena.
            {
                SceneManager.LoadScene("CenaResgate");
            }
            else
            {
                gravarDados();
            }
        }

    }
}
