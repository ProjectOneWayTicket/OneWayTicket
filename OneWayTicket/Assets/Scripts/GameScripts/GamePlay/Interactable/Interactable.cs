using UnityEngine;
using System.Collections;

namespace GamePlay.Interactable
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        public string Label; //Localization Key
        public string LookString; //Localization Key
        public bool Active = true;
        public bool Lookable = true;

        public bool PickUpable = false;
        public bool Talkable = false;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool IsActive() { return Active; }
        public bool CanLookAt() { return Lookable; }
        public string GetLabel() { return Label.Localize(); }
        public void Look() { LookString.Localize(); }

    }
}
