//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Jugador/ControlesJugador.inputactions
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

public partial class @ControlesJugador: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlesJugador()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlesJugador"",
    ""maps"": [
        {
            ""name"": ""Movimiento"",
            ""id"": ""32e7cd77-ddca-48d3-8658-f8d2da3a2f69"",
            ""actions"": [
                {
                    ""name"": ""Mover"",
                    ""type"": ""Value"",
                    ""id"": ""6449ca71-d887-474c-95e2-fb08fd4e79cd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""923911ee-ea1a-4375-9aff-af9ad61ed3d1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f46caf07-d3bf-4ebe-976b-22ec937557b7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f15338db-dd10-40bd-bac5-1c4542e0c8f3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7d23f3a4-fe2e-45de-a550-aef1b64b671d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ef28dfe5-28df-451b-a87c-d6d8ef23e544"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Sprint"",
            ""id"": ""73815eec-a26e-47fb-8e1e-de994817bb30"",
            ""actions"": [
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""16e9c090-5ba2-4b68-8248-d82cab00e6b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a9e3ca58-6824-4bda-a111-427904d311a0"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Hit"",
            ""id"": ""11b674de-4208-4bf6-b11e-69e56d969b5d"",
            ""actions"": [
                {
                    ""name"": ""Hit"",
                    ""type"": ""Button"",
                    ""id"": ""ef537006-4ce0-44d0-844c-4fe28ce368ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""76043a7e-5c49-448a-9296-f631024131a1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Acciones"",
            ""id"": ""935b4945-85a4-4fc3-8770-92490db3eee7"",
            ""actions"": [
                {
                    ""name"": ""Recoger"",
                    ""type"": ""Button"",
                    ""id"": ""75fd2945-27be-464f-b7cf-e7b4db1d6692"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CambiarArma"",
                    ""type"": ""Button"",
                    ""id"": ""0ad16bf4-dd34-45be-86a7-bed14cca2d59"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""47e076e0-494d-4733-b428-4f0d12f044d0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Recoger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c86c9b5-5225-4f5c-9317-b7d8ac313187"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CambiarArma"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movimiento
        m_Movimiento = asset.FindActionMap("Movimiento", throwIfNotFound: true);
        m_Movimiento_Mover = m_Movimiento.FindAction("Mover", throwIfNotFound: true);
        // Sprint
        m_Sprint = asset.FindActionMap("Sprint", throwIfNotFound: true);
        m_Sprint_Sprint = m_Sprint.FindAction("Sprint", throwIfNotFound: true);
        // Hit
        m_Hit = asset.FindActionMap("Hit", throwIfNotFound: true);
        m_Hit_Hit = m_Hit.FindAction("Hit", throwIfNotFound: true);
        // Acciones
        m_Acciones = asset.FindActionMap("Acciones", throwIfNotFound: true);
        m_Acciones_Recoger = m_Acciones.FindAction("Recoger", throwIfNotFound: true);
        m_Acciones_CambiarArma = m_Acciones.FindAction("CambiarArma", throwIfNotFound: true);
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

    // Movimiento
    private readonly InputActionMap m_Movimiento;
    private List<IMovimientoActions> m_MovimientoActionsCallbackInterfaces = new List<IMovimientoActions>();
    private readonly InputAction m_Movimiento_Mover;
    public struct MovimientoActions
    {
        private @ControlesJugador m_Wrapper;
        public MovimientoActions(@ControlesJugador wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mover => m_Wrapper.m_Movimiento_Mover;
        public InputActionMap Get() { return m_Wrapper.m_Movimiento; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovimientoActions set) { return set.Get(); }
        public void AddCallbacks(IMovimientoActions instance)
        {
            if (instance == null || m_Wrapper.m_MovimientoActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovimientoActionsCallbackInterfaces.Add(instance);
            @Mover.started += instance.OnMover;
            @Mover.performed += instance.OnMover;
            @Mover.canceled += instance.OnMover;
        }

        private void UnregisterCallbacks(IMovimientoActions instance)
        {
            @Mover.started -= instance.OnMover;
            @Mover.performed -= instance.OnMover;
            @Mover.canceled -= instance.OnMover;
        }

        public void RemoveCallbacks(IMovimientoActions instance)
        {
            if (m_Wrapper.m_MovimientoActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovimientoActions instance)
        {
            foreach (var item in m_Wrapper.m_MovimientoActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovimientoActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovimientoActions @Movimiento => new MovimientoActions(this);

    // Sprint
    private readonly InputActionMap m_Sprint;
    private List<ISprintActions> m_SprintActionsCallbackInterfaces = new List<ISprintActions>();
    private readonly InputAction m_Sprint_Sprint;
    public struct SprintActions
    {
        private @ControlesJugador m_Wrapper;
        public SprintActions(@ControlesJugador wrapper) { m_Wrapper = wrapper; }
        public InputAction @Sprint => m_Wrapper.m_Sprint_Sprint;
        public InputActionMap Get() { return m_Wrapper.m_Sprint; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SprintActions set) { return set.Get(); }
        public void AddCallbacks(ISprintActions instance)
        {
            if (instance == null || m_Wrapper.m_SprintActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SprintActionsCallbackInterfaces.Add(instance);
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
        }

        private void UnregisterCallbacks(ISprintActions instance)
        {
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
        }

        public void RemoveCallbacks(ISprintActions instance)
        {
            if (m_Wrapper.m_SprintActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISprintActions instance)
        {
            foreach (var item in m_Wrapper.m_SprintActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SprintActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SprintActions @Sprint => new SprintActions(this);

    // Hit
    private readonly InputActionMap m_Hit;
    private List<IHitActions> m_HitActionsCallbackInterfaces = new List<IHitActions>();
    private readonly InputAction m_Hit_Hit;
    public struct HitActions
    {
        private @ControlesJugador m_Wrapper;
        public HitActions(@ControlesJugador wrapper) { m_Wrapper = wrapper; }
        public InputAction @Hit => m_Wrapper.m_Hit_Hit;
        public InputActionMap Get() { return m_Wrapper.m_Hit; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HitActions set) { return set.Get(); }
        public void AddCallbacks(IHitActions instance)
        {
            if (instance == null || m_Wrapper.m_HitActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_HitActionsCallbackInterfaces.Add(instance);
            @Hit.started += instance.OnHit;
            @Hit.performed += instance.OnHit;
            @Hit.canceled += instance.OnHit;
        }

        private void UnregisterCallbacks(IHitActions instance)
        {
            @Hit.started -= instance.OnHit;
            @Hit.performed -= instance.OnHit;
            @Hit.canceled -= instance.OnHit;
        }

        public void RemoveCallbacks(IHitActions instance)
        {
            if (m_Wrapper.m_HitActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IHitActions instance)
        {
            foreach (var item in m_Wrapper.m_HitActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_HitActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public HitActions @Hit => new HitActions(this);

    // Acciones
    private readonly InputActionMap m_Acciones;
    private List<IAccionesActions> m_AccionesActionsCallbackInterfaces = new List<IAccionesActions>();
    private readonly InputAction m_Acciones_Recoger;
    private readonly InputAction m_Acciones_CambiarArma;
    public struct AccionesActions
    {
        private @ControlesJugador m_Wrapper;
        public AccionesActions(@ControlesJugador wrapper) { m_Wrapper = wrapper; }
        public InputAction @Recoger => m_Wrapper.m_Acciones_Recoger;
        public InputAction @CambiarArma => m_Wrapper.m_Acciones_CambiarArma;
        public InputActionMap Get() { return m_Wrapper.m_Acciones; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AccionesActions set) { return set.Get(); }
        public void AddCallbacks(IAccionesActions instance)
        {
            if (instance == null || m_Wrapper.m_AccionesActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AccionesActionsCallbackInterfaces.Add(instance);
            @Recoger.started += instance.OnRecoger;
            @Recoger.performed += instance.OnRecoger;
            @Recoger.canceled += instance.OnRecoger;
            @CambiarArma.started += instance.OnCambiarArma;
            @CambiarArma.performed += instance.OnCambiarArma;
            @CambiarArma.canceled += instance.OnCambiarArma;
        }

        private void UnregisterCallbacks(IAccionesActions instance)
        {
            @Recoger.started -= instance.OnRecoger;
            @Recoger.performed -= instance.OnRecoger;
            @Recoger.canceled -= instance.OnRecoger;
            @CambiarArma.started -= instance.OnCambiarArma;
            @CambiarArma.performed -= instance.OnCambiarArma;
            @CambiarArma.canceled -= instance.OnCambiarArma;
        }

        public void RemoveCallbacks(IAccionesActions instance)
        {
            if (m_Wrapper.m_AccionesActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAccionesActions instance)
        {
            foreach (var item in m_Wrapper.m_AccionesActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AccionesActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AccionesActions @Acciones => new AccionesActions(this);
    public interface IMovimientoActions
    {
        void OnMover(InputAction.CallbackContext context);
    }
    public interface ISprintActions
    {
        void OnSprint(InputAction.CallbackContext context);
    }
    public interface IHitActions
    {
        void OnHit(InputAction.CallbackContext context);
    }
    public interface IAccionesActions
    {
        void OnRecoger(InputAction.CallbackContext context);
        void OnCambiarArma(InputAction.CallbackContext context);
    }
}
