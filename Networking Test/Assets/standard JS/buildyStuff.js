﻿#pragma strict
public var pref		:Transform;
public var pref2	:Transform;
var tiles : GameObject[];
function Start () {
	tiles=GameObject.FindGameObjectsWithTag("Ground");
}

function Update () {

}

function buildTurret(temp2:int,type:int){
	if (networkView.isMine) {
		print("view is mine");
		for(var z:int=0;z<tiles.length;z++){
			if(temp2==1){
				print("server wants a turret");
				if(tiles[z].GetComponent(groundScript).getBuildable()&&tiles[z].GetComponent(groundScript).isSelected(1)){
					print("server can have their turret");
					tiles[z].GetComponent(groundScript).notBuildable();
					var temp:Vector3=tiles[z].transform.position;
					//temp.y+=2;
					if(type==1){
						print("they wanted the pew pew pew one");
						Network.Instantiate(pref , temp, tiles[z].transform.rotation,5);
					}else{
						print("they wanted the pew...boom one");
						Network.Instantiate(pref2, temp, tiles[z].transform.rotation,5);
					}
				}
			}else{
				print("client wants a turret");
				if(tiles[z].GetComponent(groundScript).getBuildable()&&tiles[z].GetComponent(groundScript).isSelected(2)){
					print("client can have their turret");
					tiles[z].GetComponent(groundScript).notBuildable();
					var temp1:Vector3=tiles[z].transform.position;
					//temp1.y;
					if(type==1){
						print("they wanted the pew pew pew one");
						Network.Instantiate(pref , temp1, tiles[z].transform.rotation,5);
					}else{
						print("they wanted the pew...boom one");
						Network.Instantiate(pref2, temp1, tiles[z].transform.rotation,5);
					}
				}
			}
		}
	}
}

