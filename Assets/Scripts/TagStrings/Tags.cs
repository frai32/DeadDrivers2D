using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ETags : short
{  
    PLAYER_TAG,
    BOSS_TAG,
    ENEMY_BOLT_TAG,
    MAIN_BOLT_TAG,
    BAUNDARY_TAG,
    DAMAGE_TAG,
    BOLT_TAG,
    BUSTER_TAG,
    SPAWN_POINT_TAG,
    SENAMY_TAG,
    GAME_CONTROLLER_TAG
}

public class Tags
{
    List<string> TagList = new List<string>()
    {
        "Player",       //PLAYER_TAG
        "Boss",         //BOSS_TAG
        "EBolt",        //ENEMY_BOLT_TAG
        "MainBolt",     //MAIN_BOLT_TAG
        "Baundary",     //BAUNDARY_TAG
        "Damage",       //DAMAGE_TAG
        "Bolt",         //BOLT_TAG
        "Buster",       //BUSTER_TAG
        "spawnPoint",   //SPAWN_POINT_TAG
        "SEnemy",       //SENAMY_TAG
        "GameController"//GAME_CONTROLLER_TAG
    };

    public List<string> getTagList
    {
        get
        {
            return TagList;
        }
    }
}
