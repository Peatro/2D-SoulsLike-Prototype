using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;

    private bool JumpInput;
    private bool LightAttackInput;
    private bool HeavyAttackInput;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        JumpInput = player.InputHandler.JumpInput;
        LightAttackInput = player.InputHandler.LightAttackInput;
        HeavyAttackInput = player.InputHandler.HeavyAttackInput;

        if (JumpInput == true)
        {
            //player.InputHandler.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }
        if (player.CheckIfGrounded() == false)
        {
            stateMachine.ChangeState(player.InAirState);
        }
        if (LightAttackInput || HeavyAttackInput)
        {
            stateMachine.ChangeState(player.AttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
