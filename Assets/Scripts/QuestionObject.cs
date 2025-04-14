using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class QuestionObject
{

    [SerializeField]
    private int id;

    [SerializeField]
    private DateTime date;

    [SerializeField]
    private string question;

    [SerializeField]
    private string[] choices;

    [SerializeField]
    private int solution;

    public QuestionObject(int id, DateTime date, string question, string[] choices, int solution)
    {
        this.id = id;
        this.date = date;
        this.question = question;
        this.choices = choices;
        this.solution = solution;

    }

    public int Id { get => id; set => id = value; }
    public DateTime Date { get => date; set => date = value; }
    public string Question { get => question; set => question = value; }
    public string[] Choices { get => choices; set => choices = value; }
    public int Solution { get => solution; set => solution = value; }

    public List<string> ChoicesAsList()
    {
        return new List<string>(choices);
    }
}
