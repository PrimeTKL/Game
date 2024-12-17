using UnityEngine;
using UnityEngine.InputSystem;


public class MultiInputRebinder : MonoBehaviour
{
    public InputActionReference Jump;

    private void OnEnable()
    {
        Jump.action.Disable();
    }

    private void OnDisable()
    {
        Jump.action.Enable(); 
    }



    
}
