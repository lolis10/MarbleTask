/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine.UI;

public class DistanciaMao : MonoBehaviour
{
    //public float distancia=0;
    private float tempo = 0;
    public double Distancia = 0;
    public float oldx = 0;
    public float oldy = 0;
    public float oldTempo = 0;
    public float newTempo = 0;
    public int primeiraVelocidade = 1;
    public double velocidade;


    void Start()
    {
        addRecord("Coordenada X", "Coordenada Y", "Distancia", "Velocidade (cm/s)", ParametrosStatic.nomeSuj + "Movimento.csv");
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        newTempo += Time.deltaTime;

        if (tempo > 0.25f && Bola.pegouBola)
        {
            Distancia += Math.Round(Math.Sqrt(Math.Pow(transform.position.x - oldx, 2) + Math.Pow(transform.position.y - oldy, 2)), 2);

            if (primeiraVelocidade == 1)
            {
                primeiraVelocidade = 0;
                velocidade = 0;
            }
            else
            {
                velocidade = Distancia / (newTempo - oldTempo);
            }

            addRecord(transform.position.x.ToString("F2"), transform.position.y.ToString("F2"), Distancia.ToString("F2"), velocidade.ToString("F2"), ParametrosStatic.nomeSuj + "Movimento.csv");
            Debug.Log(transform.position.x);
            oldx = transform.position.x;
            oldy = transform.position.y;

            oldTempo = newTempo;
            tempo = 0;
        }
        //Debug.Log(tempo);
    }

    void addRecord(string PosX, string PosY, string Dist, string Vel, string filepath)
    {
        try
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
            {
                file.WriteLine(PosX + ";" + PosY + ";" + Dist + ";" + Vel);
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao realizar procedimento :", ex);
        }
    }

}*/
