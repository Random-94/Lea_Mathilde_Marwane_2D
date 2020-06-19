using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Canvas : MonoBehaviour
{
    //on cree une fonction destroy public pour y acceder dans l'inspector pour detruire le gameobject lorsque qu'elle est activée
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
