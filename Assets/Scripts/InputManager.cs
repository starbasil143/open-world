using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 Movement;
    public static bool Dash;
    public static bool Cast;
    public static bool Interact;
    public static bool Slot1;
    public static bool Slot2;
    public static bool Slot3;
    public static bool Slot4;
    public static bool NoSlot;

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _dashAction;
    private InputAction _castAction;
    private InputAction _interactAction;
    private InputAction _slot1Action;
    private InputAction _slot2Action;
    private InputAction _slot3Action;
    private InputAction _slot4Action;
    private InputAction _noSlotAction;


    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();

        _moveAction = _playerInput.actions["Move"];
        _dashAction = _playerInput.actions["Dash"];
        _castAction = _playerInput.actions["Cast"];
        _interactAction = _playerInput.actions["Interact"];
        _slot1Action = _playerInput.actions["Slot 1"];
        _slot2Action = _playerInput.actions["Slot 2"];
        _slot3Action = _playerInput.actions["Slot 3"];
        _slot4Action = _playerInput.actions["Slot 4"];
        _noSlotAction = _playerInput.actions["No Slot"];
    }

    private void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>();
        Dash = _dashAction.WasPressedThisFrame();
        Cast = _castAction.WasPressedThisFrame();
        Interact = _interactAction.WasPressedThisFrame();
        Slot1 = _slot1Action.WasPressedThisFrame();
        Slot2 = _slot2Action.WasPressedThisFrame();
        Slot3 = _slot3Action.WasPressedThisFrame();
        Slot4 = _slot4Action.WasPressedThisFrame();
        NoSlot = _noSlotAction.WasPressedThisFrame();
    }
}
