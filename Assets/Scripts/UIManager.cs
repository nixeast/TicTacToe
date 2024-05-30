using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public Text textDisplayCurrentPlayerNumber;
    public Text textGameResult;
    public Image bgGameResult;
    public Button btnRestartGame;

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
            textGameResult.text = nWinPlayerNumber + " Player win !";
            btnRestartGame.gameObject.SetActive(true);
        }
        else if(nWinPlayerNumber == 0)
        {
            bgGameResult.gameObject.SetActive(true);
            textGameResult.text = "Draw !";
            btnRestartGame.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
