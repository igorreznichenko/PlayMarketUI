using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlayMarketUI.UserMenu
{
    public class UserMenuBehavior : MonoBehaviour
    {
        Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void CloseMenu()
        {
            StartCoroutine(closeMenu());
        }
        private IEnumerator closeMenu()
        {
            _animator.SetTrigger("Close");
            float length = _animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
            yield return new WaitForSeconds(length);
            gameObject.SetActive(false);
        }
    }
}