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
        inputManager.main.Collect.performed += _ => Collect(true);
        inputManager.main.Collect.canceled += _ => Collect(false);
        inputManager.main.Reset.performed += _ => Reset(true);
        inputManager.main.Reset.canceled += _ => Reset(false);
        inputManager.main.Menu.performed += _ => Menu(true);
        inputManager.main.Menu.canceled += _ => Menu(false);
        inputManager.main.ActionQ.performed += _ => ActionQ(true);
        inputManager.main.ActionQ.canceled += _ => ActionQ(false);
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

    private void Collect(bool bol)
    {
        inputs.collect = bol;
    }

    private void Reset(bool bol)
    {
        inputs.reset = bol;
    }

    private void Menu(bool bol)
    {
        inputs.menu = bol;
    }

    private void ActionQ(bool bol)
    {
        inputs.actionQ = bol;
    }

    private void Move(Vector2 direction)
    {
        inputs.vector = direction;
    }

    public Inputs GetInput()
    {
        return inputs;
    }
}

public struct Inputs
{
    public Vector2 vector { get; set; }
    public bool collect { get; set; }
    public bool reset { get; set; }
    public bool menu { get; set; }
    public bool actionQ { get; set; }
}
