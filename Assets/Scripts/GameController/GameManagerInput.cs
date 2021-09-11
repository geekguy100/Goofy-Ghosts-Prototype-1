// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/GameController/GameManagerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameManagerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameManagerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameManagerInput"",
    ""maps"": [
        {
            ""name"": ""GameController"",
            ""id"": ""fbf115d4-aa1c-4af5-a656-e8cb1d1ffd65"",
            ""actions"": [
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""b8bb115b-c7c1-4078-8617-68fe5b5977bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2b2a222b-7a6c-4113-a331-7c72eccf208a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameController
        m_GameController = asset.FindActionMap("GameController", throwIfNotFound: true);
        m_GameController_PauseGame = m_GameController.FindAction("PauseGame", throwIfNotFound: true);
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

    // GameController
    private readonly InputActionMap m_GameController;
    private IGameControllerActions m_GameControllerActionsCallbackInterface;
    private readonly InputAction m_GameController_PauseGame;
    public struct GameControllerActions
    {
        private @GameManagerInput m_Wrapper;
        public GameControllerActions(@GameManagerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseGame => m_Wrapper.m_GameController_PauseGame;
        public InputActionMap Get() { return m_Wrapper.m_GameController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameControllerActions set) { return set.Get(); }
        public void SetCallbacks(IGameControllerActions instance)
        {
            if (m_Wrapper.m_GameControllerActionsCallbackInterface != null)
            {
                @PauseGame.started -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnPauseGame;
            }
            m_Wrapper.m_GameControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
            }
        }
    }
    public GameControllerActions @GameController => new GameControllerActions(this);
    public interface IGameControllerActions
    {
        void OnPauseGame(InputAction.CallbackContext context);
    }
}
