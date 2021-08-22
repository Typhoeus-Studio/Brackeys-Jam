using UnityEngine;

namespace DialogueSystem
{
    public class DialogueCore : MonoBehaviour
    {
        [SerializeField] private Dialogue nextDialogue;
        [SerializeField] private DialogueBox dialogueBox;


        public bool IsDialogueBoxAvailable()
        {
            return dialogueBox.IsOn;
        }

        public void StartDialogueSequence(Dialogue dialogue)
        {
            if (nextDialogue == null) return;

            dialogueBox.GetTextBox(dialogue.myText, KickNextDialogue);

            void KickNextDialogue()
            {
                StartDialogueSequence(dialogue.nextDialogue);
            }
        }
    }
}