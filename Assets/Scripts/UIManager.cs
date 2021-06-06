using PlayMarketUI.UserMenu;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PlayMarketUI.UIManager{ 
public class UIManager : MonoBehaviour
{
    public GameObject GameInfoUI;
    public UserMenuBehavior _userMenu;
    Animator _gameInfo;
    private void Awake()
    {
        _gameInfo = GameInfoUI.GetComponent<Animator>();
    }
    public void OpenMenu()
    {
        _userMenu.gameObject.SetActive(true);
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
}