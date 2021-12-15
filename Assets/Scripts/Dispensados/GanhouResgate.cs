using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GanhouResgate : MonoBehaviour
{
    //float tempo;
    //public GameObject urso;
    //public Text uitempo;
    float sleep;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //tempo = urso.GetComponent<UrsoColisao>().tempo;
        //uitempo.text = "Tempo gasto: " + tempo;
        sleep += Time.deltaTime;
        if (sleep >= 3.0f) UnityEngine.SceneManagement.SceneManager.LoadScene("Configuracoes");
    }
}
