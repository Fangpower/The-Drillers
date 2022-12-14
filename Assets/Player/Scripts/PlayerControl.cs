//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Player/PlayerControl.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControl : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""97ac8537-35ca-403a-be47-e51ebf38576c"",
            ""actions"": [
                {
                    ""name"": ""LR"",
                    ""type"": ""PassThrough"",
                    ""id"": ""dfec804f-c2a1-48c5-bdb6-3fdac60c6dfa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UD"",
                    ""type"": ""PassThrough"",
                    ""id"": ""acfb8ad5-7f59-4ce5-a35f-9c24d4a85a2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""88bf798b-298e-4630-806a-e86628a3e8b1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Mine"",
                    ""type"": ""Button"",
                    ""id"": ""d48bbddb-0d18-432a-b62a-df360ade933a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""d9937ad3-a441-4a5e-ad8e-712fcd22789a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LR"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2b10ae73-96fd-40f2-861a-1e6f4825da98"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1ff380ae-2f16-4bef-88b5-9acadd53b6b5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4443485d-8c66-4498-99bd-71c32bd8fff2"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80ec5a3f-6589-421f-97fb-fb04653d4fd5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""0bc4a714-14c5-4d6f-b9ca-f96174ff1e54"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0254e645-a30e-4239-be66-1345e55435bf"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f413c610-6d1d-4821-9e65-0c2543e17ed3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Controls
        m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
        m_Controls_LR = m_Controls.FindAction("LR", throwIfNotFound: true);
        m_Controls_UD = m_Controls.FindAction("UD", throwIfNotFound: true);
        m_Controls_Mouse = m_Controls.FindAction("Mouse", throwIfNotFound: true);
        m_Controls_Mine = m_Controls.FindAction("Mine", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Controls
    private readonly InputActionMap m_Controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_Controls_LR;
    private readonly InputAction m_Controls_UD;
    private readonly InputAction m_Controls_Mouse;
    private readonly InputAction m_Controls_Mine;
    public struct ControlsActions
    {
        private @PlayerControl m_Wrapper;
        public ControlsActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @LR => m_Wrapper.m_Controls_LR;
        public InputAction @UD => m_Wrapper.m_Controls_UD;
        public InputAction @Mouse => m_Wrapper.m_Controls_Mouse;
        public InputAction @Mine => m_Wrapper.m_Controls_Mine;
        public InputActionMap Get() { return m_Wrapper.m_Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @LR.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLR;
                @LR.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLR;
                @LR.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLR;
                @UD.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnUD;
                @UD.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnUD;
                @UD.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnUD;
                @Mouse.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouse;
                @Mine.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMine;
                @Mine.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMine;
                @Mine.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMine;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LR.started += instance.OnLR;
                @LR.performed += instance.OnLR;
                @LR.canceled += instance.OnLR;
                @UD.started += instance.OnUD;
                @UD.performed += instance.OnUD;
                @UD.canceled += instance.OnUD;
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
                @Mine.started += instance.OnMine;
                @Mine.performed += instance.OnMine;
                @Mine.canceled += instance.OnMine;
            }
        }
    }
    public ControlsActions @Controls => new ControlsActions(this);
    public interface IControlsActions
    {
        void OnLR(InputAction.CallbackContext context);
        void OnUD(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
        void OnMine(InputAction.CallbackContext context);
    }
}
