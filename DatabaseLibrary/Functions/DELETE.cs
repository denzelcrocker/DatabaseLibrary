namespace DatabaseLibrary.Functions;

internal class DELETE
{
    public static bool Employee(Employee employee)
    {
        using ParsethingContext db = new();
        bool isSaved = true;

        try
        {
            _ = db.Employees.Remove(employee);
            _ = db.SaveChanges();
        }
        catch { isSaved = false; }

        return isSaved;
    }
}