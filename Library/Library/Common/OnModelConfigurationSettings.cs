namespace Library.Common
{
    public static class OnModelConfigurationSettings
    {
        public static class Book
        {
            public const int TitleLength = 50;
            public const int TitleMinLength = 10;
            public const int AuthorMaxLength = 50;
            public const int AuthorMinLength = 5;
            public const int DescriptionMaxLength = 5000;
            public const int DescriptionMinLength = 5;
            public const int RatingMinValue = 0;
            public const int RatingMaxValue = 10;
            
        }

        public static class Category
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 5;
        }
    }
}
