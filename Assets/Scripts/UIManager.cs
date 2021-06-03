using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public ScrollRect ScrollContent;
    public GameObject GameInfoUI;
    public float ShiftSmooth;
    Animator _gameInfo;
    Button[] _buttons;
    Image _scrollImage;
    private void Start()
    {
        _scrollImage = ScrollContent.gameObject.GetComponent<Image>();
        _gameInfo = GameInfoUI.GetComponent<Animator>();
    }
    public void OpenMenu()
    {
        _scrollImage.raycastTarget = true;
        ScrollContent.velocity = -Vector2.right * ShiftSmooth;
    }
    public void CloseMenu()
    {
        _scrollImage.raycastTarget = false;
        _scrollImage.color = Color.clear;
        ScrollContent.velocity = Vector2.right * ShiftSmooth;

    }
    public void OpenGameInfo()
    {
        GameInfoUI.SetActive(true);
    }
    public void CloseGameInfo()
    {
        StartCoroutine(UnSetActiveGameInfo());
    }
    public IEnumerator UnSetActiveGameInfo()
    {
        _gameInfo.SetTrigger("Close");
        var clipInfo = _gameInfo.GetCurrentAnimatorClipInfo(0)[0];
        yield return new WaitForSeconds(clipInfo.clip.length);
        GameInfoUI.SetActive(false);
    }

}
