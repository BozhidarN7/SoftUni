namespace PlayersAndMonsters.Common
{
    public static class ConstantMessages
    {
        public const string SuccessfullyAddedPlayer =
            "Successfully added player of type {0} with username: {1}";

        public const string SuccessfullyAddedCard =
            "Successfully added card of type {0}Card with name: {1}";

        public const string SuccessfullyAddedPlayerWithCards
            = "Successfully added card: {0} to user: {1}";

        public const string FightInfo
            = "Attack user health {0} - Enemy user health {1}";

        public const string PlayerReportInfo
            = "Username: {0} - Health: {1} - Cards {2}";

        public const string CardReportInfo
            = "Card: {0} - Damage: {1}";

        public const string DefaultReportSeparator
            = "###";
        public const string InvalidNameMessage =
            "Player's username cannot be null or an empty string. ";
        public const string NegativeNumberMessage =
            "Player's health bonus cannot be less than zero. ";
        public const string NegativeDamageMessage =
            "Damage points cannot be less than zero.";
        public const string InvalidCardNameMessage =
            "Card's name cannot be null or an empty string.";
        public const string NegativeCardDamagePointsMessage =
            "Card's damage points cannot be less than zero.";
        public const string NegativeHealthPointsMessage =
            "Card's HP cannot be less than zero.";
    }
}
