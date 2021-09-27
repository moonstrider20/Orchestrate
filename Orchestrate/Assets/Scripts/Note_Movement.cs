using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note_Movement : MonoBehaviour
{
    public bool canBeDestroyed = false;
    public TextMeshProUGUI SuccessfulText;

    void Start()
    {
        SuccessfulText.text = "";
    }
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - 0.05f, transform.position.y);
    }

    void Update()
    {
        if (Input.GetButtonDown("Tap") && canBeDestroyed)
        {
            SuccessfulText.text = "You did it, you successfully tapped the square!";
            Destroy(gameObject, 0.0000001f);
        }
        if (transform.position.x <= -8.74)
        {
            SuccessfulText.text = "Oh no, the note escaped and you have now taken damage.";
            Destroy(gameObject, 0.000001f);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canBeDestroyed = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canBeDestroyed = false;
    }
}
