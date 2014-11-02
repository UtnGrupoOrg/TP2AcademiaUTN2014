using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Collections.Specialized;
using System.Configuration.Provider;

namespace Personal.Providers
{
    public sealed class MyXmlProvider : RoleProvider
    {
        private string pApplicationName;
        public override string ApplicationName
        {
            get { return pApplicationName; }
            set { pApplicationName = value; }
        }

        /*
         * Roles Table
         */
        private string rolesTable = "Roles";
        private string[] columnRoles = { "RoleName" };
        private string rolesTableFile = "Roles.xml";

        /*
         * UsersInRoles Table
         */
        private string usersInRolesTable = "UsersInRoles";
        private string[] columnUsersInRoles = { "Users", "Roles" };
        private string usersInRolesTableFile = "UsersInRoles.xml";

        private DataSet dtsRoles, dtsUsersInRoles;

        private void createTable(string tableName, string[] columnsTable, string XMLFileName)
        {
            DataSet dts;
            DataTable dtb;
            System.IO.FileInfo TheFile = new System.IO.FileInfo( HttpContext.Current.Server.MapPath("./") + XMLFileName);
            if (!TheFile.Exists)
            {
                dts = new DataSet();
                dtb = dts.Tables.Add(tableName);
                foreach (string column in columnsTable)
                    dtb.Columns.Add(column, Type.GetType("System.String"));
                dts.WriteXml(HttpContext.Current.Server.MapPath("./") + XMLFileName, System.Data.XmlWriteMode.WriteSchema);
            }
        }
        public override void Initialize(string name, NameValueCollection config)
        {
            name = "MyXmlProvider";
            base.Initialize(name, config);

            createTable(rolesTable, columnRoles, rolesTableFile);
            createTable(usersInRolesTable, columnUsersInRoles, usersInRolesTableFile);

            dtsRoles = new DataSet();
            dtsUsersInRoles = new DataSet();
            dtsRoles.ReadXml(HttpContext.Current.Server.MapPath("./") + rolesTableFile);
            dtsUsersInRoles.ReadXml(HttpContext.Current.Server.MapPath("./") + usersInRolesTableFile);
        }

        //
        // RoleProvider.AddUsersToRoles
        //
        public override void AddUsersToRoles(string[] usernames, string[] rolenames)
        {
            foreach (string rolename in rolenames)
            {
                if (!RoleExists(rolename))
                {
                    throw new ProviderException("Role name not found.");
                }
            }

            foreach (string username in usernames)
            {
                foreach (string rolename in rolenames)
                {
                    if (IsUserInRole(username, rolename))
                    {
                        throw new ProviderException("User is already in role.");
                    }
                }
            }

            foreach (string username in usernames)
            {
                foreach (string rolename in rolenames)
                {
                    string[] record = { username, rolename };
                    dtsUsersInRoles.Tables[0].Rows.Add(record);
                }
            }
            dtsUsersInRoles.WriteXml(HttpContext.Current.Server.MapPath("./") + usersInRolesTableFile, XmlWriteMode.WriteSchema);
        }

        //
        // RoleProvider.CreateRole
        //
        public override void CreateRole(string rolename)
        {
            if (RoleExists(rolename))
            {
                throw new ProviderException("Role name already exists.");
            }

            string[] record = { rolename };
            dtsRoles.Tables[0].Rows.Add(record);
            dtsRoles.WriteXml(HttpContext.Current.Server.MapPath("./") + rolesTableFile, XmlWriteMode.WriteSchema);
        }


        //
        // RoleProvider.DeleteRole
        //

        public override bool DeleteRole(string rolename, bool throwOnPopulatedRole)
        {
            if (!RoleExists(rolename))
            {
                throw new ProviderException("Role does not exist.");
            }

            if (throwOnPopulatedRole && GetUsersInRole(rolename).Length > 0)
            {
                throw new ProviderException("Cannot delete a populated role.");
            }

            DataRow[] dtr = dtsRoles.Tables[0].Select(columnRoles + " = '" + rolename + "'");
            dtsRoles.Tables[0].Rows.Remove(dtr[0]);
            dtsRoles.WriteXml(HttpContext.Current.Server.MapPath("./") + rolesTableFile, XmlWriteMode.WriteSchema);

            return true;
        }

