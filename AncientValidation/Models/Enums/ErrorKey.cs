namespace Me.Kuerschner.AncientValidation.Models.Enums
{
    public enum ErrorKey
    {
        NotNull = 100,
        Equals = 101,
        Must = 102,

        LaterThan = 200,
        EarlierThan = 201,
        EqualsTime = 202,

        NotEmpty = 300,
        EqualsIgnoreCase = 301,

        LowerThan = 400,
        HigherThan = 401,
        Devisible = 402,
        Even = 403,

        IsPhoneNumber = 500,
        IsEmail = 501,
        Match = 502,

        Between = 600,
    }
}
