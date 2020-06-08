using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RetourBouton : MonoBehaviour
{
public void retourBouton()
    {
        SceneManager.LoadScene("FabMenu");
    }

}