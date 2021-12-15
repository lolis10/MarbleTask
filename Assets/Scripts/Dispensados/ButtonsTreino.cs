 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsTreino : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Voltar()
    {
        SceneManager.LoadScene("Configuracoes");
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("TreinoResgate");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
