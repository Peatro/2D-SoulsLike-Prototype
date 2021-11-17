using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    private AudioClip soundEffect;

    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, AudioClip soundEffect) : base(player, stateMachine, playerData, animBoolName)
    {
        this.soundEffect = soundEffect;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.AudioSource.clip = soundEffect;
        if (player.AudioSource.isPlaying == false)
        {
            player.AudioSource.Play();
        }        
    }

    public override void Exit()
    {
        base.Exit();
        player.AudioSource.Stop();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.CheckIfShouldFlip(xInput);
        player.SetVelocityX(playerData.movementVelocity * xInput);

        if (xInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
