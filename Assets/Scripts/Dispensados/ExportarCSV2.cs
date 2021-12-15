using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


class ExportarCSV2 : MonoBehaviour
{
    //public Text Exportado;
    private string temposTentativas = "";
    private string temposBolaMao = "";
    private string resTemposTentativas = "";
    private string resTemposBolaMao = "";

    public void OnSubmit()
    {
        addRecord(PlayerPrefs.GetString("Exp2"), PlayerPrefs.GetString("Suj2"), PlayerPrefs.GetInt("Idade2").ToString(), PlayerPrefs.GetInt("Chances2").ToString(), PlayerPrefs.GetInt("Acertos2").ToString(), PlayerPrefs.GetInt("Erros2").ToString(), PlayerPrefs.GetString("Hora2"), PlayerPrefs.GetString("Sexo2"), PlayerPrefs.GetString("Suj2") + DateTime.Now.ToString("ddMMyyhhmmss") + ".csv");
//        Exportado.text = "Exportado com sucesso!";
    }

    void addRecord(string Exp, string Suj, string Idade, string Chances, string Acertos, string Erros, string Hora, string Sexo, string filepath)
    {
        try
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
            {
                
                for (int i = 0; i < PlayerPrefs.GetInt("Chances2"); i++)
                {
                    temposTentativas += ";Tempo da tentativa " + (i + 1);
                    temposBolaMao += ";Bola na mao da tentativa " + (i + 1);
                    resTemposTentativas += ";" + PlayerPrefs.GetFloat("Suj2Tj" + i).ToString();
                    resTemposBolaMao += ";" + PlayerPrefs.GetFloat("Suj2Tj" + i).ToString();

                }

                file.WriteLine("Experimentador" + ";" + "Sujeito" + ";" + "Meses" + ";" + "Chances" + ";" + "Acertos" + ";" + "Erros" + ";" + "Hora" + ";" + "Sexo" + temposTentativas + temposBolaMao);
                //file.Write(temposTentativas);
                //file.WriteLine(temposBolaMao);

                /*for (int i = 0; i < PlayerPrefs.GetInt("Chances2"); i++)
                {
                    
                    //file.WriteLine("Bola na mão da tentativa " + (i + 1) + ";" + PlayerPrefs.GetFloat("Suj2Tm" + i).ToString());
                }*/

                file.WriteLine(Exp + ";" + Suj + ";" + Idade + ";" + Chances + ";" + Acertos + ";" + Erros + ";" + Hora + ";" + Sexo + resTemposTentativas + resTemposBolaMao);

                file.Close();
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao realizar procedimento :", ex);
        }
    }
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

}
