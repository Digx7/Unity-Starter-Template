using UnityEngine;
using TMPro;

namespace Digx7.Zygote
{
    public class BuildNumberHelper : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;

        private void Start()
        {
            textMeshProUGUI.text = Application.version;
        }
    }
}
