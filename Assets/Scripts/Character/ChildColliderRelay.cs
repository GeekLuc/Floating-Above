using UnityEngine;

public class ChildColliderRelay : MonoBehaviour
{
    public GameObject parentObject; // Référence à l'objet parent

    private void OnTriggerEnter(Collider other)
    {
        parentObject.SendMessage("OnChildTriggerEnter", other, SendMessageOptions.DontRequireReceiver);
    }

    private void OnTriggerStay(Collider other)
    {
        parentObject.SendMessage("OnChildTriggerStay", other, SendMessageOptions.DontRequireReceiver);
    }

    private void OnTriggerExit(Collider other)
    {
        parentObject.SendMessage("OnChildTriggerExit", other, SendMessageOptions.DontRequireReceiver);
    }
}

