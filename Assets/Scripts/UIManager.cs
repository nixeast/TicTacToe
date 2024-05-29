using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text textDisplayCurrentPlayerNumber;
    public Text textGameResult;
    public Image bgGameResult;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCurrentPlayerNumberOnDisplay(int nCurrentPlayerNumber)
    {
        textDisplayCurrentPlayerNumber.text = nCurrentPlayerNumber.ToString();
    }

    public void ShowGameResult(int nWinPlayerNumber)
    {
        if(nWinPlayerNumber != 0)
        {
            bgGameResult.gameObject.SetActive(true);
            //textGameResult.gameObject.SetActive(true);
            textGameResult.text = nWinPlayerNumber + " Player win !";
        }
        else if(nWinPlayerNumber == 0)
        {
            bgGameResult.gameObject.SetActive(true);
            textGameResult.text = "Draw !";
        }
    }
}
