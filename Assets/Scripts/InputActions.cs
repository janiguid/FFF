// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Utilities/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""LandMovement"",
            ""id"": ""4a103845-87aa-47bf-b29d-ea22e7dd77ba"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""5deb4d88-16e9-4a51-81b8-4aff073758fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""54de0e6b-c24d-4d0a-bcc0-f91f9a153be0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""West"",
                    ""type"": ""Button"",
                    ""id"": ""2606c87f-b109-4721-bdc3-5eb0ce5a5edc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""North"",
                    ""type"": ""Button"",
                    ""id"": ""92b15c38-f90e-4d35-bf8c-03765f118cee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleFlight"",
                    ""type"": ""Button"",
                    ""id"": ""28179be7-f4f2-43b7-9921-8bdb14dd55c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""729667cf-ce25-4fa8-be5c-bf8339d6e601"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90b604fd-e563-4e15-8f15-55b6b9edd945"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Horizontal"",
                    ""id"": ""760c0081-e8c8-47eb-83a2-af966688e8dd"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1118fe5d-24d2-452a-aa19-d2dc88f01402"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2b96bf9f-580d-4d83-9a92-c71a3719bc98"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""KeyboardHorizontal"",
                    ""id"": ""eb06e807-23c1-45ab-be8a-dba5e08549de"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ba5143e8-d399-4841-a9e8-890383296c03"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""32a091c0-b539-4de6-8b74-85843149db77"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""JoystickHorizontal"",
                    ""id"": ""d3a91d15-e9a1-4d8d-8a12-3230d6f385a5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""24ead769-fd87-4ff6-88dd-5a30b07a3d7a"",
                    ""path"": ""<DualShockGamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""df0e5488-aa82-4e8a-88a0-c8961c1c14cd"",
                    ""path"": ""<DualShockGamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d90a2905-a357-4cca-95fd-5e952413d1d7"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""West"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2651c72-2b2a-4e47-ac35-6dd417cb83ec"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""West"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c6e46f6-24e3-4ede-b170-30b10f8eb44b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9308401-4ac0-4835-a81b-7245b18d6f5f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba2934aa-69f5-4025-8632-fbfbf95b2760"",
                    ""path"": ""<DualShockGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57bb8f26-f5e3-4e1a-a707-9b350abdde2b"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""FlightMovement"",
            ""id"": ""38f29bcf-fe25-46e2-acea-54937c778e7b"",
            ""actions"": [
                {
                    ""name"": ""Flight"",
                    ""type"": ""Value"",
                    ""id"": ""49b2b898-f485-484e-8e97-51959c251c24"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cursor"",
                    ""type"": ""Value"",
                    ""id"": ""fdeaa65d-887f-4a3a-aa9b-63b674c44fe0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fireball"",
                    ""type"": ""Button"",
                    ""id"": ""582fa23c-bf17-4841-b06b-c5e68248dd56"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1a8fccac-0cdb-44e3-ba8d-a9c28743b89b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""5d2dff92-8a17-41eb-b2f9-8d29c4b08647"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dd399ef5-14b8-4ecd-a096-0a9f0def176f"",
                    ""path"": ""<keyboard>/W"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""122e8694-4d68-4e45-a465-b022602f0c3f"",
                    ""path"": ""<keyboard>/S"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""81ef596d-7221-4b5d-a818-5952dd99e529"",
                    ""path"": ""<keyboard>/A"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e43af979-d392-4ff4-8925-719fcb581141"",
                    ""path"": ""<keyboard>/D"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b1230ead-4079-45cc-a420-34e78044dc69"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""436834d6-a32d-4bfa-a640-478d584d4da7"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ca01c1f-9a39-4da8-bc6f-4a85cf76e4d6"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ecc9941-1549-494d-b477-139244ce0121"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fireball"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d9c9a86-634f-4ec4-ab2c-d199108ac5a4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fireball"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // LandMovement
        m_LandMovement = asset.FindActionMap("LandMovement", throwIfNotFound: true);
        m_LandMovement_Jump = m_LandMovement.FindAction("Jump", throwIfNotFound: true);
        m_LandMovement_Move = m_LandMovement.FindAction("Move", throwIfNotFound: true);
        m_LandMovement_West = m_LandMovement.FindAction("West", throwIfNotFound: true);
        m_LandMovement_North = m_LandMovement.FindAction("North", throwIfNotFound: true);
        m_LandMovement_ToggleFlight = m_LandMovement.FindAction("ToggleFlight", throwIfNotFound: true);
        // FlightMovement
        m_FlightMovement = asset.FindActionMap("FlightMovement", throwIfNotFound: true);
        m_FlightMovement_Flight = m_FlightMovement.FindAction("Flight", throwIfNotFound: true);
        m_FlightMovement_Cursor = m_FlightMovement.FindAction("Cursor", throwIfNotFound: true);
        m_FlightMovement_Fireball = m_FlightMovement.FindAction("Fireball", throwIfNotFound: true);
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

    // LandMovement
    private readonly InputActionMap m_LandMovement;
    private ILandMovementActions m_LandMovementActionsCallbackInterface;
    private readonly InputAction m_LandMovement_Jump;
    private readonly InputAction m_LandMovement_Move;
    private readonly InputAction m_LandMovement_West;
    private readonly InputAction m_LandMovement_North;
    private readonly InputAction m_LandMovement_ToggleFlight;
    public struct LandMovementActions
    {
        private @InputActions m_Wrapper;
        public LandMovementActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_LandMovement_Jump;
        public InputAction @Move => m_Wrapper.m_LandMovement_Move;
        public InputAction @West => m_Wrapper.m_LandMovement_West;
        public InputAction @North => m_Wrapper.m_LandMovement_North;
        public InputAction @ToggleFlight => m_Wrapper.m_LandMovement_ToggleFlight;
        public InputActionMap Get() { return m_Wrapper.m_LandMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LandMovementActions set) { return set.Get(); }
        public void SetCallbacks(ILandMovementActions instance)
        {
            if (m_Wrapper.m_LandMovementActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_LandMovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_LandMovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_LandMovementActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_LandMovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_LandMovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_LandMovementActionsCallbackInterface.OnMove;
                @West.started -= m_Wrapper.m_LandMovementActionsCallbackInterface.OnWest;
                @West.performed -= m_Wrapper.m_LandMovementActionsCallbackInterface.OnWest;
                @West.canceled -= m_Wrapper.m_LandMovementActionsCallbackInterface.OnWest;
                @North.started -= m_Wrapper.m_LandMovementActionsCallbackInterface.OnNorth;
                @North.performed -= m_Wrapper.m_LandMovementActionsCallbackInterface.OnNorth;
                @North.canceled -= m_Wrapper.m_LandMovementActionsCallbackInterface.OnNorth;
                @ToggleFlight.started -= m_Wrapper.m_LandMovementActionsCallbackInterface.OnToggleFlight;
                @ToggleFlight.performed -= m_Wrapper.m_LandMovementActionsCallbackInterface.OnToggleFlight;
                @ToggleFlight.canceled -= m_Wrapper.m_LandMovementActionsCallbackInterface.OnToggleFlight;
            }
            m_Wrapper.m_LandMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @West.started += instance.OnWest;
                @West.performed += instance.OnWest;
                @West.canceled += instance.OnWest;
                @North.started += instance.OnNorth;
                @North.performed += instance.OnNorth;
                @North.canceled += instance.OnNorth;
                @ToggleFlight.started += instance.OnToggleFlight;
                @ToggleFlight.performed += instance.OnToggleFlight;
                @ToggleFlight.canceled += instance.OnToggleFlight;
            }
        }
    }
    public LandMovementActions @LandMovement => new LandMovementActions(this);

    // FlightMovement
    private readonly InputActionMap m_FlightMovement;
    private IFlightMovementActions m_FlightMovementActionsCallbackInterface;
    private readonly InputAction m_FlightMovement_Flight;
    private readonly InputAction m_FlightMovement_Cursor;
    private readonly InputAction m_FlightMovement_Fireball;
    public struct FlightMovementActions
    {
        private @InputActions m_Wrapper;
        public FlightMovementActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Flight => m_Wrapper.m_FlightMovement_Flight;
        public InputAction @Cursor => m_Wrapper.m_FlightMovement_Cursor;
        public InputAction @Fireball => m_Wrapper.m_FlightMovement_Fireball;
        public InputActionMap Get() { return m_Wrapper.m_FlightMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FlightMovementActions set) { return set.Get(); }
        public void SetCallbacks(IFlightMovementActions instance)
        {
            if (m_Wrapper.m_FlightMovementActionsCallbackInterface != null)
            {
                @Flight.started -= m_Wrapper.m_FlightMovementActionsCallbackInterface.OnFlight;
                @Flight.performed -= m_Wrapper.m_FlightMovementActionsCallbackInterface.OnFlight;
                @Flight.canceled -= m_Wrapper.m_FlightMovementActionsCallbackInterface.OnFlight;
                @Cursor.started -= m_Wrapper.m_FlightMovementActionsCallbackInterface.OnCursor;
                @Cursor.performed -= m_Wrapper.m_FlightMovementActionsCallbackInterface.OnCursor;
                @Cursor.canceled -= m_Wrapper.m_FlightMovementActionsCallbackInterface.OnCursor;
                @Fireball.started -= m_Wrapper.m_FlightMovementActionsCallbackInterface.OnFireball;
                @Fireball.performed -= m_Wrapper.m_FlightMovementActionsCallbackInterface.OnFireball;
                @Fireball.canceled -= m_Wrapper.m_FlightMovementActionsCallbackInterface.OnFireball;
            }
            m_Wrapper.m_FlightMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Flight.started += instance.OnFlight;
                @Flight.performed += instance.OnFlight;
                @Flight.canceled += instance.OnFlight;
                @Cursor.started += instance.OnCursor;
                @Cursor.performed += instance.OnCursor;
                @Cursor.canceled += instance.OnCursor;
                @Fireball.started += instance.OnFireball;
                @Fireball.performed += instance.OnFireball;
                @Fireball.canceled += instance.OnFireball;
            }
        }
    }
    public FlightMovementActions @FlightMovement => new FlightMovementActions(this);
    public interface ILandMovementActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnWest(InputAction.CallbackContext context);
        void OnNorth(InputAction.CallbackContext context);
        void OnToggleFlight(InputAction.CallbackContext context);
    }
    public interface IFlightMovementActions
    {
        void OnFlight(InputAction.CallbackContext context);
        void OnCursor(InputAction.CallbackContext context);
        void OnFireball(InputAction.CallbackContext context);
    }
}
