using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueOJ")]

public class DialogueOJ : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;

    public string[] Dialogue => dialogue;
}
