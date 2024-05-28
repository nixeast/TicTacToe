using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    //public GameObject btnTicTacToe_01;

    //int sizeTicTacToeBtn = 0;
    //sizeTicTacToeBtn = 9;
    public GameObject[] btnTicTacToe;
    //int nCurrentPlayerNumber = 0;
    TMP_Text test_tmpText;
    

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Hello world!!");

        string strBtnName = btnTicTacToe[0].name;
        Debug.Log(strBtnName);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestMessage(int nBtnNumber)
    {
        //string strMyName = this.name;
        //Debug.Log("test btn clicked..");
        Debug.Log("btn " + nBtnNumber +" clicked..");

        string tmp = btnTicTacToe[nBtnNumber].transform.GetChild(0).name;

        //Text txtBtnNumber = btnTicTacToe[nBtnNumber].GetComponent<Text>();
        Debug.Log(tmp);

        GameObject testGameObject = btnTicTacToe[nBtnNumber].transform.GetChild(0).gameObject;
        string myString = testGameObject.GetComponent<TMP_Text>().text;

        Debug.Log(myString);

    }

}