        //
        // RoleProvider.GetAllRoles
        //
        public override string[] GetAllRoles()
        {
            string tmpRoleNames = "";

            foreach (DataRow row in dtsRoles.Tables[0].Rows)
            {
                tmpRoleNames += row[columnRoles[0]] + ",";
            }

            if (tmpRoleNames.Length > 0)
            {
                tmpRoleNames = tmpRoleNames.Substring(0, tmpRoleNames.Length - 1);
                return tmpRoleNames.Split(',');
            }

            return new string[0];
        }

        //
        // RoleProvider.GetRolesForUser
        //
        public override string[] GetRolesForUser(string username)
        {
            string tmpRoleNames = "";

            DataRow[] dtr = dtsUsersInRoles.Tables[0].Select(columnUsersInRoles[0] + " = '" + username + "'");

            foreach (DataRow row in dtr)
            {
                tmpRoleNames += row[columnUsersInRoles[1]] + ",";
            }

            if (tmpRoleNames.Length > 0)
            {
                tmpRoleNames = tmpRoleNames.Substring(0, tmpRoleNames.Length - 1);
                return tmpRoleNames.Split(',');
            }

            return new string[0];
        }


        //
        // RoleProvider.GetUsersInRole
        //
        public override string[] GetUsersInRole(string rolename)
        {
            string tmpUserNames = "";

            DataRow[] dtr = dtsUsersInRoles.Tables[0].Select(columnUsersInRoles[1] + " = '" + rolename + "'");

            foreach (DataRow row in dtr)
            {
                tmpUserNames += row[columnUsersInRoles[1]] + ",";
            }

            if (tmpUserNames.Length > 0)
            {
                // Remove trailing comma.
                tmpUserNames = tmpUserNames.Substring(0, tmpUserNames.Length - 1);
                return tmpUserNames.Split(',');
            }

            return new string[0];
        }

        //
        // RoleProvider.IsUserInRole
        //
        public override bool IsUserInRole(string username, string rolename)
        {
            bool userIsInRole = false;
            string query = columnUsersInRoles[1] + " = '" + rolename + "' AND " + columnUsersInRoles[0] + " = '" + username + "'";
            int numRecs = dtsUsersInRoles.Tables[0].Select(query).Length;

            if (numRecs > 0)
            {
                userIsInRole = true;
            }

            return userIsInRole;
        }

        //
        // RoleProvider.RemoveUsersFromRoles
        //
        public override void RemoveUsersFromRoles(string[] usernames, string[] rolenames)
        {
            foreach (string rolename in rolenames)
            {
                if (!RoleExists(rolename))
                {
                    throw new ProviderException("Role name not found.");
                }
            }

            foreach (string username in usernames)
            {
                foreach (string rolename in rolenames)
                {
                    if (!IsUserInRole(username, rolename))
                    {
                        throw new ProviderException("User is not in role.");
                    }
                }
            }

            string query;
            DataRow[] dtr;
            foreach (string username in usernames)
            {
                foreach (string rolename in rolenames)
                {
                    query = columnUsersInRoles[1] + " = '" + rolename + "' AND " + columnUsersInRoles[0] + " = '" + username + "'";
                    dtr = dtsUsersInRoles.Tables[0].Select(query);
                    dtsUsersInRoles.Tables[0].Rows.Remove(dtr[0]);
                }
            }
            dtsUsersInRoles.WriteXml(HttpContext.Current.Server.MapPath("./") + usersInRolesTableFile, XmlWriteMode.WriteSchema);
        }

        //
        // RoleProvider.RoleExists
        //
        public override bool RoleExists(string rolename)
        {
            bool exists = false;

            string query = columnRoles[0] + " = '" + rolename + "'";
            int numRecs = dtsRoles.Tables[0].Select(query).Length;

            if (numRecs > 0)
            {
                exists = true;
            }

            return exists;
        }

        //
        // RoleProvider.FindUsersInRole
        //
        public override string[] FindUsersInRole(string rolename, string usernameToMatch)
        {
            return new string[0];
        }
    }
}