using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbiilityState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, AudioClip audioClip) : base(player, stateMachine, playerData, animBoolName, audioClip)
    {
    }

    public override void Enter()
    {
        base.Enter(); 
        player.SetVelocityY(playerData.jumpVelocity);

        player.AudioSource.PlayOneShot(audioClip);
        isAbilityDone = true;
    }
}
