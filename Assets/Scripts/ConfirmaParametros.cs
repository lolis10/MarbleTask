using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ConfirmaParametros : MonoBehaviour
{
    public Text nomeExp;
    public Text nomeSuj;
    public Text dataNasc;
    public Text NroTentativas;
    public Text sexo;
    public Text dominio;
    public Text obstaculo;

    // Start is called before the first frame update
    void Start() // Exibe as informações de entrada anteriormente preenchidas.
    {
        nomeExp.text += ": " + ParametrosStatic.nomeExp;
        nomeSuj.text += ": " + ParametrosStatic.nomeSuj;
        dataNasc.text += ": " + Parametros.dataaux;
        NroTentativas.text += ": " + ParametrosStatic.nroTentativas;
        sexo.text += ": " + ParametrosStatic.sexo;
        dominio.text += ": " + ParametrosStatic.dominio;
        obstaculo.text += ": " + ParametrosStatic.obstaculo;
}
    public void Confirma() // Confirma o inicio da jogada com as informações preenchidas.
    {
        Gravar.addRecord("Experimentador", "Sujeito", "Meses", "Tentativa", "Acerto(s)", "Erro(s)", "Lateralidade", "Lado do Obstaculo", "Esperado", "Obtido", "Data/Hora", "Sexo", "Tempo de reacao", "Tempo observado", "Tempo total gasto", "Tempo com bola", ParametrosStatic.nomeSuj + ".csv");

        if (ParametrosStatic.chancesTreino > 0) // Caso chancesTreino tenha sido setada, entra na cena de treino
        {
            SceneManager.LoadScene("TreinoResgate");
        }
        else
        {
            SceneManager.LoadScene("CenaResgate"); // Caso chancesTreino não tenha sido setada, entra na cena principal do jogo.
        }
        
    }

    public void Voltar() // Volta para cena Configurações.
    {
        SceneManager.LoadScene("Configuracoes");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
