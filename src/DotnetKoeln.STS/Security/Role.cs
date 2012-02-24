/*
 * 08.02.2009 - Albert Weinert- erstellt.
 * 
 */

using System;

namespace DotnetKoeln.STS.Security
{
    public static class Role
    {
        public const string Administrator = "Administrator";

        public const string Moderator = "Moderator";

        public const string User = "User";

        private static readonly string[] AdministratorRoles = new[] { User, Moderator, Administrator };
        private static readonly string[] ModeratorRoles = new[] { User, Moderator };
        private static readonly string[] UserRoles = new[] { User };

        public static string[] GetRolesForRole(string role) {
            switch (role) {
                case User:
                    return UserRoles;
                case Moderator:
                    return ModeratorRoles;
                case Administrator:
                    return AdministratorRoles;
            }
            return new string[0];
        }
    }
}