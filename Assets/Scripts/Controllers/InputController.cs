using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private InputManager inputManager;
    private Inputs inputs;

    private void Awake()
    {
        inputs = new Inputs();
        inputManager = new InputManager();
        inputManager.main.Collect.performed += _ => Collect();
        inputManager.main.Collect.canceled += _ => CollectRelease();
        inputManager.main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        inputManager.main.Movement.canceled += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        inputManager.Enable();
    }

    private void OnDisable()
    {
        inputManager.Disable();
    }

    private void Collect()
    {
        inputs.collect = true;
        Debug.Log(inputs.collect);
    }

    private void CollectRelease()
    {
        inputs.collect = false;
        Debug.Log(inputs.collect);
    }

    private void Move(Vector2 direction)
    {
        inputs.vector = direction;
        Debug.Log(inputs.vector);
    }

    public Inputs getInput()
    {
        return inputs;
    }
}

public struct Inputs
{
    public Vector2 vector { get; set; }
    public bool collect { get; set; }
}
