using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if USE_INPUTSYSTEM && ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Yarn.Unity.Example
{

    public class Detective : MonoBehaviour
    {

        [Header("Movement")]
        public float speed = 5f;
        public float forceMultiplier = 10f;
        public float interactionRadius = 1.1f;

        Rigidbody2D rb2d;

        [Header("Interactables")]
        public GameObject interactIcon;

        private DialogueAdvanceInput dialogueInput;
        
        //[Header("UI Elements")]


        // Start is called before the first frame update
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();

            //dialogue stuff
            dialogueInput = FindObjectOfType<DialogueAdvanceInput>();
            //dialogueInput.enabled = false;
            
        }

        // Update is called once per frame
        void Update()
        {
            rb2d.MovePosition(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Time.fixedDeltaTime * speed);

            
            //removes all player control when in dialogue
            /*
            if(FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
            {
                return;
            }*/

            //leave dialogue, disable input
            /*
            if(dialogueInput.enabled)
            {
                dialogueInput.enabled = false;
            }*/

            //detect if want to start conversation
            if(Input.GetKeyDown(KeyCode.F)){
                CheckForNearbyNPC();
            }
            //if players presses E to interact
            /*if(Input.GetKeyDown(KeyCode.E)){
                CheckInteraction();
            }*/

        }

        public void CheckForNearbyNPC() {
            var allParticipants = new List<NPC>((IEnumerable<NPC>)FindObjectOfType<NPC>());
            var target = allParticipants.Find(delegate (NPC p)
            {
                return string.IsNullOrEmpty(p.talkToNode) == false && //has a conversation node?
                (p.transform.position - this.transform.position)// is in range?
                .magnitude <= interactionRadius;

            });
            if(target != null)
            {
                //start dialogue at node
                FindObjectOfType<DialogueRunner>().StartDialogue(target.talkToNode);
                //re-enable input of dialogue
                dialogueInput.enabled = true;
            }
        }

        void FixedUpdate()
        {
            //standard movement method, recommended
            //rb2d.MovePosition(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Time.fixedDeltaTime * speed);

        }

        public void OpenInteractableIcon()
        {
            interactIcon.SetActive(true);
        }

        public void CloseInteractableIcon()
        {
            interactIcon.SetActive(false);
        }

        private void CheckInteraction()
        {

        }


    }

}