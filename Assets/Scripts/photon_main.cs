using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class photon_main : MonoBehaviour
{
   public GameObject text_obj;
   public GameObject input_obj;
   PhotonView  photonView;
   string inp_s="";
   bool input_flag=false;
   
   private IEnumerator wait_func(string box) {
       Text text = text_obj.GetComponent<Text> ();
       text.text = box;
       // 3秒待つ
       yield return new WaitForSeconds (3.0f);
       text.text ="";
       
   }
   void Start() {
       
       photonView  = GetComponent<PhotonView>();
       
   }
   //部屋から退出した時
   public void OnLeftRoom(){
       Debug.Log("退出したお");
       SceneManager.LoadScene("Lobby");
   }
   //切断した時
   public void OnDisconnectedFromPhoton(){
       Debug.Log("切断したお");
       SceneManager.LoadScene("Start");
   }
   
   /* 他のプレイヤーが入室してきた時-->ならんぞ！！
   public void OnPlayerEnteredRoom(PhotonPlayer newPlayer)
   {
       //Text text =text_obj
       Debug.Log(newPlayer.name);
       Debug.Log("入室してきたよー");
   } */
   // 他のプレイヤーが入室してきた時 --> こっちはなるぞ
   public void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
   {
       
       StartCoroutine ( wait_func( newPlayer.name + "  Join!" ) );
       //text.text = newPlayer.name + "  Join!";
       Debug.Log(newPlayer.name);
       Debug.Log("入室してきたよー");
      
   }
   //他のプレイヤーが退出
   public void OnPhotonPlayerDisconnected(PhotonPlayer newPlayer)
   {
       Text text = text_obj.GetComponent<Text> ();
       StartCoroutine ( wait_func( newPlayer.name + "  Exit!") );
       Debug.Log(newPlayer.name);
       Debug.Log("退出しました。");
   }
   
  
  
    public void click_start(){
        PhotonNetwork.Disconnect();
    }
    
    public void click_lobby(){
        PhotonNetwork.LeaveRoom();
    }
    public void InputText(){
        InputField inp =input_obj.GetComponent<InputField> ();
        //入力された文字をinp_sに格納
        inp_s = inp.text;
        //input_flag
        input_flag=true;
    
    }
    public void send(){
        if (input_flag){
            //sending
            inp_s=PhotonNetwork.playerName+"さん:"+inp_s;
            Debug.Log("sending --->"+ inp_s);
            
            photonView.RPC("Messaging", PhotonTargets.Others, inp_s );
            
            InputField inp =input_obj.GetComponent<InputField> ();
            inp.text="";
        }else{
            Debug.Log("入力されていません");
        }
        input_flag = false;
    }
    /* ここから PhotonView photonView の設定 */
   
    [PunRPC]
    private void Messaging(string message)
    {
       StartCoroutine ( wait_func(message) );
    }
    
    
}
