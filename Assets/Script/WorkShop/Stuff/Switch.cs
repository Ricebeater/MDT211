using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : Stuff, IInteractable
{
    public Switch() { 
        Name = "Switch";
    }
    public bool isInteractable { get => CanUse; set => CanUse = value; }
    [SerializeField]
    bool isOn = false;
    Animator animator;
    public Identity InteractTo;
    IInteractable IInteract
    {
        get { return InteractTo as IInteractable; }
    }

    public void Interact(Player player)
    {
        isOn = !isOn;
        if (isOn)
        {
            // if (Iinteract != null) { }
            IInteract?.Interact(player);
        }
        else
        {
            IInteract?.Interact(player);
        }
    }
}

