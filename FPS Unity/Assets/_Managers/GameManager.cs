using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Text m_MessageText;
    public Text m_AmmoText;
    public int ammo;
    public Text m_AmmoCounter;


    public GameObject[] m_Characters;

        private float m_gameTime = 0;
        public float GameTime
    { get

    {return m_gameTime;
    }
    }

    public enum GameState
    {
        Start,
        Playing,
        GameOver
    };

    private GameState m_GameState;
    public GameState State { get { return m_GameState;  } }



    // Start is called before the first frame update
    private void Awake()
    {
        m_GameState = GameState.Start;
    }

    // Update is called once per frame
    private void Start()
    {
        for (int i = 0; i < m_Characters.Length; i++)
        {
            m_Characters[i].SetActive(false);
        }

        m_AmmoText.gameObject.SetActive(false);
        m_MessageText.text = "Find the key and escape";
    }

    private void Update()
    {
        switch (m_GameState)
        {
            case GameState.Start:
                if (Input.GetKeyUp(KeyCode.Return) == true)
                {
                    m_AmmoText.gameObject.SetActive(true);
                    m_MessageText.text = "";
                    m_AmmoText.text = "Ammo: " + ammo;

                    m_GameState = GameState.Playing;
                    for (int i = 0; i < m_Characters.Length; i++)
                    {
                        m_Characters[i].SetActive(true);
                    }
                }
                break;
            case GameState.Playing:
                bool isGameOver = false;

                m_gameTime += Time.deltaTime;
                int seconds = Mathf.RoundToInt(m_gameTime);


                if (OneCharacterLeft() == true)
                {
                    isGameOver = true;
                }
                else if (IsPlayerDead() == true)
                {
                    isGameOver = true;
                }
                //need to set game state over when player exits door

                if (isGameOver == true)
                {
                    m_GameState = GameState.GameOver;
                    m_AmmoText.gameObject.SetActive(false);

                    if(IsPlayerDead() == true)
                    {
                        m_MessageText.text = "You failed to escape";
                    }
                    else
                    {
                        m_MessageText.text = "You got away";
                    }
                }
                break;

            case GameState.GameOver:
                if (Input.GetKeyUp(KeyCode.Return) == true)
                    {
                    m_gameTime = 0;
                    m_GameState = GameState.Playing;
                    m_MessageText.text = "";
                    m_AmmoText.gameObject.SetActive(true);

                    for(int i = 0; i < m_Characters.Length; i++)
                    {
                        m_Characters[i].SetActive(true);
                    }
                    }
                break;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();

        }
      bool OneCharacterLeft()
        {
            int numCharactersLeft = 0;

            for (int i = 0; i < m_Characters.Length; i++)
            {
                if (m_Characters[i].activeSelf == true)
                {
                    numCharactersLeft++;
                }
            }
            return numCharactersLeft <= 1;
        }

       bool IsPlayerDead()
        {
            for (int i =0; 1 < m_Characters.Length; i++)
            {
                if (m_Characters[i].activeSelf == false)
                {
                    if (m_Characters[i].tag == "Player")
                        return true;
                }
            }

            return false;

        }
            

    }
}
