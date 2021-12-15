using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Windows.Kinect;
using AudioSource = UnityEngine.AudioSource;
using System;

public class TreinoBola : MonoBehaviour
{
    public Windows.Kinect.JointType _jointType;
    public Windows.Kinect.JointType _jointTypeE;
    public GameObject _bodySourceManager;
    private BodySourceManager _bodyManager;
    public GameObject Aberta;
    public GameObject Fechada;
    //public GameObject FechadaBola;
    //public GameObject cortina;
    //public Image black;
    public float TempoComBola = 0.0f;
    //public Animator anim;
    public bool descecortina = false;
    private bool pegou;
    float sleep;
    public float tempo = 0.0f;
    public static bool pegouBola = false;
    public string colidiu;
    public GameObject obst1;
    private string ladoUrso = "null";
    private string ladoObst = "null";
    public bool iniciar = false;
    public GameObject alerta;
    public float TempoAux = 1.0f;
    public GameObject paredeE;
    public GameObject paredeD;
    public float velocidadeParede = 10;
    public static bool salvou;
    public float timer = 0.0f;
    public GameObject copo;
    public GameObject copoFeliz;
    public Text parabens;
    public bool ganhou = false;

    void Start()
    {
        _jointType = JointType.HandRight;
        _jointTypeE = JointType.HandLeft;
        Parametros.mDireita = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (pegouBola == false && transform.position.y > 3.5)
        {
            if (transform.position.x > 2.7 && transform.position.x < 7.7)
            {
                copo.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            }
            else
            {
                copo.gameObject.GetComponent<PolygonCollider2D>().enabled = true; 
            }
        }
        if ((pegouBola == true && transform.position.y < 3.5))
        {
            copo.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }

        /*if (ganhou)
        {
            Vector3 a = new Vector3(5.1f, 0.8f, 0.0f);
            Quaternion b = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            timer += Time.deltaTime;
            gameObject.transform.position = a;
            gameObject.transform.rotation = b;
        }*/
            

        if (timer > 2.0)
        {
            ParametrosStatic.chancesTreino--;
            if (ParametrosStatic.chancesTreino <= 0)
            {
                SceneManager.LoadScene("CenaResgate");
            }
            else
            {
                SceneManager.LoadScene("TreinoResgate");
            }
        }

        if (gameObject.transform.position.y < -4.5){
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

        if (iniciar) tempo += Time.deltaTime; // Tempo para realizar a tarefa
        if (pegouBola) TempoComBola += Time.deltaTime; // tempo com a bola na mão

        TempoAux = int.Parse(DateTime.Now.ToString("ss")); // tempo para alternar o alerta

        if (!iniciar)
        {
            if (TempoAux % 2 == 0)
            {
                alerta.SetActive(true);
            }
            else
            {
                alerta.SetActive(false);
            }
        }
        else
        {
            alerta.SetActive(false);
        }

        if (_bodySourceManager == null)
        {
            return;
        }

        _bodyManager = _bodySourceManager.GetComponent<BodySourceManager>();
        if (_bodyManager == null)
        {
            return;
        }

        Body[] data = _bodyManager.GetData();
        if (data == null)
        {
            return;
        }

        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                var pos = body.Joints[_jointType].Position;

                if (Parametros.mDireita)
                {
                    switch (body.HandRightState)
                    {
                        case HandState.Closed: // Caso a mão esteja fechada e haja colisão com a bola, ambas farão o mesmo movimento.
                            if (colidiu == "mao")
                            {
                                iniciar = true;
                                this.gameObject.transform.position = new Vector3(pos.X * 40, pos.Y * 40, pos.Z * 0);
                                pegouBola = true;
                            }
                            break;
                        case HandState.Open:
                            colidiu = "nao";
                            pegouBola = false;
                            break;
                    }
                }
                else
                {
                    switch (body.HandLeftState)
                    {
                        case HandState.Closed: // Caso a mão esteja fechada e haja colisão com a bola, ambas farão o mesmo movimento.
                            if (colidiu == "mao")
                            {
                                iniciar = true;
                                this.gameObject.transform.position = new Vector3(pos.X * 40, pos.Y * 40, pos.Z * 0);
                                pegouBola = true;
                            }
                            break;
                        case HandState.Open:
                            colidiu = "nao";
                            pegouBola = false;
                            break;
                    }
                }
                break;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MaoFechada") // Verificação da colisão da bola com a mão fechada.
        {
            colidiu = "mao";
        }
        if (collision.gameObject.tag == "copo") // Verificação da colisão da bola com a mão fechada.
        {
            copo.SetActive(false);
            copoFeliz.SetActive(true);
            alerta.SetActive(false);
            ganhou = true;
        }
    }
}
