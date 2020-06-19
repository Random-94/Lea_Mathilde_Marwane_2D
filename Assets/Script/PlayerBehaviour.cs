using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // on ajoute le namespace des deplacement du personnage
using UnityEngine.Events; 
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    //public UnityEvent onDeath;

    [SerializeField] private GameObject gameOverCanvas;  // on cree une variable modifiable dans l'inspector
    [SerializeField] float speed;// on cree une variable modifiable dans l'inspector
    [SerializeField] float maxSpeed;// on cree une variable modifiable dans l'inspector



    private Rigidbody2D myRB; // on cree une variable pour modifier le rigidbody du personnage

    private Vector2 direction; // on cree une variable pour la direction du personnage

    public float JumpForce; // on cree une variable pour modifier la force du saut du personnage
    private bool IsOnGround = false; // on cree une variable booleenne qu'on déclare "faux" 

    private Animator MyAnim; // on cree une variable pour l'animation du personnage
    private SpriteRenderer MySprite; // on cree une variable pour modifier le sprite qui va etre affiché pendant les animations

    private void OnEnable() // 
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

        MyAnim = GetComponent<Animator>(); // on recupère le composant animator
        MySprite = GetComponent<SpriteRenderer>(); // on recupère le composant sprite renderer
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

        // on lance l'animation isrunning dès que le personnage est en mouvement
        var isRunning = playerDirection.x != 0; 
        MyAnim.SetBool("IsRunning", isRunning);

        //on change l'orientatino du sprite en fonction de sa direction
        if(direction.x < 0)
        {
            MySprite.flipX = true;
        }
        else if(direction.x > 0) 
        {
            MySprite.flipX = false;
        }

        //on lance l'animation isjumping et isfalling dès que le personnage est en mouvement sur l'axe y
        var IsAscending = !IsOnGround && myRB.velocity.y > 0;
        MyAnim.SetBool("IsJumping", IsAscending);
        var IsDescending = !IsOnGround && myRB.velocity.y > 0;
        MyAnim.SetBool("IsFalling", IsDescending);
        MyAnim.SetBool("IsGrounded", IsOnGround);
        
        
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

        //si le Player collisionne avec un GameObject qui a le tag "vide" on lance la fonction gameover
        if (other.gameObject.CompareTag("Vide"))
        {
            GameOver();
            Debug.Log("Bravo tu creves !");
        }
        
    }

    public void GameOver()
    {
        // Lancement de l’event onDeath
        //onDeath.Invoke();
        // Instantiation de l’écran de Game Over
        //Instantiate(gameOverCanvas);
        // Destruction de l’objet sur lequel le script est placé
        Destroy(gameObject);
        SceneManager.LoadScene("FabMenu");
        
    }
}
