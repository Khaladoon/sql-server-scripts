using System.Data.SqlClient;

public class DynamicQueryBuilder
{
    public static SqlCommand BuildSearchCommand(
        SqlConnection conn,
        string wellNo,
        string town,
        string owner,
        double? minDepth,
        double? maxDepth)
    {
        var cmd = new SqlCommand("SearchWells", conn);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@WellNo", (object)wellNo ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Town", (object)town ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Owner", (object)owner ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@MinDepth", (object)minDepth ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@MaxDepth", (object)maxDepth ?? DBNull.Value);

        return cmd;
    }
}
