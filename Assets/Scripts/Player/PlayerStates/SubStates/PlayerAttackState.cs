using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbiilityState
{
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, AudioClip audioClip) : base(player, stateMachine, playerData, animBoolName, audioClip)
    {
        
    }

    public override void Enter()
    {
        if (player.InputHandler.LightAttackInput)
        {
            this.animBoolName = "lightAttack";
        }
        else if (player.InputHandler.HeavyAttackInput)
        {
            this.animBoolName = "heavyAttack";
        }

        base.Enter();    
        
        player.AudioSource.PlayOneShot(audioClip);
        isAbilityDone = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.SetVelocityX(0);
    }
}
