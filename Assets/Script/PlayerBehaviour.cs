using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;

    private Rigidbody2D myRB;

    private void OnEnable()
    {
        var Controls = new PlayerControler();
        Controls.Enable();

        Controls.Player.Move.performed += OnMovePerformed;
        Controls.Player.Move.canceled += OnMoveCanceled;
    }

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.ReadValue<Vector2>()); //OK
    }

    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {

    }
}
