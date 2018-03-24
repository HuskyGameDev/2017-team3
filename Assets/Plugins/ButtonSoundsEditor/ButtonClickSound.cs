using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Plugins.ButtonSoundsEditor
{
    public class ButtonClickSound : MonoBehaviour, IPointerClickHandler
    {
		private int input;
		private int timer;
        public AudioSource AudioSource;
        public AudioClip ClickSound;


		void Awake(){
			input = 60;
			timer = 60;
		}

        public void OnPointerClick(PointerEventData eventData)
        {
			if (timer == 0) {
				PlayClickSound ();
				timer = input;
			} 
				
            
        }

		void Update(){
			if (timer != 0) {
				timer -= 1;
			}
		}
        private void PlayClickSound()
        {
            AudioSource.PlayOneShot(ClickSound);
        }
    }

}
