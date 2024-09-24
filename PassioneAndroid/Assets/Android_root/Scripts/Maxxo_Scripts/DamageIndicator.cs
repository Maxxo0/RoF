using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Maxxo
{
    public class DamageIndicator : MonoBehaviour
    {
        public Animator animator;
        public TMP_Text text;
        public void DisplayDamage(int amount)
        {
            text.text = amount.ToString();
            animator.Play("DisplayDamage");
        }
    }
}
