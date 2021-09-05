// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""943c283f-ff44-4f61-b4d4-bc54bf569b55"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""087f16ed-9456-4b9f-a252-e4d76fa6ac9b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AbilityActivate"",
                    ""type"": ""Button"",
                    ""id"": ""b226195c-b404-48ae-ba3d-f4f5c1a4b3e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WeaponRotate"",
                    ""type"": ""Value"",
                    ""id"": ""4a8d69ec-6a5c-4c6d-a015-ae6b32eb49ee"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WeaponFire"",
                    ""type"": ""Button"",
                    ""id"": ""f70cd70d-0d18-4041-9d36-47949d9c7ba3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""1e11466f-e314-4896-bfa5-ed785f95bc6b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a2f75033-0254-4860-b164-d8e3a0c26128"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9f46cf7b-5094-40f4-b5fb-92d220f33c7c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c352b00d-b975-4591-91d2-6c5f2348cee7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ab801a1c-f091-42c8-8116-df11eb360759"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""84bf50ad-4190-4d5c-badb-a69c10fc228d"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityActivate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ba0c78d-53eb-4546-893b-c857ebde1c85"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeaponRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82648324-cd53-4af3-a43f-6f0eda73d56e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeaponFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_AbilityActivate = m_Player.FindAction("AbilityActivate", throwIfNotFound: true);
        m_Player_WeaponRotate = m_Player.FindAction("WeaponRotate", throwIfNotFound: true);
        m_Player_WeaponFire = m_Player.FindAction("WeaponFire", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_AbilityActivate;
    private readonly InputAction m_Player_WeaponRotate;
    private readonly InputAction m_Player_WeaponFire;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @AbilityActivate => m_Wrapper.m_Player_AbilityActivate;
        public InputAction @WeaponRotate => m_Wrapper.m_Player_WeaponRotate;
        public InputAction @WeaponFire => m_Wrapper.m_Player_WeaponFire;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @AbilityActivate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbilityActivate;
                @AbilityActivate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbilityActivate;
                @AbilityActivate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbilityActivate;
                @WeaponRotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponRotate;
                @WeaponRotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponRotate;
                @WeaponRotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponRotate;
                @WeaponFire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponFire;
                @WeaponFire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponFire;
                @WeaponFire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponFire;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @AbilityActivate.started += instance.OnAbilityActivate;
                @AbilityActivate.performed += instance.OnAbilityActivate;
                @AbilityActivate.canceled += instance.OnAbilityActivate;
                @WeaponRotate.started += instance.OnWeaponRotate;
                @WeaponRotate.performed += instance.OnWeaponRotate;
                @WeaponRotate.canceled += instance.OnWeaponRotate;
                @WeaponFire.started += instance.OnWeaponFire;
                @WeaponFire.performed += instance.OnWeaponFire;
                @WeaponFire.canceled += instance.OnWeaponFire;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAbilityActivate(InputAction.CallbackContext context);
        void OnWeaponRotate(InputAction.CallbackContext context);
        void OnWeaponFire(InputAction.CallbackContext context);
    }
}
