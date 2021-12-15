using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Windows.Kinect;
using AudioSource = UnityEngine.AudioSource;

public class TrocaObstaculo : MonoBehaviour
{
    private int flag;
    public GameObject obst1;
    public GameObject obst2;
    public GameObject Bola1;
    public GameObject Urso;
    public Text nomeSuj;
    public Text nroTentativas;
    public float aux = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = Bola1.transform.position;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        Urso.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        
        if(Parametros.ladoObst == 1)
        {
            flag = 1;
            obst1.SetActive(true);
            obst2.SetActive(false);
            obst1.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(Parametros.ladoObst == 2)
        {
            flag = 2;
            obst1.SetActive(false);
            obst2.SetActive(true);
            obst2.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            if (Random.Range(1, 3) == 2)
            { 
                // Troca obstáculo de forma randômica.
                flag = 1;
                obst1.SetActive(true);
                obst2.SetActive(false);
                obst1.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                flag = 2;
                obst1.SetActive(false);
                obst2.SetActive(true);
                obst2.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Gerencia os objetos que ficarão ativos e inativos quando a mão estiver em frente a Marble Task.
        if (Bola.pegouBola == false && Bola1.transform.position.y > 6.78)
        {
            if (Bola1.transform.position.x > -7.72 && Bola1.transform.position.x < -2.87)
            {
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                Urso.GetComponent<PolygonCollider2D>().enabled = false;
                if (flag == 1) obst1.GetComponent<BoxCollider2D>().enabled = false;
                if (flag == 2) obst2.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<PolygonCollider2D>().enabled = true;
                Urso.GetComponent<PolygonCollider2D>().enabled = true;
                if (flag == 1) obst1.GetComponent<BoxCollider2D>().enabled = true;
                if (flag == 2) obst2.GetComponent<BoxCollider2D>().enabled = true;
            }            
        }
        if((Bola.pegouBola == true && Bola1.transform.position.y < 6.78))
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            Urso.GetComponent<PolygonCollider2D>().enabled = false;
            if (flag == 1) obst1.GetComponent<BoxCollider2D>().enabled = false;
            if (flag == 2) obst2.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
