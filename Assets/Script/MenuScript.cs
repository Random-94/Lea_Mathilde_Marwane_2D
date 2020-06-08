using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
  public void playBouton()
  {
      SceneManager.LoadScene("SampleScene");
  }

  public void quitBouton()
  {
      Debug.Log("Ferme le jeu");
      Application.Quit();
  }
}
