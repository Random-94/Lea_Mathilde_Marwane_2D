using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
        //Fonction : Bouton "Jouer" pour lancer le jeu
        //Remplacer "Testjeu" par le nom de la scene du jeu
    public void PlayBouton()
    {
        SceneManager.LoadScene("Testjeu");
    }
    
    //Fonction : Bouton "Credits" pour afficher les participants au developpement
    public void CreditBouton()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    //Fonction : Bouton "Quitter" pour arreter le jeu
    public void QuitBouton()
    {
        Debug.Log("Quitte le jeu");
        Application.Quit();
    }
}
