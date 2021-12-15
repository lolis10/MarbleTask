using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Windows.Kinect;
using AudioSource = UnityEngine.AudioSource;
using System;

public class Bola : MonoBehaviour
{
    public Windows.Kinect.JointType _jointType;
    public Windows.Kinect.JointType _jointTypeE;
    public GameObject _bodySourceManager;
    private BodySourceManager _bodyManager;
    public GameObject Aberta;
    public GameObject Fechada;
    public float TempoComBola = 0.0f;
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
    public string dominiomao = "Mao esquerda";
    public string criterioobst = "Pseudoaleatorio";
    public float temporeacao = 0.0f;
    public bool contareacao = true;
    public float tempoobservado = 0.0f;

    void Start()
    {
        if (Parametros.mDireita) // Verifica se a mão direita foi setada, caso contrário o jogador irá utilizar a mão esquerda
        {
            dominiomao = "Mao direita";
        }
        // Verifica se foi definido algum critério para lado do obstáculo.
        if (Parametros.ladoObst == 1) criterioobst = "Lado Direito";
        if (Parametros.ladoObst == 2) criterioobst = "Lado Esquerdo";

        if (!obst1.gameObject.activeSelf) // Verifica em que lado o obstáculo se encontra e guarda as informações em variáveis.
        {
            ladoUrso = "Esquerdo";
            ladoObst = "Direito";
        }
        else
        {
            ladoUrso = "Direito";
            ladoObst = "Esquerdo";
        }
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime; // Contando o tempo da atividade.

        if (pegouBola) contareacao = false;
        if (contareacao) temporeacao += Time.deltaTime; // Contagem do tempo de reação
        if (!contareacao) tempoobservado += Time.deltaTime; // Contagem do tempo observado a partir da reação

        if (timer > 120) // Tempo para realização da atividade
        {
            ParametrosStatic.nroTentativas--; // Decremento do número de tentativas caso acerte no obstáculo.
            Gravar.addRecord(ParametrosStatic.nomeExp, ParametrosStatic.nomeSuj, ParametrosStatic.idade.ToString(), (ParametrosStatic.chances - ParametrosStatic.nroTentativas).ToString()/* + " de " + ParametrosStatic.chances*/, ParametrosStatic.acertos.ToString(), ParametrosStatic.erros.ToString(), dominiomao, criterioobst, ladoUrso, "Tempo Esgotado", System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ParametrosStatic.sexo, temporeacao.ToString(), tempoobservado.ToString(), tempo.ToString(), TempoComBola.ToString(), ParametrosStatic.nomeSuj + ".csv");
            SceneManager.LoadScene("GanhouResgate");
        }
        // Abertura da animação das paredes
        if (paredeD.transform.position.x < 15.0 + 20) paredeD.transform.Translate(Vector3.right * Time.deltaTime * velocidadeParede);
        if (paredeE.transform.position.x > -25.47 - 20) paredeE.transform.Translate(Vector3.left * Time.deltaTime * velocidadeParede);
        // Área definida para que a bola não sofra interferência no eixo X.
        if (this.gameObject.transform.position.x < -10.86 || this.gameObject.transform.position.x > 0 || this.gameObject.transform.position.y > 7.30 || this.gameObject.transform.position.y < -0.80)
        {
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

        tempo += Time.deltaTime; // Tempo para realizar a tarefa.
        if (pegouBola) TempoComBola += Time.deltaTime; // tempo com a bola na mão.

        TempoAux = int.Parse(DateTime.Now.ToString("ss")); // tempo para alternar o alerta.

        if (!iniciar)
        {
            if(TempoAux % 2 == 0) // realiza a ação de piscar no alerta.
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
                var pos = body.Joints[_jointTypeE].Position;

                if (Parametros.mDireita) pos = body.Joints[_jointType].Position;

                if (this.gameObject.transform.position.x < -16.5) this.gameObject.transform.position = new Vector3(-16.5f, pos.Y * 40, pos.Z * 0);
                if (this.gameObject.transform.position.x > 7) this.gameObject.transform.position = new Vector3(7f, pos.Y * 40, pos.Z * 0);
                if (this.gameObject.transform.position.y < -5.5) this.gameObject.transform.position = new Vector3(pos.X * 40, -5.5f, pos.Z * 0);
                if (this.gameObject.transform.position.y > 11.8) this.gameObject.transform.position = new Vector3(pos.X * 40, 11.8f, pos.Z * 0);

                if(Parametros.mDireita) // Caso a mão direita seja escolhida
                {
                    switch (body.HandRightState)
                    {
                        case HandState.Closed: // Caso a mão esteja fechada e haja colisão com a bola, ambas farão o mesmo movimento.
                            if (colidiu == "mao") // Colisão da bola com a mão fechada.
                            {
                                iniciar = true; // Variável que inicia dependências a partir da bola na mão.
                                this.gameObject.transform.position = new Vector3(pos.X * 40, pos.Y * 40, pos.Z * 0); // Realiza o acompanhamento da bola juntamente com a mão.
                                pegouBola = true; // Variável que inicia dependências a partir da bola na mão.
                            }
                            break;
                        case HandState.Open:
                            colidiu = "nao"; // Não colisão da bola com a mão fechada.
                            pegouBola = false;
                            break;
                    }
                }
                else // Caso a mão esquerda seja escolhida
                {
                    Aberta.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    Fechada.gameObject.GetComponent<SpriteRenderer>().flipX = true;
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
        if (collision.gameObject.tag == "Marble") // Verificação para colisão da bola com o castelo.
        {
            colidiu = "castelo";
        }
        if (collision.gameObject.tag == "Urso") // Verificação de colisão da bola com o urso.
        {
            salvou = true;
            ParametrosStatic.nroTentativas--; // Decremento do número de tentativas caso acerte no urso.
            ParametrosStatic.acertos++; // Incremento do número de acertos.
            PlayerPrefs.SetFloat("Suj" + ParametrosStatic.indice + "Tm" + ParametrosStatic.tentativa, TempoComBola);
            PlayerPrefs.SetFloat("Suj" + ParametrosStatic.indice + "Tj" + ParametrosStatic.tentativa++, tempo);

            Gravar.addRecord(ParametrosStatic.nomeExp, ParametrosStatic.nomeSuj, ParametrosStatic.idade.ToString(), (ParametrosStatic.chances - ParametrosStatic.nroTentativas).ToString()/* + " de " + ParametrosStatic.chances*/, ParametrosStatic.acertos.ToString(), ParametrosStatic.erros.ToString(), dominiomao, criterioobst, ladoUrso, ladoUrso, System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ParametrosStatic.sexo, temporeacao.ToString(), tempoobservado.ToString(), tempo.ToString(), TempoComBola.ToString(), ParametrosStatic.nomeSuj + ".csv");

            SceneManager.LoadScene("GanhouResgate");
        }
        if (collision.gameObject.tag == "Obst")
        {
            salvou = false;

            ParametrosStatic.nroTentativas--; // Decremento do número de tentativas caso acerte no obstáculo.
            ParametrosStatic.erros++; // Incremento do número de erros.
            PlayerPrefs.SetFloat("Suj" + ParametrosStatic.indice + "Tm" + ParametrosStatic.tentativa, TempoComBola);
            PlayerPrefs.SetFloat("Suj" + ParametrosStatic.indice + "Tj" + ParametrosStatic.tentativa++, tempo);

            Gravar.addRecord(ParametrosStatic.nomeExp, ParametrosStatic.nomeSuj, ParametrosStatic.idade.ToString(), (ParametrosStatic.chances - ParametrosStatic.nroTentativas).ToString()/* + " de " + ParametrosStatic.chances*/, ParametrosStatic.acertos.ToString(), ParametrosStatic.erros.ToString(), dominiomao, criterioobst, ladoUrso, ladoObst, System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ParametrosStatic.sexo, temporeacao.ToString(), tempoobservado.ToString(), tempo.ToString(), TempoComBola.ToString(), ParametrosStatic.nomeSuj + ".csv");

            SceneManager.LoadScene("GanhouResgate"); 
        }
    }
}
