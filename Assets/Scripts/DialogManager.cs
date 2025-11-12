using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogManager : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] int lettersPerSecond;
    [SerializeField] private GameObject dialogBox;

    public event Action OnShowDialog;
    public event Action OnHideDialog;
    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    Dialog dialog;
    int currentLine = 0;
    bool isTyping;

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isTyping)
        {
            ++currentLine;
            if (currentLine<dialog.Lines.Count>)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                dialogBox.SetActive(false);
                OnHideDialog?.Invoke();
            }
        }
    }
    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();
        this.dialog = dialog;
        dialogBox.SetActive(true);

    }
    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
    }
}
