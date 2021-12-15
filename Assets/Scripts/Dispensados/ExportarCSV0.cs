using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


class ExportarCSV0 : MonoBehaviour
{
    public Text Exportado;

    public void OnSubmit()
    {
        addRecord(PlayerPrefs.GetString("Exp0"), PlayerPrefs.GetString("Suj0"), PlayerPrefs.GetInt("Idade0").ToString(), PlayerPrefs.GetInt("Chances0").ToString(), PlayerPrefs.GetInt("Acertos0").ToString(), PlayerPrefs.GetInt("Erros0").ToString(), PlayerPrefs.GetString("Hora0"), PlayerPrefs.GetString("Sexo0"), PlayerPrefs.GetString("Suj0") + ".csv");
//        Exportado.text = "Exportado com sucesso!";
    }

    void addRecord(string Exp, string Suj, string Idade, string Chances, string Acertos, string Erros, string Hora, string Sexo, string filepath)
    {
        try
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
            {
                file.WriteLine("Experimentador" + ";" + "Sujeito" + ";" + "Idade" + ";" + "Chances" + ";" + "Acertos" + ";" + "Erros" + ";" + "Hora" + ";" + "Sexo");
                file.WriteLine(Exp + ";" + Suj + ";" + Idade + ";" + Chances + ";" + Acertos + ";" + Erros + ";" + Hora + ";" + Sexo);
                
                //file.WriteLine();

                for (int i = 0; i < PlayerPrefs.GetInt("Chances0"); i++)
                {
                    file.WriteLine("Tempo da tentativa " + (i + 1) + ";" + PlayerPrefs.GetFloat("Suj0Tj" + i).ToString());
                }
                //file.WriteLine();

                for (int i = 0; i < PlayerPrefs.GetInt("Chances0"); i++)
                {
                    file.WriteLine("Bola na mão da tentativa " + (i + 1) + ";" + PlayerPrefs.GetFloat("Suj0Tm" + i).ToString());
                }
                //file.WriteLine();
            }
        }
        catch(Exception ex)
        {
            throw new ApplicationException("Erro ao realizar procedimento :", ex);
        }
    }
}
