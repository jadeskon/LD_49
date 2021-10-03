// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controllers/InputManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""main"",
            ""id"": ""1da8ecc3-36b6-46c2-8467-89fdba786ca1"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e79142e0-7bf1-488b-816d-2182a84b0ee4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Collect"",
                    ""type"": ""Button"",
                    ""id"": ""15435c5d-7e9b-47cc-982a-ef0f5344d9c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""ff3b50bb-d7bf-4461-9114-26bd70762c66"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionQ"",
                    ""type"": ""Button"",
                    ""id"": ""4130cfaf-7ef7-41a3-b7a4-8ac3233fe5e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""aed0a34b-da7d-4789-98ca-0daeab631a24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""9469ed0b-3441-48ce-823c-60eb1c40f6d9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""960d99b0-b330-4b1b-aac6-e3a2ff6a4907"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3ce4ecfe-822d-4ef4-a536-c021486a36b9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8e1ce327-aeb1-4ca1-ad35-2ffb758cf2e9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""edb755d3-9da1-40e8-ab18-e8a414bb933e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""6fbf0f25-976d-4642-b888-615fca91645a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""37aec6f9-bedd-4fe9-805b-b71eefa34f0c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d3be71e9-74c8-4a01-afc6-9b678d3c0d79"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b09b1ec3-2f91-4344-9225-1aff65698fbe"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8b76f7f9-e82d-4667-9181-39b077259622"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6487794f-034b-470e-b0f9-d17140c70d51"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Collect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62737d08-cb6c-4831-b361-ef37e4bba8aa"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Collect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c022c24-54f6-418c-b7f6-c7c174637fda"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73789684-3757-4cef-b521-f9a03f5b3c7f"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionQ"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abbdfc03-dee0-4524-ac26-d36eade6a01c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // main
        m_main = asset.FindActionMap("main", throwIfNotFound: true);
        m_main_Movement = m_main.FindAction("Movement", throwIfNotFound: true);
        m_main_Collect = m_main.FindAction("Collect", throwIfNotFound: true);
        m_main_Reset = m_main.FindAction("Reset", throwIfNotFound: true);
        m_main_ActionQ = m_main.FindAction("ActionQ", throwIfNotFound: true);
        m_main_Menu = m_main.FindAction("Menu", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // main
    private readonly InputActionMap m_main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_main_Movement;
    private readonly InputAction m_main_Collect;
    private readonly InputAction m_main_Reset;
    private readonly InputAction m_main_ActionQ;
    private readonly InputAction m_main_Menu;
    public struct MainActions
    {
        private @InputManager m_Wrapper;
        public MainActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_main_Movement;
        public InputAction @Collect => m_Wrapper.m_main_Collect;
        public InputAction @Reset => m_Wrapper.m_main_Reset;
        public InputAction @ActionQ => m_Wrapper.m_main_ActionQ;
        public InputAction @Menu => m_Wrapper.m_main_Menu;
        public InputActionMap Get() { return m_Wrapper.m_main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMovement;
                @Collect.started -= m_Wrapper.m_MainActionsCallbackInterface.OnCollect;
                @Collect.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnCollect;
                @Collect.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnCollect;
                @Reset.started -= m_Wrapper.m_MainActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnReset;
                @ActionQ.started -= m_Wrapper.m_MainActionsCallbackInterface.OnActionQ;
                @ActionQ.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnActionQ;
                @ActionQ.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnActionQ;
                @Menu.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMenu;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Collect.started += instance.OnCollect;
                @Collect.performed += instance.OnCollect;
                @Collect.canceled += instance.OnCollect;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
                @ActionQ.started += instance.OnActionQ;
                @ActionQ.performed += instance.OnActionQ;
                @ActionQ.canceled += instance.OnActionQ;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
            }
        }
    }
    public MainActions @main => new MainActions(this);
    public interface IMainActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCollect(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
        void OnActionQ(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
    }
}
