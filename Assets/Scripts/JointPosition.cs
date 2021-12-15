using UnityEngine;
using System.Collections;
using Windows.Kinect;
using AudioSource = UnityEngine.AudioSource;
using System;

public class JointPosition : MonoBehaviour 
{
    public Windows.Kinect.JointType _jointType;
    public Windows.Kinect.JointType _jointTypeE;
    public GameObject _bodySourceManager;
    public string Estado;
    private BodySourceManager _bodyManager;
    public GameObject Aberta;
    public GameObject Fechada;
	public GameObject somPegando;
	public GameObject somSoltando;
    public GameObject mao;
    public GameObject Grab;
    public string pegou;

    private float tempo = 0;
    private double Distancia = 0;
    private double Aceleracao = 0;
    private double DistanciaAnt = 0;
    private float oldx = 0;
    private float oldy = 0;
    private float oldTempo = 0;
    private float newTempo = 0;
    private int primeiraVelocidade = 1;
    private double Velocidade;
    private double VelocidadeAnt;
    private double x;
    private double y;
    private bool repouso;

    private float txAmostragem = 0.25f;

    void Start () 
    {
        Aberta.SetActive(false); // Inicia as imagens de mão aberta e fechada.
        Fechada.SetActive(false);
        addRecord("Coordenada X", "Coordenada Y", "Distancia (cm)", "Velocidade (cm/s)", "Aceleracao(cm/s²)", ParametrosStatic.nomeSuj + "Mov.csv");
    }
	
	// Update is called once per frame
	void Update () 
    {   // Trecho de código disponibilizado pelo pacote Unity para Kinect com o intuito de rastrear o corpo.
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

        // Obtém o primeiro corpo rastreável.
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

                this.gameObject.transform.position = new Vector3(pos.X * 40, pos.Y * 40, pos.Z * 0);

                tempo += Time.deltaTime; // Controle de tempo para cada atualização das coordenadas X e Y.

                if (tempo > txAmostragem && Bola.pegouBola)
                {
                    x = transform.position.x / 40; // Divide as posições por 40, uma vez que foi alterada anteriormente.
                    y = transform.position.y / 40;
                    // Cálculo da distância
                    Distancia += Math.Round(Math.Sqrt(Math.Pow(x - oldx, 2) + Math.Pow(y - oldy, 2)), 2);

                    if (primeiraVelocidade == 2)
                    {
                        primeiraVelocidade = 0;
                        Velocidade = ((Distancia - DistanciaAnt) / txAmostragem);
                        Aceleracao = 0; // Zera a segunda aceleração por não possuir dados de distância suficiente para cálculo.
                    }
                    else
                    {
                        Velocidade = ((Distancia - DistanciaAnt) / txAmostragem); // Cálculo da velocidade.
                        Aceleracao = (Velocidade - VelocidadeAnt) / txAmostragem; // Cálculo da aceleração.
                    }
                    if (primeiraVelocidade == 1)
                    {
                        primeiraVelocidade = 2;
                        Velocidade = 0; // Na primeira execução, a primeira linha de velocidade, distancia e aceleração serão setadas em zero.
                        Distancia = 0;
                        Aceleracao = 0;
                    }

                    VelocidadeAnt = Velocidade;
                    DistanciaAnt = Distancia;

                    addRecord(x.ToString("F2"), y.ToString("F2"), Distancia.ToString("F2"), Velocidade.ToString("F2"), Aceleracao.ToString("F2"), ParametrosStatic.nomeSuj + "Mov.csv");
                    Debug.Log(transform.position.x);
                    oldx = transform.position.x;
                    oldy = transform.position.y;

                    tempo = 0;
                }

                if (gameObject.transform.position.x < -16.5) this.gameObject.transform.position = new Vector3(-16.5f, pos.Y * 40, pos.Z * 0);
                if (gameObject.transform.position.x > 7) this.gameObject.transform.position = new Vector3(7f, pos.Y * 40, pos.Z * 0);
                if (gameObject.transform.position.y < -5.5) this.gameObject.transform.position = new Vector3(pos.X * 40, -5.5f, pos.Z * 0);
                if (gameObject.transform.position.y > 11.8) this.gameObject.transform.position = new Vector3(pos.X * 40, 11.8f, pos.Z * 0);

                if (Grab.gameObject.GetComponent<Rigidbody2D>().velocity == new Vector2(0.0f, 0.0f))
                {
                    repouso = true; // Caso a bola esteja parada, a mão estará ativa
                }
                else
                {
                    repouso = false;
                }

                if (Parametros.mDireita)
                {
                    switch (body.HandRightState)
                    {
                        case HandState.Open:
                            Estado = "ABERTA";

                            if (repouso == true)
                            {
                                Aberta.SetActive(true);
                                Fechada.SetActive(false);
                            }
                            else
                            {
                                Aberta.SetActive(false);
                                Fechada.SetActive(false);
                            }
                            break;

                        case HandState.Closed:
                            Estado = "FECHADA";
                            Aberta.SetActive(false);
                            if (repouso) Fechada.SetActive(true);
                            break;
                    }
                    break;
                }
                else
                {
                    switch (body.HandLeftState)
                    {
                        case HandState.Open:
                            Estado = "ABERTA";

                            if (repouso == true)
                            {
                                Aberta.SetActive(true);
                                Fechada.SetActive(false);
                            }
                            else
                            {
                                Aberta.SetActive(false);
                                Fechada.SetActive(false);
                            }
                            break;

                        case HandState.Closed:
                            Estado = "FECHADA";
                            Aberta.SetActive(false);
                            if (repouso) Fechada.SetActive(true);
                            break;
                    }
                    break;
                }
                
            }
        }
	}
    void addRecord(string PosX, string PosY, string Dist, string Vel, string Acel, string filepath)
    {
        try
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
            {
                file.WriteLine(PosX + ";" + PosY + ";" + Dist + ";" + Vel + ";" + Acel);
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao realizar procedimento :", ex);
        }
    }
}
