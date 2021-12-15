using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHistorico : MonoBehaviour
{
    public void OnSubmit() // Salto para a cena Historico.
    {
        SceneManager.LoadScene("Historico");
    }
}
