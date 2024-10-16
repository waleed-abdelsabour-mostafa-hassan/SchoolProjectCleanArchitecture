﻿namespace SchoolProject.Data.AppMetaData
{
    public static class Router
    {
        public const string SingleRoute = "/{id}";
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";

        public static class StudentRouting
        {
            public const string Prefix = Rule + "Student";
            public const string List = Prefix + "/List";
            public const string PaginatedList = Prefix + "/PaginatedList";
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete/{id}";
        }

        public static class DepartmentRouting
        {
            public const string Prefix = Rule + "Department";
            public const string List = Prefix + "/List";
            public const string PaginatedList = Prefix + "/PaginatedList";
            // public const string GetById = Prefix + SingleRoute;
            public const string GetById = Prefix + "/Id";
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete/{id}";
        }

        public static class ApplicationUserRouting
        {
            public const string Prefix = Rule + "User";
            public const string Create = Prefix + "/Create";
            public const string PaginatedList = Prefix + "/PaginatedList";
            public const string GetById = Prefix + SingleRoute;
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete/{id}";
        }

    }
}
