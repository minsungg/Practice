using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int number;
    private TextMeshProUGUI text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        number = MainManager.Instance.number;
        text = GameObject.Find("Number").GetComponent<TextMeshProUGUI>();
        
        text.text = "" + number;
    }

    // Update is called once per frame
    void Update()
    {
        number = MainManager.Instance.number;
        text.text = "" + number;
    }

    public void Do()
    {
        if (SceneManager.GetActiveScene().name == "PositiveScene")
        {
            MainManager.Instance.number++;
        }
        else if (SceneManager.GetActiveScene().name == "NegativeScene")
        {
            MainManager.Instance.number--;
        }
    }

    public void Turn()
    {
        if(SceneManager.GetActiveScene().name=="PositiveScene")
        {
            SceneManager.LoadScene("NegativeScene");
        } else if (SceneManager.GetActiveScene().name == "NegativeScene")
        {
            SceneManager.LoadScene("PositiveScene");
        }
    }
}
