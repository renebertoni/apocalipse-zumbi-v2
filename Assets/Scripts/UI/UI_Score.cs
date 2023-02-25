using UnityEngine;
using TMPro;

public class UI_Score : MonoBehaviour
{
    Helper _helper;
    TMP_Text _time, _enemies, _survivors, _newRecord;

    void OnEnable()
    {
        _helper = new Helper();    
        ScoreHandler.ShowScore += OnShowScore;
        _time = GameObject.Find(Constants.TIME_TEXT)?.GetComponent<TMP_Text>();
        _enemies = GameObject.Find(Constants.ENEMIES_TEXT)?.GetComponent<TMP_Text>();
        _survivors = GameObject.Find(Constants.SURVIVORS_TEXT)?.GetComponent<TMP_Text>();
        _newRecord = GameObject.Find(Constants.NEW_RECORD_TEXT)?.GetComponent<TMP_Text>();
    }

    void OnDisable()
    {
        ScoreHandler.ShowScore -= OnShowScore;
    }

    void OnShowScore(Score score, bool newScore)
    {
        var timeConverted = _helper.TimeConvert(score.Time); // TODO gostaria de usar destructuring
        var minutes = timeConverted[0];
        var seconds = timeConverted[1];
        try{
            _time.text = $"Você sobreviveu por {minutes} minutos e {seconds} segundos";
            _enemies.text = $"Você matou {score.Enemies} zumbis";
            _survivors.text = $"Você resgatou {score.Survivors} sobreviventes";
            _newRecord.text = newScore ? "Novo Record!!!" : "";
        }
        catch
        {
            Debug.Log("Não foi possível encontar os elementos de interface");
        }
    }
}
