using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class photon_main : MonoBehaviour
{
   public GameObject text_obj;
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
       Text text = text_obj.GetComponent<Text> ();
       text.text = newPlayer.name + "  Join!";
       Debug.Log(newPlayer.name);
       Debug.Log("入室してきたよー");
   }
   //他のプレイヤーが退出
   public void OnPhotonPlayerDisconnected(PhotonPlayer newPlayer)
   {
       Text text = text_obj.GetComponent<Text> ();
       text.text = newPlayer.name + "  Exit!";
       Debug.Log(newPlayer.name);
       Debug.Log("退出しました。");
   }
   
  
  
    public void click_start(){
        PhotonNetwork.Disconnect();
    }
    
    public void click_lobby(){
        PhotonNetwork.LeaveRoom();
    }
    
    
}
