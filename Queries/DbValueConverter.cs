namespace DatabaseLibrary.Queries

{
    public static class DbValueConverter
    {
        public static string ToNullableString(string stringLine)
        {
            if (stringLine == String.Empty)
                return null;
            else
                return stringLine;
        }
    }
}
