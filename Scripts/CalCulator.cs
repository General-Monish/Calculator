using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalCulator : MonoBehaviour
{
   public TextMeshProUGUI InputText, OutputText;
    public string inputString, outputString, SelectedOperator;
    private bool decilmalHasAssign;
    // Start is called before the first frame update
    void Start()
    {
        InputText.text = "";
        OutputText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddInput(string input)
    {
        inputString += input;
        UpdateUI();
    }
    public void UpdateUI()
    {
        InputText.text = inputString;
        OutputText.text = outputString;
    }

    public void AddOperator(string operatorrr)
    {
        if (SelectedOperator == "")
        {
            inputString += operatorrr;
            SelectedOperator = operatorrr;
            decilmalHasAssign = false;
        }

        UpdateUI();
    }

    public void AddDecimal()
    {
        if (!decilmalHasAssign)
        {
            inputString += ".";
            decilmalHasAssign = true;
        }
       
        UpdateUI();
    }

  public void EarasecChar()
    {
        string CharToEarse = inputString[inputString.Length - 1].ToString();

        if (CharToEarse== SelectedOperator)
        {
            SelectedOperator = "";
        }

        if (CharToEarse == ".")
        {
            decilmalHasAssign = false;
        }

        inputString = inputString.Substring(0,inputString.Length - 1);
        UpdateUI();
       
    }
    public void Clear()
    {
        inputString = "";
        UpdateUI();
    }
   
}
