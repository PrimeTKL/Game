using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindingDisplay : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpAction = null;
    [SerializeField] private TMP_Text bindingDisplayNameText = null;
    [SerializeField] private GameObject startRebindObject = null;
    [SerializeField] private GameObject waitingForInputObject = null;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    private const string RebindsKey = "rebinds";

    private void Start()
    {
        string rebinds = PlayerPrefs.GetString(RebindsKey, string.Empty);
        if (!string.IsNullOrEmpty(rebinds))
        {
            PlayerInput playerInput = FindObjectOfType<PlayerInput>();
            playerInput.actions.LoadBindingOverridesFromJson(rebinds);
        }

        UpdateBindingDisplay();
    }

    public void Save()
    {
        PlayerInput playerInput = FindObjectOfType<PlayerInput>();
        string rebinds = playerInput.actions.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString(RebindsKey, rebinds);
        PlayerPrefs.Save();
    }

    public void StartRebinding()
    {
        startRebindObject.SetActive(false);
        waitingForInputObject.SetActive(true);


        Debug.Log("Binding  rebind: " + InputControlPath.ToHumanReadableString(
        jumpAction.action.bindings[jumpAction.action.GetBindingIndexForControl(jumpAction.action.controls[0])].effectivePath,
        InputControlPath.HumanReadableStringOptions.OmitDevice
    ));

        jumpAction.action.Disable();

        rebindingOperation = jumpAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                RebindComplete();
                Save();
            })
            .Start();
    }

    private void RebindComplete()
    {
        rebindingOperation.Dispose();
        rebindingOperation = null;

        UpdateBindingDisplay();

        jumpAction.action.Enable();
        waitingForInputObject.SetActive(false);
        startRebindObject.SetActive(true);
    }

    private void UpdateBindingDisplay()
    {
        string bindingString = jumpAction.action.GetBindingDisplayString();
        bindingDisplayNameText.text = bindingString;
    }
}
