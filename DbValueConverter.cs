namespace DatabaseLibrary

{
    public static class DbValueConverter
    {
        public static string? ToNullableString(string value) =>
            value == string.Empty ? null : value;
    }
}
