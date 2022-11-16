using LoLRunes.Shared.LiteralIdentifiers;
using LoLRunes.Shared.Utils.UnityComponents;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LoLRunes.View.Controllers
{
    public class MessageWindowController : MonoBehaviour
    {
        public static MessageWindowController instance { get; private set; }

        [Header("References")]
        [SerializeField] private TMP_Text titleInputField;
        [SerializeField] private TMP_Text messageInputField;
        [SerializeField] private GameObject aggregator;

        [Header("Parameters")]
        [Tooltip("The time delay that will be applied before the outside close feature is enabled.")]
        [SerializeField] private float outsideCloseDelay;

        private float displayStartTime;

        public bool isDisplaying { get; private set; }       

        private void Awake()
        {
            if (instance)
            {
                Destroy(this);
                return;
            }

            instance = this;

            aggregator.SetActive(false);
            isDisplaying = false;
        }

        private void Update()
        {
            EvaluateCloseMassageBox();
        }

        public bool DisplayMessage(string title, string message)
        {
            if (isDisplaying) return false;

            titleInputField.text = title;
            messageInputField.text = message;

            displayStartTime = Time.time;
            aggregator.SetActive(true);
            isDisplaying = true;

            return true;
        }

        public void CloseMessageBox()
        {
            aggregator.SetActive(false);
            isDisplaying = false;
        }

        private void EvaluateCloseMassageBox()
        {
            if (!isDisplaying) return;

            if (Input.GetKeyDown(KeyCode.Return) ||
                Input.GetKeyDown(KeyCode.KeypadEnter) ||
                Input.GetKeyDown(KeyCode.Escape))
            {
                CloseMessageBox();
                return;
            }

            CloseOnClickOutside();
        }

        private void CloseOnClickOutside()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            if (Time.time - displayStartTime < outsideCloseDelay) return;

            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();

            EventSystem.current.RaycastAll(pointerEventData, raycastResults);

            bool close = !raycastResults.Exists(r => TransformUtility.FindParentByTag(r.gameObject.transform, TagName.MessageCanvas));

            if(close) CloseMessageBox();
        }
    }
}
