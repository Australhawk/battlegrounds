using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour {

    public TextMeshProUGUI alivePlayers;
    public TextMeshProUGUI gameStartCountDown;
    public static GameManager instance;
    public int countDown = 90;
    [HideInInspector]
    public bool gameStarted = false;
    private void Start()
    {
        if(instance == null)
        {
            instance = this;

            // START GAME;

            StartCoroutine(StartGame());
        }
        else
        {
            Destroy(this);
        }
    }
    // Use this for initialization
    void FixedUpdate () {
        int players = FindObjectsOfType<PlayerStats>().Length;
        alivePlayers.SetText(players.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator StartGame()
    {
        gameStartCountDown.enabled = true;
        while(countDown > 0)
        {
            gameStartCountDown.SetText(countDown.ToString());
            yield return new WaitForSecondsRealtime(1);
            countDown--;
        }
        gameStartCountDown.transform.parent.gameObject.SetActive(false);
        gameStarted = true;
        
    }
}
