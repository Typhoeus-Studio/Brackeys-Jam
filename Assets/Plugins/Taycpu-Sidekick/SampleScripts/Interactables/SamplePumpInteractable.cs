using HyperTemplate.HyperMono.HyperGameObject;

public class SamplePumpInteractable : HyperInteractable
{
    public override void Initialize()
    {
    }

    public override void Interact()
    {
        if (isInteracted) return;
        base.Interact();


        gameObject.SetActive(false);
    }
}