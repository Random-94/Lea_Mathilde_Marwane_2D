using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;

    private Rigidbody2D myRB;

    private Vector2 direction;

    public float JumpForce;
    private bool IsOnGround = false;

    private void OnEnable()
    {
        //on instancie l'input system créé dans Unity
        var Controls = new PlayerControler();
        Controls.Enable();

        //quand on appuie sur les inputs de l'action Move de l'action Map player, on lance la fonction OnMovePerformed
        Controls.Player.Move.performed += OnMovePerformed;
        ////quand on arrête d'appuyer sur les inputs de l'action Move de l'action Map player, on lance la fonction OnMoveCanceled
        Controls.Player.Move.canceled += OnMoveCanceled;

        ////quand on appuie sur les inputs de l'action Jump de l'action Map player, on lance la fonction OnJumpPerformed
        Controls.Player.Jump.performed += OnJumpPerformed;
    }

    // Start is called before the first frame update
    void Start()
    {
        //on récupère le Rigidbody2D du Player pour pouvoir agir dessus
        myRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //on fait en sorte que le Player ne puisse se deplacer que sur l'axe x
        var playerDirection = new Vector2(direction.x, 0);

        //Tant que la vitesse de déplacement du player n'est pas superieure à maxSpeed, on lui ajoute une force en fonction des inputs enclenchés
        if (myRB.velocity.sqrMagnitude < maxSpeed)
        {
            myRB.AddForce(playerDirection * speed);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        //la variable direction recupère la position (-1, 0 ou 1) des inputs enclenchés
        direction = obj.ReadValue<Vector2>();
    }

    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
        //si le bool IsOnGround est vrai, on ajoute une force (JumpForce) vers le haut sur le player
        //puis on repasse le booléen a faux pour arrêter d'ajouter la force même si on continue d'enclencher l'input
        if(IsOnGround)
        {
            myRB.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            IsOnGround = false;
        }
    }

    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        //quand on arrête d'appuyer sur les inputs, on fait en sorte que le personnage ne reçoive plus aucune force pour qu'il arrête d'avancer
        direction = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //si le Player collisionne avec un GameObject qui a le tag "Ground" le booléen IsOnGround passe en true pour que le Player puisse sauter
        if(other.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
        
    }

}
