using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoLimpaHist : MonoBehaviour
{
    public void OnSubmit()
    {
        for(int i = 0; i < 3; i++) // For para limpar todo o histórico.
        {
            PlayerPrefs.DeleteKey("Exp" + i);
            PlayerPrefs.DeleteKey("Suj" + i);
            PlayerPrefs.DeleteKey("Idade" + i);
            PlayerPrefs.DeleteKey("Chances" + i);
            PlayerPrefs.DeleteKey("Acertos" + i);
            PlayerPrefs.DeleteKey("Erros" + i);
            PlayerPrefs.DeleteKey("Hora" + i);

            for (int j = 0; j < PlayerPrefs.GetInt("Chances" + i); j++)
            {
                PlayerPrefs.DeleteKey("Suj" + i + "Tj" + j);
                PlayerPrefs.DeleteKey("Suj" + i + "Tm" + j);
            }
        }
        SceneManager.LoadScene("Historico"); // Após limpeza, recarrega a mesma cena.
    }
}
