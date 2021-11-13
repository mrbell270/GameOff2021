// GENERATED AUTOMATICALLY FROM 'Assets/Resources/InputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""GameRunning"",
            ""id"": ""6c098fcd-1ece-470e-87a7-8902e3e485df"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""3ce60a73-575a-4afe-b644-79fd362a617c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""814aea12-c79d-4d1d-8f5b-ff32507b4de7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""02890115-7621-432f-9003-58eb8ca3f08b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""5e54acf0-30cc-4779-8bc2-a540e212a514"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Form1"",
                    ""type"": ""Button"",
                    ""id"": ""ee50ccc2-d2a3-42d4-a1bc-063b9a6ed8ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Form2"",
                    ""type"": ""Button"",
                    ""id"": ""d7235361-3fd6-4537-85ad-1e982ae8cab9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Form3"",
                    ""type"": ""Button"",
                    ""id"": ""2b7b7713-28a0-4527-8bd5-4d2331bd8adc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FormPrev"",
                    ""type"": ""Button"",
                    ""id"": ""b0575dec-5e25-4a44-8e2b-df47f07fd8f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Plan"",
                    ""type"": ""Button"",
                    ""id"": ""a437f61d-20b9-4117-9c1e-125dffbf08d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4b205c33-3eca-471e-ad11-9561ee4c7561"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamepadControlScheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""3bac8eaa-15bf-4aaf-8834-86d0e289ced7"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6903ef7f-23c4-41c0-b6d0-0ce1dbb06467"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d870586b-a4e4-4e38-b35b-3c60e43caea3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0ed3d0a1-a774-46b7-b2a5-1acc4aba2d1d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""56352f28-dc8a-41b7-8e12-3ad2fdda3644"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ffaba1e9-fe86-4cb1-8627-5e10d1776d01"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamepadControlScheme"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e77b2744-d3be-401b-ab71-c1ba8f9389fb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03c48e42-eaa3-4b29-bf18-7b4c65f4c7b4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamepadControlScheme"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75a9fc33-e9c6-434a-8e7e-31f37be8b5a3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""213b5cdf-266a-4bfb-99e8-69e40f470ad0"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdb5614a-4b13-4dff-885b-0592680aacde"",
                    ""path"": ""*/{Menu}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamepadControlScheme"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb5c1345-1bd3-4cff-8d9f-f74d2fb0df3c"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Form1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a9866b8-e013-4e0a-aebe-09c79a06b7f5"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Form2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7caaa89d-867e-4b90-a6ad-6676de99c6e2"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Form3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecff78f7-21d9-4aa0-aa11-b5c6bdae710b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Plan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c26af25-bfe6-4916-aa81-198c0acc676e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""FormPrev"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GamePlanning"",
            ""id"": ""c253926d-96fa-4eb7-801b-761a782bdcc3"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""f2d2e217-a66c-4a2f-a52f-81b3dda94386"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""80b9c658-8b2e-4913-bb10-825e16401054"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""5028173f-8bf6-4648-ba2e-ed5e75d454b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""cb9a8de1-8687-44f6-9ba6-651c52c516b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c986b89a-6203-4635-913a-09c252efc3b6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""5745fbde-52f2-48ea-a5bf-2acbd6a72d25"",
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
                    ""id"": ""db16c6d2-c8c6-4721-81a8-4003b42390f3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0845fe20-f34e-483c-a4b6-df4cb3f9cdb9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8910062c-2db0-4372-bb03-4f742984226a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""39f6ee52-1c36-46d5-93bd-1976677b00fd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6f11fba6-121e-4d6d-ba98-cf1cd04858da"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ce96372-257a-442b-bb1e-177cc08319ec"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardControlScheme"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""59d0d1c8-648c-4808-9eea-38bdb4c4e52d"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""19b913b9-1835-44e6-8ae6-3ef0eef16724"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8abaca4e-5151-4003-a1cf-ae55097fa002"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""GamepadControlScheme"",
            ""bindingGroup"": ""GamepadControlScheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KeyboardControlScheme"",
            ""bindingGroup"": ""KeyboardControlScheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // GameRunning
        m_GameRunning = asset.FindActionMap("GameRunning", throwIfNotFound: true);
        m_GameRunning_Pause = m_GameRunning.FindAction("Pause", throwIfNotFound: true);
        m_GameRunning_Move = m_GameRunning.FindAction("Move", throwIfNotFound: true);
        m_GameRunning_Attack = m_GameRunning.FindAction("Attack", throwIfNotFound: true);
        m_GameRunning_Use = m_GameRunning.FindAction("Use", throwIfNotFound: true);
        m_GameRunning_Form1 = m_GameRunning.FindAction("Form1", throwIfNotFound: true);
        m_GameRunning_Form2 = m_GameRunning.FindAction("Form2", throwIfNotFound: true);
        m_GameRunning_Form3 = m_GameRunning.FindAction("Form3", throwIfNotFound: true);
        m_GameRunning_FormPrev = m_GameRunning.FindAction("FormPrev", throwIfNotFound: true);
        m_GameRunning_Plan = m_GameRunning.FindAction("Plan", throwIfNotFound: true);
        // GamePlanning
        m_GamePlanning = asset.FindActionMap("GamePlanning", throwIfNotFound: true);
        m_GamePlanning_Pause = m_GamePlanning.FindAction("Pause", throwIfNotFound: true);
        m_GamePlanning_Move = m_GamePlanning.FindAction("Move", throwIfNotFound: true);
        m_GamePlanning_Use = m_GamePlanning.FindAction("Use", throwIfNotFound: true);
        m_GamePlanning_Back = m_GamePlanning.FindAction("Back", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Newaction = m_Menu.FindAction("New action", throwIfNotFound: true);
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

    // GameRunning
    private readonly InputActionMap m_GameRunning;
    private IGameRunningActions m_GameRunningActionsCallbackInterface;
    private readonly InputAction m_GameRunning_Pause;
    private readonly InputAction m_GameRunning_Move;
    private readonly InputAction m_GameRunning_Attack;
    private readonly InputAction m_GameRunning_Use;
    private readonly InputAction m_GameRunning_Form1;
    private readonly InputAction m_GameRunning_Form2;
    private readonly InputAction m_GameRunning_Form3;
    private readonly InputAction m_GameRunning_FormPrev;
    private readonly InputAction m_GameRunning_Plan;
    public struct GameRunningActions
    {
        private @InputControls m_Wrapper;
        public GameRunningActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_GameRunning_Pause;
        public InputAction @Move => m_Wrapper.m_GameRunning_Move;
        public InputAction @Attack => m_Wrapper.m_GameRunning_Attack;
        public InputAction @Use => m_Wrapper.m_GameRunning_Use;
        public InputAction @Form1 => m_Wrapper.m_GameRunning_Form1;
        public InputAction @Form2 => m_Wrapper.m_GameRunning_Form2;
        public InputAction @Form3 => m_Wrapper.m_GameRunning_Form3;
        public InputAction @FormPrev => m_Wrapper.m_GameRunning_FormPrev;
        public InputAction @Plan => m_Wrapper.m_GameRunning_Plan;
        public InputActionMap Get() { return m_Wrapper.m_GameRunning; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameRunningActions set) { return set.Get(); }
        public void SetCallbacks(IGameRunningActions instance)
        {
            if (m_Wrapper.m_GameRunningActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnPause;
                @Move.started -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnAttack;
                @Use.started -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnUse;
                @Form1.started -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnForm1;
                @Form1.performed -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnForm1;
                @Form1.canceled -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnForm1;
                @Form2.started -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnForm2;
                @Form2.performed -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnForm2;
                @Form2.canceled -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnForm2;
                @Form3.started -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnForm3;
                @Form3.performed -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnForm3;
                @Form3.canceled -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnForm3;
                @FormPrev.started -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnFormPrev;
                @FormPrev.performed -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnFormPrev;
                @FormPrev.canceled -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnFormPrev;
                @Plan.started -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnPlan;
                @Plan.performed -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnPlan;
                @Plan.canceled -= m_Wrapper.m_GameRunningActionsCallbackInterface.OnPlan;
            }
            m_Wrapper.m_GameRunningActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @Form1.started += instance.OnForm1;
                @Form1.performed += instance.OnForm1;
                @Form1.canceled += instance.OnForm1;
                @Form2.started += instance.OnForm2;
                @Form2.performed += instance.OnForm2;
                @Form2.canceled += instance.OnForm2;
                @Form3.started += instance.OnForm3;
                @Form3.performed += instance.OnForm3;
                @Form3.canceled += instance.OnForm3;
                @FormPrev.started += instance.OnFormPrev;
                @FormPrev.performed += instance.OnFormPrev;
                @FormPrev.canceled += instance.OnFormPrev;
                @Plan.started += instance.OnPlan;
                @Plan.performed += instance.OnPlan;
                @Plan.canceled += instance.OnPlan;
            }
        }
    }
    public GameRunningActions @GameRunning => new GameRunningActions(this);

    // GamePlanning
    private readonly InputActionMap m_GamePlanning;
    private IGamePlanningActions m_GamePlanningActionsCallbackInterface;
    private readonly InputAction m_GamePlanning_Pause;
    private readonly InputAction m_GamePlanning_Move;
    private readonly InputAction m_GamePlanning_Use;
    private readonly InputAction m_GamePlanning_Back;
    public struct GamePlanningActions
    {
        private @InputControls m_Wrapper;
        public GamePlanningActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_GamePlanning_Pause;
        public InputAction @Move => m_Wrapper.m_GamePlanning_Move;
        public InputAction @Use => m_Wrapper.m_GamePlanning_Use;
        public InputAction @Back => m_Wrapper.m_GamePlanning_Back;
        public InputActionMap Get() { return m_Wrapper.m_GamePlanning; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlanningActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlanningActions instance)
        {
            if (m_Wrapper.m_GamePlanningActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GamePlanningActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GamePlanningActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GamePlanningActionsCallbackInterface.OnPause;
                @Move.started -= m_Wrapper.m_GamePlanningActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GamePlanningActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GamePlanningActionsCallbackInterface.OnMove;
                @Use.started -= m_Wrapper.m_GamePlanningActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_GamePlanningActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_GamePlanningActionsCallbackInterface.OnUse;
                @Back.started -= m_Wrapper.m_GamePlanningActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_GamePlanningActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_GamePlanningActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_GamePlanningActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public GamePlanningActions @GamePlanning => new GamePlanningActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Newaction;
    public struct MenuActions
    {
        private @InputControls m_Wrapper;
        public MenuActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Menu_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_GamepadControlSchemeSchemeIndex = -1;
    public InputControlScheme GamepadControlSchemeScheme
    {
        get
        {
            if (m_GamepadControlSchemeSchemeIndex == -1) m_GamepadControlSchemeSchemeIndex = asset.FindControlSchemeIndex("GamepadControlScheme");
            return asset.controlSchemes[m_GamepadControlSchemeSchemeIndex];
        }
    }
    private int m_KeyboardControlSchemeSchemeIndex = -1;
    public InputControlScheme KeyboardControlSchemeScheme
    {
        get
        {
            if (m_KeyboardControlSchemeSchemeIndex == -1) m_KeyboardControlSchemeSchemeIndex = asset.FindControlSchemeIndex("KeyboardControlScheme");
            return asset.controlSchemes[m_KeyboardControlSchemeSchemeIndex];
        }
    }
    public interface IGameRunningActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnForm1(InputAction.CallbackContext context);
        void OnForm2(InputAction.CallbackContext context);
        void OnForm3(InputAction.CallbackContext context);
        void OnFormPrev(InputAction.CallbackContext context);
        void OnPlan(InputAction.CallbackContext context);
    }
    public interface IGamePlanningActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
