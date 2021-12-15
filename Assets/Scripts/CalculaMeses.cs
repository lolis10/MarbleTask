using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculaMeses : MonoBehaviour
{
    public InputField nasc;
    public Text texto;
    int diaA;
    int mesA;
    int anoA;
    int diaN;
    int mesN;
    int anoN;
    char[] aux = new char[10];
    char[] data = new char[10];
    int meses;
    int dias;

    // Start is called before the first frame update
    void Start()
    {
        diaA = Convert.ToInt32(DateTime.Now.ToString("dd"));
        mesA = Convert.ToInt32(DateTime.Now.ToString("MM"));
        anoA = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
    }

    // Update is called once per frame
    void Update() // Função para calculo de meses a partir da data de nascimento.
    {
        if (nasc.text.Length == 10)
        {
            data = nasc.text.ToCharArray();
            if (data[2] == '/' || data[5] == '/')
            {
                diaN = (Convert.ToInt32(data[0].ToString()) * 10) + Convert.ToInt32(data[1].ToString());
                mesN = (Convert.ToInt32(data[3].ToString()) * 10) + Convert.ToInt32(data[4].ToString());
                anoN = (Convert.ToInt32(data[6].ToString()) * 1000) + (Convert.ToInt32(data[7].ToString()) * 100) + (Convert.ToInt32(data[8].ToString()) * 10) + Convert.ToInt32(data[9].ToString());
                if (anoN <= anoA)
                {
                    meses = ((anoA - anoN) * 12) + (mesA - mesN);

                    if (diaN > diaA)
                    {
                        meses--;
                        dias = diaA;
                    }
                    else
                    {

                        dias = diaA - diaN;
                    }
                    texto.text = meses + " meses.";
                }
            }
            else
            {
                texto.text = "Formato de data invalida! Digite: dd/mm/aaaa";
            }

            if (diaN > 31 || diaN < 1 || mesN > 12 || mesN < 1 || anoN > 2019 || anoN < 1900)
            {
                texto.text = "Data Invalida!";
            }
        }
        else
        {
            texto.text = "Formato de tamanho de data invalida! Digite: dd/mm/aaaa";
        }
    }
}