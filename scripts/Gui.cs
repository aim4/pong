using Godot;
using System;

public class Gui : Control
{

    [Signal]
    public delegate void NewGame();
    [Signal]
    public delegate void EndGame();
    private MarginContainer _scoreContainer;
    private MarginContainer _newGameContainer;

    public override void _Ready()
    {
        _scoreContainer = GetNode<MarginContainer>("Score");
        _newGameContainer = GetNode<MarginContainer>("NewGame");
        _newGameContainer.Hide();
    }

    public void UpdatePlayerScore(int score)
    {
        var playerScore = _scoreContainer.GetNode<Label>("NinePatchRect/PlayerScore");
        playerScore.Text = score.ToString();
    }

    public void UpdateEnemyScore(int score)
    {
        var enemyScore = _scoreContainer.GetNode<Label>("NinePatchRect/EnemyScore");
        enemyScore.Text = score.ToString();
    }

    public void PromptNewGame()
    {
        _newGameContainer.Show();
    }

    public void OnYesButtonPressed()
    {
        EmitSignal(nameof(NewGame));
        _newGameContainer.Hide();
    }

    public void OnNoButtonPressed()
    {
        EmitSignal(nameof(EndGame));
        _newGameContainer.Hide();
    }
}
