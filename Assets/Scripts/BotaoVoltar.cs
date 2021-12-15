using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoVoltar : MonoBehaviour
{
    public void OnSubmit() // Volta para cena Configurações
    {
        SceneManager.LoadScene("Configuracoes");
    }
}
