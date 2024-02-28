using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private const string password = "dudin";

    public TMP_InputField passwordInput;
    public TextMeshProUGUI toastTmp;
    public void ValidatePassword()
    {
        if (passwordInput.text == password)
        {
            SceneManager.LoadScene(1);
        }
        else
        { 
            passwordInput.text = string.Empty;
            toastTmp.text = "Wrong Password";
            Invoke(nameof(ClearToast), 2);
        }
    }

    private void ClearToast()
    {
        toastTmp.text = string.Empty;
    }
}
