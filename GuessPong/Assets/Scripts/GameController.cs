using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text winnerLabel;
    public Text restartLabel;

    public BallController ballController;

    public static GameController Instance;

    private void Awake()
    {
        if (Instance)
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        } else
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        winnerLabel.enabled = false;
        restartLabel.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    public void AnnounceWinner(string winner)
    {
        winnerLabel.text = winner + " has won!";
        winnerLabel.enabled = true;
        restartLabel.enabled = true;
    }

}
