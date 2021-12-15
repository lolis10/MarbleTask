using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Historico : MonoBehaviour
{
    public Text[] exp;
    public Text[] suj;
    public Text[] idade;
    public Text[] chances;
    public Text[] acertos;
    public Text[] erros;
    public Text[] hora;
    public Text[] ttotal;
    private float tempo;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++) // Realiza a busca dos três últimos registros de jogadas.
        {
            tempo = 0;

            exp[i].text = PlayerPrefs.GetString("Exp" + i); // Para cada campo de Text, carrega os registros correspondentes.
            suj[i].text = PlayerPrefs.GetString("Suj" + i);
            idade[i].text = PlayerPrefs.GetInt("Idade" + i).ToString();
            chances[i].text = PlayerPrefs.GetInt("Chances" + i).ToString();
            acertos[i].text = PlayerPrefs.GetInt("Acertos" + i).ToString();
            erros[i].text = PlayerPrefs.GetInt("Erros" + i).ToString();
            hora[i].text = PlayerPrefs.GetString("Hora" + i);

            for (int j = 0; j < PlayerPrefs.GetInt("Chances" + i); j++) tempo += PlayerPrefs.GetFloat("Suj" + i + "Tj" + j);
            ttotal[i].text = tempo.ToString();

        }
    }
}
