using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using UnityEngine;
using UnityEngine.Networking;

public class ConnectAPI : MonoBehaviour
{
    [SerializeField]
    string serverName;
    [SerializeField]
    string port;
    [SerializeField]
    string databaseName;
    [SerializeField]
    string userName;
    [SerializeField]
    string password;

    [SerializeField]
    string tableName = "questions_collection";


    [SerializeField]
    bool queryId = true;

    [SerializeField]
    bool queryDate;

    [SerializeField]
    bool queryQuestion;

    [SerializeField]
    bool queryChoices;

    [SerializeField]
    bool querySolution;

    private List<QuestionObject> questionsList;

    public List<QuestionObject> QuestionsList { get => questionsList; set => questionsList = value; }

    public void GetRequest()
    {
        QuestionsList = new List<QuestionObject>();
        string connectionString = "Data Source=" + serverName + "," + port + ";Initial Catalog=" + databaseName + ";User ID=" + userName + ";Password=" + password;

        string sql = BuildSelectionQuery();
        SqlConnection connection = new SqlConnection(connectionString);
        try
        {

            connection.Open();

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        QuestionObject data = new QuestionObject(id: reader.GetInt32(0),
                            date: reader.GetDateTime(1),
                            question: reader.GetString(2),
                            choices: reader.GetString(3).Split(";"),
                            solution: reader.GetInt32(4));

                        QuestionsList.Add(data);
                    }
                    reader.Close();
                }

                command.Dispose();
            }

        }
        catch (Exception ex)
        {
            Debug.Log("Can not open connection ! " + ex.Message);
            throw ex;
        }

        finally
        {
            connection.Close();

        }
    }


    private string BuildSelectionQuery()
    {

        List<string> attributesSelections = new List<string>();
        if (queryId) attributesSelections.Add("id");
        if (queryDate) attributesSelections.Add("date");
        if (queryQuestion) attributesSelections.Add("question");
        if (queryChoices) attributesSelections.Add("choices");
        if (querySolution) attributesSelections.Add("solution");

        string selections = String.Join(",", attributesSelections);

        return "Select " + selections + " from " + tableName;
    }
}
