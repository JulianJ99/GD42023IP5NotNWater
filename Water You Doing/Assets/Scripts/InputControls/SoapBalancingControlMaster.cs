//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.1
//     from Assets/Scripts/InputControls/SoapBalancingControlMaster.inputactions
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

public partial class @SoapBalancingControlMaster : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @SoapBalancingControlMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SoapBalancingControlMaster"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""67ced49a-0af2-4d62-911e-2742fd7e3da2"",
            ""actions"": [
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""d229ec37-4031-4e15-82ed-3d622ef5ed77"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""rotate"",
                    ""type"": ""Button"",
                    ""id"": ""f6be389a-7a4d-4e2c-b5ff-bc0ea26152f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f1bed8e4-b02d-48ef-9324-d8f2bd036b34"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2fef5ed-e008-462c-8d6d-9699f70b9cb3"",
                    ""path"": ""<Sensor>"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Controls
        m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
        m_Controls_Touch = m_Controls.FindAction("Touch", throwIfNotFound: true);
        m_Controls_rotate = m_Controls.FindAction("rotate", throwIfNotFound: true);
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
    private readonly InputAction m_Controls_Touch;
    private readonly InputAction m_Controls_rotate;
    public struct ControlsActions
    {
        private @SoapBalancingControlMaster m_Wrapper;
        public ControlsActions(@SoapBalancingControlMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touch => m_Wrapper.m_Controls_Touch;
        public InputAction @rotate => m_Wrapper.m_Controls_rotate;
        public InputActionMap Get() { return m_Wrapper.m_Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @Touch.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnTouch;
                @Touch.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnTouch;
                @Touch.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnTouch;
                @rotate.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRotate;
                @rotate.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRotate;
                @rotate.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Touch.started += instance.OnTouch;
                @Touch.performed += instance.OnTouch;
                @Touch.canceled += instance.OnTouch;
                @rotate.started += instance.OnRotate;
                @rotate.performed += instance.OnRotate;
                @rotate.canceled += instance.OnRotate;
            }
        }
    }
    public ControlsActions @Controls => new ControlsActions(this);
    public interface IControlsActions
    {
        void OnTouch(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
}
