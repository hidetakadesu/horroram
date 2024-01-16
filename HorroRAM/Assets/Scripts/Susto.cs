using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class Susto : MonoBehaviour {
   private BoxCollider[] Colisores;
   private float cronometroSusto;
   public float TempoDoSusto;
   private bool ativarSusto;
   public GameObject monstro;
   public AudioClip AudioDoSusto;
   void Start (){
      GetComponent<AudioSource>().clip = AudioDoSusto;
      Colisores = gameObject.GetComponents<BoxCollider> ();
      monstro.SetActive (false);
   }
   void Update () {
      if (ativarSusto == true) {
         cronometroSusto += Time.deltaTime;
         monstro.SetActive(true);
      }
      if (cronometroSusto >= TempoDoSusto) {
         ativarSusto = false;
         Destroy (monstro);
         Destroy (gameObject,(GetComponent<AudioSource>().clip.length-TempoDoSusto));
      }
   }
   void OnTriggerEnter (){
      ativarSusto = true;
      GetComponent<AudioSource>().PlayOneShot (GetComponent<AudioSource>().clip);
      foreach (BoxCollider BoxColl in Colisores) {
         BoxColl.enabled = false;
      }
   }
}