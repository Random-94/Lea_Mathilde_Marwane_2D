using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RetourBouton : MonoBehaviour
{
public void retourBouton() // on cree une fonction qui permet de relancer la scene fabmenu quand on l'active
    {
        SceneManager.LoadScene("FabMenu");
    }

}