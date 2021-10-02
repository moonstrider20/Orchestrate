using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Game_Controller : MonoBehaviour
{
    public Slider HealthBar;

    public Image HealthBarFill;

    public Gradient HealthBarGradient;
    public int Health;

    public GameObject Note;

    public Transform NoteSpawn;

    public GameObject RestartButton;

    public TextMeshProUGUI SuccessfulText;

    void Awake()
    {
        HealthBar.maxValue = Health;
        HealthBar.value = Health;
        HealthBarFill.color = HealthBarGradient.Evaluate(1f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Note") == null && Health > 0)
        {
            Instantiate(Note, NoteSpawn);
        }
    }

    public void ChangeHealth(int value)
    {
        Health += value;

        if ( Health > 0 )
        {
            HealthBar.value = Health;
            HealthBarFill.color = HealthBarGradient.Evaluate(HealthBar.normalizedValue);
        }
        else if ( Health == 0 )
        {
            HealthBar.value = 0;
            HealthBarFill.color = HealthBarGradient.Evaluate(HealthBar.normalizedValue);
            SuccessfulText.text = "You lost. Restart?";
            RestartButton.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("PC_Version");
    }
}
