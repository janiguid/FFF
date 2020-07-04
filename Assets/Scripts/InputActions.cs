// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Utilities/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace FFF
{
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
                    ""id"": ""4c6e46f6-24e3-4ede-b170-30b10f8eb44b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""North"",
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
        public struct LandMovementActions
        {
            private @InputActions m_Wrapper;
            public LandMovementActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Jump => m_Wrapper.m_LandMovement_Jump;
            public InputAction @Move => m_Wrapper.m_LandMovement_Move;
            public InputAction @West => m_Wrapper.m_LandMovement_West;
            public InputAction @North => m_Wrapper.m_LandMovement_North;
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
                }
            }
        }
        public LandMovementActions @LandMovement => new LandMovementActions(this);
        public interface ILandMovementActions
        {
            void OnJump(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
            void OnWest(InputAction.CallbackContext context);
            void OnNorth(InputAction.CallbackContext context);
        }
    }
}
