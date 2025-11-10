using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogManager : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] int lettersPerSecond;
    [SerializeField] private GameObject dialogBox;
    public void ShowDialog()
    {
        dialogBox.SetActive(True);
        StartCoroutine(TypeDialog());
    }
    public IEnumerator TypeDialog(string line)
    {
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }
}
