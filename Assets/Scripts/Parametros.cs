using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.EventSystems;

public class Parametros : MonoBehaviour
{

    public InputField nomeExp; // Dados que serão preenchidos e serão parâmetros para o jogo.
    public InputField nomeSuj;
    public InputField idade;
    public Toggle treinoSim;
    public Toggle masculino;
    public Toggle feminino;
    public Toggle maoDireita;
    public Toggle maoEsquerda;
    public Toggle ladoDir;
    public Toggle ladoEsq;
    public Toggle Pseudo;
    public InputField nroTentativas;

    public bool dispensar = false;

    public static bool mDireita;
    public static int ladoObst = 0;

    public Text texto;
    int diaA;
    int mesA;
    int anoA;
    int diaN;
    int mesN;
    int anoN;
    char[] aux = new char[10];
    char[] data = new char[10];
    int meses;
    int dias;
    bool dataValida = true;

    public static string dataaux;

    void Start()
    {
        
        diaA = Convert.ToInt32(DateTime.Now.ToString("dd"));
        mesA = Convert.ToInt32(DateTime.Now.ToString("MM"));
        anoA = Convert.ToInt32(DateTime.Now.ToString("yyyy"));

        nomeExp.text = ParametrosStatic.nomeExp;
        nomeSuj.text = ParametrosStatic.nomeSuj;
        idade.text = dataaux;

        ParametrosStatic.chancesTreino = 0;
}

    private void Update()
    {
        
    }

    public void Treino()
    {
        SceneManager.LoadScene("TreinoResgate");
    }

    public void OnSubmit()
    {
        // Trecho de código para cálculo dos meses.
        if (idade.text.Length == 10)
        {
            data = idade.text.ToCharArray();
            if (data[2] == '/' || data[5] == '/')
            {
                diaN = (Convert.ToInt32(data[0].ToString()) * 10) + Convert.ToInt32(data[1].ToString());
                mesN = (Convert.ToInt32(data[3].ToString()) * 10) + Convert.ToInt32(data[4].ToString());
                anoN = (Convert.ToInt32(data[6].ToString()) * 1000) + (Convert.ToInt32(data[7].ToString()) * 100) + (Convert.ToInt32(data[8].ToString()) * 10) + Convert.ToInt32(data[9].ToString());
                if (anoN <= anoA)
                {
                    meses = ((anoA - anoN) * 12) + (mesA - mesN);

                    if (diaN > diaA)
                    {
                        meses--;
                        dias = diaA;
                    }
                    else
                    {
                        dias = diaA - diaN;
                    }
                    //texto.text = meses + " meses.";
                    dataValida = true;
                }
            }
            else
            {
                texto.text = "Formato de data invalida! Digite: dd/mm/aaaa";
                dataValida = false;
            }

            if (diaN > 31 || diaN < 1 || mesN > 12 || mesN < 1 || anoN > 2019 || anoN < 1900)
            {
                texto.text = "Data Invalida!";
                dataValida = false;
            }
        }
        else
        {
            texto.text = "Formato de tamanho de data invalida! Digite: dd/mm/aaaa";
            dataValida = false;
        }

        if (nomeExp.text != "" && nomeSuj.text != "" && idade.text != "" && dataValida && nroTentativas.text != "" && (masculino.isOn || feminino.isOn))
        {

            ParametrosStatic.nomeExp = nomeExp.text; // Os dados que serão usados estarão sendo coletados pelas informações fornecidas pelo usuário.
            ParametrosStatic.nomeSuj = nomeSuj.text;
            ParametrosStatic.idade = meses;
            ParametrosStatic.nroTentativas = int.Parse(nroTentativas.text);
            ParametrosStatic.chances = int.Parse(nroTentativas.text);
            ParametrosStatic.acertos = 0;
            ParametrosStatic.erros = 0;
            ParametrosStatic.tentativa = 0;
            ParametrosStatic.sexo = masculino.isOn ? "Masculino" : "Feminino"; ;
            mDireita = maoDireita.isOn ? true : false;
            ParametrosStatic.dominio = mDireita ? "Mao Direita" : "Mao Esquerda";
            if (ladoDir.isOn) ladoObst = 1;
            if (ladoEsq.isOn) ladoObst = 2;
            ParametrosStatic.obstaculo = "Pseudoaleatorio";
            if (ladoDir.isOn) ParametrosStatic.obstaculo = "Lado Direito";
            if (ladoEsq.isOn) ParametrosStatic.obstaculo = "Lado Esquerdo";
            if (treinoSim.isOn) ParametrosStatic.chancesTreino = 3;

            dataaux = idade.text;

            for (int i = 0; i < 3; i++) // For para gravar dados
            {
                Debug.Log("Entrando no for...");
                if (PlayerPrefs.HasKey("Exp" + i) == false) // Caso haja algum slot vazio, grava.
                {
                    ParametrosStatic.indice = i; // Indice vazio para referencia de dados detalhados de desempenho.
                    dispensar = true; // Controle para Sair do for e ir pra cena seguinte.
                    break; // Break do for.
                }
            }
            if (dispensar == false) ParametrosStatic.indice = 2; // Caso todos os slots estejam cheios, o índice será 2 (o que será utilizado posteriormente após a substituição).

            SceneManager.LoadScene("ConfirmaConfig");
        }
    }
}
