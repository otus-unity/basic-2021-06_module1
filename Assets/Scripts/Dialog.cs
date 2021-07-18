using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Dialog")]
    public class Dialog : ScriptableObject
    {
        public string Text;
        public Dialog[] Next;

        public void Save()
        {
            this.Save();
        }
    }
}