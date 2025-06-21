using UnityEngine;

public class Vent : Interactable
{
    [SerializeField] private GameObject vent;
    private bool ventIsOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        ventIsOpen = !ventIsOpen;
        vent.GetComponent<Animator>().SetBool("VentIsOpen", ventIsOpen);
    }
}
