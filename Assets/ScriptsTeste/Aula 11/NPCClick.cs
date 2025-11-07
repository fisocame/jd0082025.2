using UnityEngine;
using DialogueEditor;

public class NPCClick : MonoBehaviour
{
    public NPCConversation myConversation;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}