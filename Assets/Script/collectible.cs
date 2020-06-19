using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class collectible : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Score;
    // on créé une variable qui apparait dans l'inspector pour afficher le score
    private int ScoreValue;
    // autre variable "valeur du score" nombre entier "int"


    void Start()
    {
        ScoreValue = 0; //donne une valeur à la variable "valeur du score"
    }


    void Update()
    {
        Score.text = "Score : " + ScoreValue;
        // le compteur affiche "score : + la valeur de ScoreValue

    }

    private void OnTriggerEnter2D(Collider2D other)
    // on apelle une fonction qui detecte quand un objet est traversé, 
    // other on peut l'appeller comme on veut
    {

        Debug.Log("tu as récupéré un joyaux!");
        // on affiche un message dans la console, quand la fonction est vérifié
        // le compteur fonctionne et il affiche "pumpkin detected" dans la console

        if (other.gameObject.CompareTag("Joyaux"))
        // on appelle la variable qu'on a mis dans la fonction avec l'objet et le tag qu'on à mis a nos collectibles
        {

            Destroy(other.gameObject);
            ScoreValue += 1;
            /* on peut ecrire aussi : 
            scoreValue ++;
            ScoreValue = ScoreValue +1;
            */
        }
    }
}
