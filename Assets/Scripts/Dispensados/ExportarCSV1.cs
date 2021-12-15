using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


class ExportarCSV1 : MonoBehaviour
{

    public void OnSubmit()
    {
        addRecord(PlayerPrefs.GetString("Exp1"), PlayerPrefs.GetString("Suj1"), PlayerPrefs.GetInt("Idade1").ToString(), PlayerPrefs.GetInt("Chances1").ToString(), PlayerPrefs.GetInt("Acertos1").ToString(), PlayerPrefs.GetInt("Erros1").ToString(), PlayerPrefs.GetString("Hora1"), PlayerPrefs.GetString("Sexo1"), PlayerPrefs.GetString("Suj1") + ".csv");
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

                file.WriteLine();

                for (int i = 0; i < PlayerPrefs.GetInt("Chances1"); i++)
                {
                    file.WriteLine("Tempo da tentativa " + (i + 1) + ";" + PlayerPrefs.GetFloat("Suj1Tj" + i).ToString());
                }
                file.WriteLine();

                for (int i = 0; i < PlayerPrefs.GetInt("Chances1"); i++)
                {
                    file.WriteLine("Bola na mão da tentativa " + (i + 1) + ";" + PlayerPrefs.GetFloat("Suj1Tm" + i).ToString());
                }
                file.WriteLine();
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
