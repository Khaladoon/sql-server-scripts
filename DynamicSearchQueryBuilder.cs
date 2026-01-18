using System.Collections.Generic;
using System.Data.SqlClient;

public class DynamicSearchQueryBuilder
{
    private readonly List<string> conditions = new();
    private readonly List<SqlParameter> parameters = new();

    public void AddLikeCondition(string columnName, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return;

        string parameterName = $"@{columnName}";
        conditions.Add($"{columnName} LIKE {parameterName}");
        parameters.Add(
            new SqlParameter(parameterName, $"%{value}%")
        );
    }

    public SqlCommand BuildQuery(
        string tableName,
        SqlConnection connection
    )
    {
        string whereClause = conditions.Count > 0
            ? "WHERE " + string.Join(" AND ", conditions)
            : "";

        var command = new SqlCommand(
            $"SELECT * FROM {tableName} {whereClause}",
            connection
        );

        command.Parameters.AddRange(parameters.ToArray());
        return command;
    }
}
