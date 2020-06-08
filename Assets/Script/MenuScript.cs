using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
  //Chaque fonction représente un bouton du Menu dans la hierarchy des gameobjets
  //(Design et disposition du code)


  //Fonction pour le bouton "jouer"
  public void playBouton()
  {
      SceneManager.LoadScene("SampleScene");//Charge la scène du jeu
  }

  //Fonction pour le bouton "Crédits"
  public void creditsBouton()
  {
    SceneManager.LoadScene("FabCredits");//Charge la scène de crédits
  }

  //Fonction pour le bouton "Quitter"
  public void quitBouton()
  {
      Debug.Log("Ferme le jeu");//Code de débug pour voir si le bouton réagit bien.
      Application.Quit();//Ferme et Arrête l'application
  }
}
