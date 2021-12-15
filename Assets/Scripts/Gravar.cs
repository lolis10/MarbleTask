using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine.UI;

public class Gravar : MonoBehaviour
{
    // Função para adicionar informações no CSV.
    public static void addRecord(string Exp, string Suj, string Idade, string Chances, string Acertos, string Erros, string Dominio, string LadoObst, string Esperado, string Obtido, string Hora, string Sexo, string TempoReacao, string TempoObs, string Tempo, string TempoBola, string filepath)
    {
        try
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
            {
                file.WriteLine(Exp + ";" + Suj + ";" + Idade + ";" + Chances + ";" + Acertos + ";" + Erros + ";" + Dominio + ";" + LadoObst + ";" + Esperado + ";" + Obtido + ";" + Hora + ";" + Sexo + ";" + TempoReacao + ";" + TempoObs + ";" + Tempo + ";" + TempoBola);
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao realizar procedimento :", ex);
        }
    }
// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
