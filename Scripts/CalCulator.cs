using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalCulator : MonoBehaviour
{
   public TextMeshProUGUI InputText, OutputText;
    public string inputString, outputString, SelectedOperator;
    private bool decilmalHasAssign;
    public GameObject Red;
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

    public void AddNegative()
    {
        if (SelectedOperator == "")
        {
            if (SelectedOperator == "-")
            {
                inputString = inputString.Substring(1, inputString.Length - 1);
            }
            else
            {
                inputString =  '-' + inputString ;
            }
        }
        else
        {
            char oprtr = char.Parse(SelectedOperator);
            string[] inputValueArray = inputString.Split(oprtr);


            string firstInput="";
            string SecondInput="";

            firstInput = inputValueArray[0];
            SecondInput = inputValueArray[1];
            

            if (SecondInput[0] == '-')
            {
                SecondInput = SecondInput.Substring(1, SecondInput.Length - 1);
            }
            else
            {
                SecondInput = '-' + SecondInput;
            }

            inputString = firstInput + SelectedOperator + SecondInput;
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
        SelectedOperator = "";
        UpdateUI();
    }
   
    public void CalCulation()
    {
        char oprtr = char.Parse(SelectedOperator);
        string[] inputValueArray = inputString.Split(oprtr);

        double inputOne = double.Parse(inputValueArray[0]);
        double inputTwo = double.Parse(inputValueArray[1]);
        double result = 0;

        switch (SelectedOperator)
        {
            case "+":
                result = inputOne + inputTwo;
                break;
            case "/":
                result = inputOne / inputTwo;
                break;
            case "*":
                result = inputTwo * inputOne;
                break;
            case "-":
                result = inputOne - inputTwo;
                break;
        }
        outputString = result.ToString();
        UpdateUI();
    }

    public void ChangeUITheme()
    {
        // Toggle the active state of the Red GameObject
        Red.SetActive(!Red.activeSelf);
    }
}
